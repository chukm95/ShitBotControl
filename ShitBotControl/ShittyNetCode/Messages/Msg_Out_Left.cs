using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTest.ShittyNetCode.Messages
{
    public class Msg_Out_Left : MessagesOut
    {
        public Msg_Out_Left() : base(3)
        {

        }
    }
}
