using NetworkTest.ShittyNetCode.Messages;
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
    public partial class frm_Sensors : Form
    {
        
        public cnt_Sensors controller;
        private int ultrasoon;
        private bool lf_Left, lf_Mid, lf_Right;
        private int motorLeft, motorRight;

        public frm_Sensors()
        {
            InitializeComponent();


        }

        private void Frm_Sensors_Load(object sender, EventArgs e)
        {
            controller = new cnt_Sensors(this);
            Console.WriteLine("sensors loaded!");
        }
        
        private void Pbx_rendersurface_Resize(object sender, EventArgs e)
        {

        }

        private void Frm_Sensors_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public void SetData(Msg_In_SensorData msg)
        {
            ultrasoon = msg.Distance;
            if (ultrasoon > 5000)
                ultrasoon = 5000;
            else if (ultrasoon < 0)
                ultrasoon = 0;
            pb_ultrasoon.Value =  ultrasoon;
            lf_Left = msg.LineLeft;
            pbx_lf_L.BackColor = lf_Left ? Color.Green : Color.Red;
            lf_Mid = msg.LineMid;
            pbx_lf_m.BackColor = lf_Mid ? Color.Green : Color.Red;
            lf_Right = msg.LineRight;
            pbx_lf_r.BackColor = lf_Right ? Color.Green : Color.Red;
            motorLeft = msg.MotorLeft;
            pb_motor_L.Value = motorLeft;
            motorRight = msg.MotorRight;
            pb_motor_R.Value = motorRight;
        }
    }
}
