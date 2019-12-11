using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetCode
{
    internal class Connection
    {
        //the service we use
        private MessageService messageService;
        //the client we are communicating trough
        private TcpClient client;
        //the stream to read and send data
        private NetworkStream stream;
        //thread from wich we are sending and recieving data
        private Task task;
        //lock for keeping shit organized
        private SemaphoreSlim semalock;
        //are we still running this connection
        private bool isRunning;

        public Connection(MessageService messageService)
        {
            //message service
            this.messageService = messageService;
            //init lock with only one thread access
            semalock = new SemaphoreSlim(1, 1);
            //set is running to true
            isRunning = true;
            //create task 
            task = new Task(()=>Loop());
            //run task
            task.Start();
        }
        
        //try connecting
        public async Task TryConnect(IPAddress ip, int port)
        {
            //lock that shit
            await semalock.WaitAsync();

            //temp cient object
            TcpClient client = null;

            try
            {
                //check if we already have a client
                if (this.client != null)
                    throw new Exception("Already connected!");

                //create client 
                client = new TcpClient(ip.ToString(), port);
                //config client
                client.ReceiveTimeout = 1000;
                client.SendTimeout = 1000;
            }
            catch(Exception e)
            {
                client.Close();
                Console.WriteLine(e.StackTrace);
                throw e;
            }
            finally
            {
                this.client = client;
                stream = client.GetStream();
                semalock.Release();
            }
        }

        //the loop where we check for incoming or outgoing messages
        private async Task Loop()
        {
            try
            {
                //while running check messages
                while (await IsRunning())
                {
                    //lock that shit
                    await semalock.WaitAsync();

                    //if we are connected
                    if (client != null)
                    {
                        CheckIncomingMessages();
                        messageService.SendMessages();
                    }

                    //release
                    semalock.Release();

                    //wait a millisecond
                    await Task.Delay(1);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("shit");
            }

            //if we stopped running
            stream.Close();
            client.Close();
        }

        private void CheckIncomingMessages()
        {
            NetworkStream nws = client.GetStream();
            //check if we have incoming messages
            if (client.GetStream().DataAvailable)
            {
                
                messageService.ReadMessage(client.GetStream());
            }
        }

        internal void SendMessage(Message message)
        {
            byte[] data = message.ConvertToByteArray();
            client.GetStream().Write(data, 0, data.Length);
        }

        private async Task<bool> IsRunning()
        {
            //bool that needs to be returned
            bool currentValue;
            //we want it uptodate so if its locked its being changed 
            await semalock.WaitAsync();
            //get the current value
            currentValue = isRunning;
            //release the lock
            semalock.Release();
            //return the value
            return currentValue;
        }

        public async Task StopRunning()
        {
            //lock that shit up
            await semalock.WaitAsync();
            //set isrunning to false
            isRunning = false;
            //unlock that shit
            semalock.Release();            
        }

    }
}
