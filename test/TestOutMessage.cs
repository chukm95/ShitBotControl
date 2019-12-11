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
        public long longval;
        public int intval;
        public short shortval;
        public float floatval;
        public double doubleval;
        public string utf8val;
        public byte byteval;

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
