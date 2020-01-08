using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShitBotControl.Controllers
{
    public class cnt_Route : Controller
    {

        public cnt_Route(Form form) : base(form)
        {

        }

        protected override void OnUpdate()
        {
        }

        protected override void OnTimeout()
        {
            Console.WriteLine("timeout");
            form.Owner.Owner.Show();
            Stop();
            form.Owner.Hide();
        }

    }
}
