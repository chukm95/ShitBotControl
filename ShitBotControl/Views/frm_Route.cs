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
    public partial class frm_Route : Form
    {
        public cnt_Route controller;

        public frm_Route()
        {
            InitializeComponent();
        }

        private void Frm_Route_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Frm_Route_Load(object sender, EventArgs e)
        {
            controller = new cnt_Route(this, editorScene1);
            Console.WriteLine("Map loaded");
        }

        private void EditorScene1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                controller.SetShitBot(e.X, e.Y);
            }
            else if(e.Button == MouseButtons.Right)
            {
                controller.SetEndPoint(e.X, e.Y);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Btn_drive_Click(object sender, EventArgs e)
        {
            controller.Drive();
        }
    }
}
