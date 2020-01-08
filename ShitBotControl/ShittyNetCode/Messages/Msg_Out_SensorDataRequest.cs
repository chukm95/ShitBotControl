using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTest.ShittyNetCode.Messages
{
    public class Msg_Out_SensorDataRequest : MessagesOut
    {
        public Msg_Out_SensorDataRequest() : base(1)
        {

        }
    }
}
