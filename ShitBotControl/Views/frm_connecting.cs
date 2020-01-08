using ShitBotControl.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShitBotControl.Views
{
    public partial class frm_Connecting : Form
    {
        private cnt_Connecting connectingController;

        public frm_Connecting()
        {
            InitializeComponent();
        }

        private void frm_Connecting_Load(object sender, EventArgs e)
        {
            connectingController = new cnt_Connecting(this);
            tbx_ipaddress.Text = "145.48.230.197";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            connectingController.Connect(tbx_ipaddress.Text);
        }

    }
}
