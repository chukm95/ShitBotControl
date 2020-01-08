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
    public partial class frm_Route : Form
    {
        private SolidBrush brush;        
        private Timer timer;

        public frm_Route()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = (int)(1000.0 / 30.0);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }


        private void Frm_Route_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }

        private void Frm_Route_Load(object sender, EventArgs e)
        {
            brush = new SolidBrush(Color.Red);
            timer.Start();
        }

        private void Frm_Route_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
        }
    }
}
