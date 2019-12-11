using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetCode
{
    public abstract class Message
    {
        //message type incoming or outgoing
        public enum MessageTypes
        {
            INCOMING,
            OUTGOING
        }

        //getter setter property for message id
        //short has only 65536 unique id's if this
        //is to few you are doing something wrong 
        public short ID
        {
            get;
            private set;
        }

        //getter setter property to indicate wether it is outgoing or incoming
        public MessageTypes MessageType
        {
            get;
            private set;
        }

        //we cache the message data if it isnt changed, yes yes wasting memory but honestly messages arent 
        //that big and are frequently deleted by our god the one and only GC
        private byte[] data;
        //bool to keep track if data changed... oh no 8 more bits wasted in memory a whole byte osheeejz
        private bool hasChanged;
        //premature optimalization is a bitch

        //the temporary client holder trough wich we read our messages
        private NetworkStream stream;
        //the temporary byte array
        private List<byte> byteArray;

        //constructor set the message id and message type of parent class
        protected Message(short id, MessageTypes type)
        {
            ID = id;
            MessageType = type;
        }

        //gives a streamable byte array
        public byte[] ConvertToByteArray()
        {
            //if our data changed
            if (hasChanged)
            {
                //create temporary byte list
                byteArray = new List<byte>();
                //redefine our data
                ToBytes();
                //save our data
                data = byteArray.ToArray();
                //now its uptodate
                hasChanged = false;
                //clear list
                byteArray = null;
            }
            //then return our data
            return data;
        }

        //implementation for turning message in sendable bytes
        protected abstract void ToBytes();

        //writes long to our byte buffer
        protected void WriteLong(long value)
        {
            //convert the long to bytes and put each byte in the bytearray
            foreach (byte b in BitConverter.GetBytes(value))
            {
                byteArray.Add(b);
            }
        }

        //writes int to our byte buffer
        protected void WriteInt(int value)
        {
            //convert the int to bytes and put each byte in the bytearray
            foreach (byte b in BitConverter.GetBytes(value))
            {
                byteArray.Add(b);
            }
        }

        //writes short to our byte buffer
        protected void WriteShort(short value)
        {
            //convert the short to bytes and put each byte in the bytearray
            foreach (byte b in BitConverter.GetBytes(value))
            {
                byteArray.Add(b);
            }
        }

        //writes float to our byte buffer
        protected void WriteFloat(float value)
        {
            //convert the float to bytes and put each byte in the bytearray
            foreach (byte b in BitConverter.GetBytes(value))
            {
                byteArray.Add(b);
            }
        }

        //writes double to our byte buffer
        protected void WriteDouble(double value)
        {
            //convert the double to bytes and put each byte in the bytearray
            foreach (byte b in BitConverter.GetBytes(value))
            {
                byteArray.Add(b);
            }
        }

        //writes string to our byte buffer
        protected void WriteString(string value)
        {
            //convert our string to byte array
            byte[] data = System.Text.Encoding.UTF8.GetBytes(value);

            //convert ourt string size to bytes
            foreach(byte b in BitConverter.GetBytes(data.Length))
            {
                byteArray.Add(b);
            }

            //convert the string to bytes and put each byte in the bytearray
            foreach (byte b in data)
            {
                byteArray.Add(b);
            }
        }

        //write byte to our byte buffer
        protected void WriteByte(byte value)
        {
            byteArray.Add(value);
        }

        //we can only start reading the message internal this keeps access to the stream from client
        internal void ReadMessage(NetworkStream stream)
        {
            //save the socket temporarly
            this.stream = stream;

            //read the message the way it was intended by our client
            FromBytes();

            //set stream to null
            this.stream = null;
        }

        //read the message trough the socket
        protected abstract void FromBytes();
        
        //read long from socket
        protected long ReadLong()
        {
            byte[] buffer = new byte[sizeof(long)];
            int size = stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToInt64(buffer.Reverse().ToArray(), 0);
        }

        //read integer from socket
        protected int ReadInt()
        {
            byte[] buffer = new byte[sizeof(int)];
            int size = stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToInt32(buffer.Reverse().ToArray(), 0);
        }


        //read short from socket
        protected short ReadShort()
        {
            byte[] buffer = new byte[sizeof(short)];
            int size = stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToInt16(buffer.Reverse().ToArray(), 0);
        }

        //read float from socket
        protected float ReadFloat()
        {
            byte[] buffer = new byte[sizeof(float)];
            int size = stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToSingle(buffer.Reverse().ToArray(), 0);
        }

        //read double from socket
        protected double ReadDouble()
        {
            byte[] buffer = new byte[sizeof(double)];
            int size = stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToDouble(buffer.Reverse().ToArray(), 0);
        }

        //read utf string from socket
        protected string ReadUtf()
        {
            int size = ReadInt();
            byte[] buffer = new byte[size];
            int i = stream.Read(buffer, 0, buffer.Length);
            return System.Text.Encoding.UTF8.GetString(buffer);
        }

        //read byte from socket
        protected byte ReadByte()
        {
            byte[] buffer = new byte[1];
            stream.Read(buffer, 0, 1);
            return buffer[0];
        }

        //with this methode the client app can indicate our data has changed
        protected void FlagDataChanged()
        {
            hasChanged = true;
        }
    }
}
