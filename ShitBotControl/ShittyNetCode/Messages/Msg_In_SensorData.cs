using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTest.ShittyNetCode.Messages
{
    public class Msg_In_SensorData : MessagesIn
    {
        public int Distance
        {
            get;
            private set;
        }

        public bool LineLeft
        {
            get;
            private set;
        }

        public bool LineMid
        {
            get;
            private set;
        }

        public bool LineRight
        {
            get;
            private set;
        }
        public int MotorLeft
        {
            get;
            private set;
        }

        public int MotorRight
        {
            get;
            private set;
        }


        public Msg_In_SensorData()
        {
            MessageType = MessageTypes.SENSORDATA;
        }

        public override void ReadMessage(NetworkStream stream)
        {
            Distance = ShittyNetUtility.ReadInt(stream);
            LineLeft = ShittyNetUtility.ReadBool(stream);
            LineMid = ShittyNetUtility.ReadBool(stream);
            LineRight = ShittyNetUtility.ReadBool(stream);
            MotorLeft = ShittyNetUtility.ReadInt(stream);
            MotorRight = ShittyNetUtility.ReadInt(stream);
        }

        public void Print()
        {
            Console.WriteLine(string.Format("Ultrasoon: {0},\nLeftLine: {1},\nMidLine: {2},\nRightLine: {3},\nMotorLeft: {4},\nMotorRight: {5}\n", Distance, LineLeft, LineMid, LineRight, MotorLeft, MotorRight));
        }

    }
}
