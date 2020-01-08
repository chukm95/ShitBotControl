using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTest.ShittyNetCode.Messages
{
    public abstract class MessagesIn
    {
        public enum MessageTypes
        {
            SENSORDATA,
            TIMEOUT,
            COMPLETE
        }

        public MessageTypes MessageType
        {
            get;
            protected set;
        }

        public virtual void ReadMessage(NetworkStream stream)
        {

        }
    }
}
