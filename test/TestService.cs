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
        protected override void OnPoll(Message m)
        {
            throw new NotImplementedException();
        }

        protected override Message SortMessage(short id)
        {
            switch (id)
            {
                case 200:
                    return new TestMessage();
                default:
                    return null;
            }
        }
    }
}
