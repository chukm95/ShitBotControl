using NetworkTest.ShittyNetCode.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShitBotControl.Controllers
{
    public class cnt_Move : Controller
    {
        private bool isComplete;

        public cnt_Move(Form form) : base(form)
        {
            isComplete = true;
        }

        protected override void OnUpdate()
        {
            shittyNetClient.SendMessage(new Msg_Out_SensorDataRequest());
        }

        protected override void OnTimeout()
        {
            Console.WriteLine("timeout");
            form.Owner.Owner.Show();
            Stop();
            form.Owner.Hide();
        }

        protected override void OnComplete()
        {
            isComplete = true;
        }

        public void MoveForward()
        {
            if (isComplete)
                shittyNetClient.SendMessage(new Msg_Out_Forward());
        }

        public void MoveLeft()
        {
            if (isComplete)
                shittyNetClient.SendMessage(new Msg_Out_Left());
        }

        public void MoveRight()
        {
            if (isComplete)
                shittyNetClient.SendMessage(new Msg_Out_Right());
        }

        public void InfinitEight()
        {
            if (isComplete)
                shittyNetClient.SendMessage(new Msg_Out_Infinite_Eight());
        }

        public void Rotate()
        {
            if (isComplete)
                shittyNetClient.SendMessage(new Msg_Out_Rotate());
        }
    }
}
