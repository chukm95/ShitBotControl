using ShitBotControl.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShitBotControl.Controllers
{
    class cnt_Connecting : Controller
    {

        public cnt_Connecting(Form form) : base(form)
        {

        }

        public void Connect(string ip)
        {
            if(shittyNetClient.TryConnect(ip, 12345))
            {
                frm_MainView frm = new frm_MainView();
                frm.Owner = form;
                frm.Show();
                form.Hide();
                Stop();              
            }
            else
            {
                MessageBox.Show("Failed to setup connection!");
            }
        }

    }
}
