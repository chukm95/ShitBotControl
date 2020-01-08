using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTest.ShittyNetCode.Messages
{
    public class Msg_In_Timeout : MessagesIn
    {
        public Msg_In_Timeout()
        {
            MessageType = MessageTypes.TIMEOUT;
        }
    }
}
