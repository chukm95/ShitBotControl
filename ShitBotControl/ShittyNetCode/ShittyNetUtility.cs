using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTest.ShittyNetCode
{
    class ShittyNetUtility
    {
        public static void WriteLong(long value, NetworkStream stream)
        {
            //convert the long to bytes and put each byte in the bytearray
            foreach (byte b in BitConverter.GetBytes(value).Reverse())
            {
                stream.WriteByte(b);
            }
        }

        //writes int to our byte buffer
        public static void WriteInt(int value, NetworkStream stream)
        {
            //convert the int to bytes and put each byte in the bytearray
            foreach (byte b in BitConverter.GetBytes(value).Reverse())
            {
                stream.WriteByte(b);
            }
        }

        //writes short to our byte buffer
        public static void WriteShort(short value, NetworkStream stream)
        {
            //convert the short to bytes and put each byte in the bytearray
            foreach (byte b in BitConverter.GetBytes(value).Reverse())
            {
                stream.WriteByte(b);
            }
        }

        //writes float to our byte buffer
        public static void WriteFloat(float value, NetworkStream stream)
        {
            //convert the float to bytes and put each byte in the bytearray
            foreach (byte b in BitConverter.GetBytes(value).Reverse())
            {
                stream.WriteByte(b);
            }
        }

        //writes double to our byte buffer
        public static void WriteDouble(double value, NetworkStream stream)
        {
            //convert the double to bytes and put each byte in the bytearray
            foreach (byte b in BitConverter.GetBytes(value).Reverse())
            {
                stream.WriteByte(b);
            }
        }

        //writes string to our byte buffer
        public static void WriteString(string value, NetworkStream stream)
        {
            //convert our string to byte array
            byte[] data = System.Text.Encoding.UTF8.GetBytes(value);

            //convert ourt string size to bytes
            foreach (byte b in BitConverter.GetBytes(data.Length).Reverse())
            {
                stream.WriteByte(b);
            }

            //convert the string to bytes and put each byte in the bytearray
            foreach (byte b in data)
            {
                stream.WriteByte(b);
            }
        }

        //write byte to our byte buffer
        public static void WriteByte(byte value, NetworkStream stream)
        {
            stream.WriteByte(value);
        }

        //write boolean
        public static void WriteBool(bool value, NetworkStream stream)
        {
            byte data = value ? (byte)1 : (byte)0;
            stream.WriteByte(data);
        }

        //read long from socket
        public static long ReadLong(NetworkStream stream)
        {
            byte[] buffer = new byte[sizeof(long)];
            int size = stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToInt64(buffer.Reverse().ToArray(), 0);
        }

        //read integer from socket
        public static int ReadInt(NetworkStream stream)
        {
            byte[] buffer = new byte[sizeof(int)];
            int size = stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToInt32(buffer.Reverse().ToArray(), 0);
        }


        //read short from socket
        public static short ReadShort(NetworkStream stream)
        {
            byte[] buffer = new byte[sizeof(short)];
            int size = stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToInt16(buffer.Reverse().ToArray(), 0);
        }

        //read float from socket
        public static float ReadFloat(NetworkStream stream)
        {
            byte[] buffer = new byte[sizeof(float)];
            int size = stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToSingle(buffer.Reverse().ToArray(), 0);
        }

        //read double from socket
        public static double ReadDouble(NetworkStream stream)
        {
            byte[] buffer = new byte[sizeof(double)];
            int size = stream.Read(buffer, 0, buffer.Length);
            return BitConverter.ToDouble(buffer.Reverse().ToArray(), 0);
        }

        //read utf string from socket
        public static string ReadUtf(NetworkStream stream)
        {
            int size = ReadInt(stream);
            byte[] buffer = new byte[size];
            int i = stream.Read(buffer, 0, buffer.Length);
            return System.Text.Encoding.UTF8.GetString(buffer);
        }

        //read byte from socket
        public static byte ReadByte(NetworkStream stream)
        {
            byte[] buffer = new byte[1];
            stream.Read(buffer, 0, 1);
            return buffer[0];
        }

        public static bool ReadBool(NetworkStream stream)
        {
            byte[] buffer = new byte[sizeof(bool)];
            stream.Read(buffer, 0, 1);
            return BitConverter.ToBoolean(buffer.Reverse().ToArray(), 0);
        }
    }
}
