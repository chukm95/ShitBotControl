using NetworkTest.ShittyNetCode.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTest.ShittyNetCode
{
    public class ShittyNetClient
    {

        //singleton
        private static ShittyNetClient instance;

        //then singleton getter
        public static ShittyNetClient GetInstance()
        {
            //check if instance is null
            if (instance == null)
                //yes, create a new instance
                instance = new ShittyNetClient();
            //return the instance
            return instance;
        }

        //tcp client
        private TcpClient client;
        //stream
        private NetworkStream stream;
        //ping time
        private int lastPingRecieved;
        //time to ping
        private int lastPingSended;
        //stopwatch
        private Stopwatch stopwatch;
        //are we connected
        public bool IsConnected
        {
            get;
            private set;
        }
        //messages in
        private List<MessagesIn> messagesIn;

        //constructor
        private ShittyNetClient()
        {
            messagesIn = new List<MessagesIn>();
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        //try connect to the server
        public bool TryConnect(string ip, int port)
        {
            //check if we are connected
            if (IsConnected)
                return false;

            //create temporary client
            TcpClient client = null;

            try
            {
                //try setting up the tcp client
                client = new TcpClient(ip, port);
                //setting timeouts
                client.ReceiveTimeout = 1000;
                client.SendTimeout = 1000;
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
            this.client = client;
            stream = client.GetStream();
            IsConnected = true;
            stopwatch.Restart();
            //we have connected
            return true;
        }


        public void Update()
        {
            if (IsConnected)
            {
                //send ping
                SendPing();
                RecieveMessages();
                CheckTimeOut();

            }
        }

        public MessagesIn[] GetMessages()
        {
            MessagesIn[] msgs = messagesIn.ToArray();
            messagesIn.Clear();
            return msgs;
        }

        private void SendPing()
        {
            lastPingSended += (int)stopwatch.ElapsedMilliseconds;
            try
            {
                if (lastPingSended > 100)
                {
                    ShittyNetUtility.WriteShort(0, stream);
                    lastPingSended = 0;
                }
            }
            catch (Exception e)
            {

            }
        }

        private void RecieveMessages()
        {
            if (stream.DataAvailable)
            {
                short msgId = ShittyNetUtility.ReadShort(stream);
                switch (msgId)
                {
                    case 0: //ping
                        lastPingRecieved = 0;
                        break;
                    case 1: //sensor data
                        Msg_In_SensorData msg = new Msg_In_SensorData();
                        msg.ReadMessage(stream);
                        messagesIn.Add(msg);
                        break;
                    case 2:
                        Console.WriteLine("completed");
                        messagesIn.Add(new Msg_In_Complete());
                        break;
                    default:
                        Console.WriteLine("unknown message!");
                        break;
                }
            }
        }

        public void SendMessage(MessagesOut msg) 
        {
            try
            {
                msg.SendMessage(stream);
            }
            catch (Exception e)
            {

            }
        }

        private void CheckTimeOut()
        {
            lastPingRecieved += (int)stopwatch.ElapsedMilliseconds;
            stopwatch.Restart();

            if(lastPingRecieved > 7000)
            {
                stream.Close();
                client.Close();
                stream.Dispose();
                client = null;
                stream = null;
                IsConnected = false;
                messagesIn.Add(new Msg_In_Timeout());
                lastPingRecieved = 0;
                lastPingSended = 0;
            }


        }
    }
}
