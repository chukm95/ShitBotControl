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
    public abstract class MessageService
    {
        //concurrent queue for incoming messages
        private ConcurrentQueue<Message> messageInQueue;
        //concurrent queue for outgoing messages
        private ConcurrentQueue<Message> messageOutQueue;
        //connection we use
        private Connection connection;

        protected MessageService()
        {
            messageInQueue = new ConcurrentQueue<Message>();
            messageOutQueue = new ConcurrentQueue<Message>();
            connection = new Connection(this);
        }

        //try connecting to address and port
        public async Task TryConnect(string address, int port)
        {
            //create ip address variable
            IPAddress ip;

            //try parsing it and create a object
            if (!IPAddress.TryParse(address, out ip))
                //parsing failed throw exception
                throw new Exception("Invalid ip address");

            //parsing succesfull check for connection
            await connection.TryConnect(ip, port);
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

        public void Poll()
        {
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
