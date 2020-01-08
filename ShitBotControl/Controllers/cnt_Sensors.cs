using NetworkTest.ShittyNetCode.Messages;
using ShitBotControl.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShitBotControl.Controllers
{
    public class cnt_Sensors : Controller
    {
        int index = 0;
        public cnt_Sensors(Form form) : base(form)
        {

        }

        protected override void OnUpdate()
        {
            if (index > 10)
            {
                shittyNetClient.SendMessage(new Msg_Out_SensorDataRequest());
                index = 0;
            }
            index++;
        }

        protected override void OnTimeout()
        {
            Console.WriteLine("timeout");
            form.Owner.Owner.Show();
            Stop();
            form.Owner.Hide();
        }

        protected override void OnSensorData(Msg_In_SensorData msg_In_SensorData)
        {
            ((frm_Sensors)form).SetData(msg_In_SensorData);
        }

    }
}
