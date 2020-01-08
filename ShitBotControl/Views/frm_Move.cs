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
    public partial class frm_Move : Form
    {
        private cnt_Move controller;

        public frm_Move()
        {
            InitializeComponent();
        }

        private void Btn_Rotate_Click(object sender, EventArgs e)
        {
            controller.Rotate();
        }

        private void Btn_infiniteEight_Click(object sender, EventArgs e)
        {
            controller.InfinitEight();
        }

        private void Btn_right_Click(object sender, EventArgs e)
        {
            controller.MoveRight();
        }

        private void Btn_left_Click(object sender, EventArgs e)
        {
            controller.MoveLeft();
        }

        private void Btn_forward_Click(object sender, EventArgs e)
        {
            controller.MoveForward();
        }

        private void Frm_Move_Load(object sender, EventArgs e)
        {
            controller = new cnt_Move(this);
        }
    }
}
