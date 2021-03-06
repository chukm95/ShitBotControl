﻿using NetCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class TestMessage : Message
    {
        public long longval;
        public int intval;
        public short shortval;
        public float floatval;
        public double doubleval;
        public string utf8val;
        public byte byteval;

        public TestMessage() : base(0, MessageTypes.INCOMING)
        {

        }

        protected override void FromBytes()
        {
            longval = ReadLong();
            intval = ReadInt();
            shortval = ReadShort();
            floatval = ReadFloat();
            doubleval = ReadDouble();
            utf8val = ReadUtf();
            byteval = ReadByte();
        }

        protected override void ToBytes()
        {
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
