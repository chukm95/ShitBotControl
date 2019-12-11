using NetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class TestService : MessageService
    {
        protected override Message SortMessage(short id)
        {
            switch (id)
            {
                case 0:
                    return new TestMessage();
                case 1000:  //ping

                    return null;
                default:
                    return null;
            }
        }

        protected override void OnPoll(Message m)
        {
            switch (m.ID)
            {
                case 0: // is een testmessage
                    ((TestMessage)m).Print();
                    break;
            }
        }

    }
}
