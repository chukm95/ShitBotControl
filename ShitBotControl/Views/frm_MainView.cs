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
        private frm_Move frm_Move;
        private frm_Route frm_Map;

        public frm_MainView()
        {
            InitializeComponent();

            //initialize subview
            frm_Sensors = new frm_Sensors();
            frm_Sensors.Owner = this;
            frm_Sensors.TopLevel = false;
            frm_Sensors.Dock = DockStyle.Fill;

            frm_Move = new frm_Move();
            frm_Move.Owner = this;
            frm_Move.TopLevel = false;
            frm_Move.Dock = DockStyle.Fill;

            frm_Map = new frm_Route();
            frm_Map.Owner = this;
            frm_Map.TopLevel = false;
            frm_Map.Dock = DockStyle.Fill;

            //add them to their pages
            tp_sensors.Controls.Add(frm_Sensors);
            frm_Sensors.Show();

            tp_move.Controls.Add(frm_Move);
            frm_Move.Show();

            tp_map.Controls.Add(frm_Map);
            frm_Map.Show();
        }

        private void Tc_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("index " + tc_main.SelectedTab.Name);
            switch (tc_main.SelectedTab.Name.ToString())
            {
                case "tp_sensors":
                    frm_Move?.controller?.Stop();
                    frm_Map?.controller?.Stop();
                    frm_Sensors?.controller?.Start();
                    break;
                case "tp_map":
                    frm_Move?.controller?.Stop();
                    frm_Map?.controller?.Start();
                    frm_Sensors?.controller?.Stop();
                    break;
                case "tp_move":
                    frm_Move?.controller?.Start();
                    frm_Map?.controller?.Stop();
                    frm_Sensors?.controller?.Stop();
                    break;

            }
        }
    }
}
