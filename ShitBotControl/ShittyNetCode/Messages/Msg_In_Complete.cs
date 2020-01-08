using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTest.ShittyNetCode.Messages
{
    public class Msg_In_Complete : MessagesIn
    {
        public Msg_In_Complete()
        {
            MessageType = MessageTypes.COMPLETE;
        }

      

    }
}
