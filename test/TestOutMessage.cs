using NetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class TestOutMessage : Message
    {
        public long longval = 1001;
        public int intval = 1002;
        public short shortval = 1003;
        public float floatval = 1004.4f;
        public double doubleval = 1005.5;
        public string utf8val = "testmsg3!";
        public byte byteval = 58;

        public TestOutMessage() : base(1, MessageTypes.OUTGOING)
        {

        }

        protected override void FromBytes()
        {
            
        }

        protected override void ToBytes()
        {
            WriteLong(longval);
            WriteInt(intval);
            WriteShort(shortval);
            WriteFloat(floatval);
            WriteDouble(doubleval);
            WriteString(utf8val);
            WriteByte(byteval);
        }

        public void Print()
        {
            Console.WriteLine(longval);
            Console.WriteLine(intval);
            Console.WriteLine(shortval);
            Console.WriteLine(floatval);
            Console.WriteLine(doubleval);
            Console.WriteLine(utf8val);
            Console.WriteLine(byteval);
        }
    }
}
