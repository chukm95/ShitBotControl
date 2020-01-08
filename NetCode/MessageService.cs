using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCode
{
    public delegate void TimeOut();

    public abstract class MessageService
    {
        //concurrent queue for incoming messages
        private ConcurrentQueue<Message> messageInQueue;
        //concurrent queue for outgoing messages
        private ConcurrentQueue<Message> messageOutQueue;
        //connection we use
        private Connection connection;
        //lock
        private SemaphoreSlim semaLock;

        //pingtime
        private long pingTime;

        public event TimeOut OnTimeOut;

        protected MessageService()
        {
            messageInQueue = new ConcurrentQueue<Message>();
            messageOutQueue = new ConcurrentQueue<Message>();
            connection = new Connection(this);
            semaLock = new SemaphoreSlim(1, 1);
            pingTime = 0;
        }


        //try connecting to address and port
        public async Task<bool> TryConnect(string address, int port)
        {
            //create ip address variable
            IPAddress ip;

            //try parsing it and create a object
            if (!IPAddress.TryParse(address, out ip))
                //return false
                return false;

            //parsing succesfull check for connection
            try
            {
                await connection.TryConnect(ip, port);
            }
            catch(Exception e)
            {
                return false;
            }

            return true;
        }

        protected async Task Ping()
        {
            await semaLock.WaitAsync();
            pingTime += 10;
            semaLock.Release();
        }

        protected async Task<long> GetPingTime()
        {
            long pt = 0;
            await semaLock.WaitAsync();
            pt = pingTime;
            semaLock.Release();

            return pt;
        }

        //handle incoming message
        protected abstract Message SortMessage(short id);

        internal void ReadMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[sizeof(short)];
            stream.Read(buffer, 0, buffer.Length);
            short id = BitConverter.ToInt16(buffer.Reverse().ToArray(), 0);

            Message message = SortMessage(id);

            if(message != null)
                message.ReadMessage(stream);

            //check if the message doesnt equal null
            if(message != null)
                messageInQueue.Enqueue(message);
        }

        //add a message to the send queue
        public void SendMessage(Message message)
        {
            //check if the message is outgoing
            if (message.MessageType != Message.MessageTypes.OUTGOING)
                //if the message is not outgoing throw a exception
                throw new Exception("message needs to be outgoing!");

            //check if the message doesnt equal to null
            if(message != null)
                //if the message is equal to null 
                messageOutQueue.Enqueue(message);
        }

        //let the connection dequeue and send messages
        internal void SendMessages()
        {
            //while we have messages
            while(messageOutQueue.Count > 0)
            {
                //temporary message
                Message m;
                //check if we can deque a message
                if (messageOutQueue.TryDequeue(out m))
                {
                    //message dequed send it!
                    connection.SendMessage(m);
                }

            }
        }

        public async void Poll()
        {
            if (await GetPingTime() > 2000)
                OnTimeOut?.Invoke();

            while(messageInQueue.Count > 0)
            {
                Message m;
                if(messageInQueue.TryDequeue(out m))
                {
                    OnPoll(m);
                }
            }
        }

        protected abstract void OnPoll(Message m);

        public void Stop()
        {
            connection.StopRunning();
        }
    }
}
