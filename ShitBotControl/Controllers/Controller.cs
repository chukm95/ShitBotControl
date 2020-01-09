using NetworkTest.ShittyNetCode;
using NetworkTest.ShittyNetCode.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShitBotControl.Controllers
{
    public abstract class Controller
    {
        protected readonly ShittyNetClient shittyNetClient;
        protected readonly Form form;
        private Timer timer;

        public Controller(Form form)
        {
            shittyNetClient = ShittyNetClient.GetInstance();
            this.form = form;
            timer = new Timer();
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Start();
            Initialize();
        }

        private void Initialize()
        {

        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            //updaten onze controller
            OnUpdate();
            shittyNetClient.Update();
            foreach(MessagesIn msg in shittyNetClient.GetMessages())
            {
                switch (msg.MessageType)
                {
                    case MessagesIn.MessageTypes.TIMEOUT:
                        OnTimeout();
                        break;
                    case MessagesIn.MessageTypes.SENSORDATA:
                        OnSensorData((Msg_In_SensorData)msg);
                        break;
                    case MessagesIn.MessageTypes.COMPLETE:
                        OnComplete();
                        break;
                }
            }
        }

        protected virtual void OnUpdate()
        {

        }

        protected virtual void OnTimeout()
        {

        }

        protected virtual void OnSensorData(Msg_In_SensorData msg_In_SensorData)
        {

        }

        protected virtual void OnComplete()
        {

        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

    }
}
