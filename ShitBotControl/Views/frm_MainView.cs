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
    public partial class frm_MainView : Form
    {
        //all sub forms that are displayed in the page
        private frm_Sensors frm_Sensors;

        public frm_MainView()
        {
            InitializeComponent();

            //initialize subview
            frm_Sensors = new frm_Sensors();
            frm_Sensors.TopLevel = false;
            frm_Sensors.Dock = DockStyle.Fill;

            //add them to their pages
            tp_sensors.Controls.Add(frm_Sensors);
            frm_Sensors.Show();
        }
    }
}
