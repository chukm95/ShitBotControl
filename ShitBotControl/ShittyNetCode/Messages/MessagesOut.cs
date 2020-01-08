using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTest.ShittyNetCode.Messages
{
    public abstract class MessagesOut
    {
        private short id;

        protected MessagesOut(short id)
        {
            this.id = id;
        }

        public void SendMessage(NetworkStream stream)
        {
            ShittyNetUtility.WriteShort(id, stream);
            OnSendMessage(stream);
        }

        protected virtual void OnSendMessage(NetworkStream stream)
        {

        }
    }
}
