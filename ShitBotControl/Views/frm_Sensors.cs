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
        //the rendersurface 
        private Bitmap rendersurface;
        //graphics for the rendersurface
        private Graphics graphics;
        //solid brush to paint shapes
        private SolidBrush solidBrush;
        //pen for shapes
        private Pen pen;
        //font for strings
        private Font font;
        //the timer for rendering
        private Timer timer;


        private const float UltrasoonPerscentage = 692f / 10000f;
        private float ultrasoon = 5000;

        private bool lf_Left = false, lf_Middle = false, lf_Right = false;

        private Random rand;

        public frm_Sensors()
        {
            InitializeComponent();

            //initialize rendersurface
            rendersurface = new Bitmap(1280, 720);
            //init graphics
            graphics = Graphics.FromImage(rendersurface);
            //init solid brush
            solidBrush = new SolidBrush(Color.Black);
            //init pen
            pen = new Pen(solidBrush, 3);
            //init font
            font = new Font("verdana", 16, FontStyle.Bold);


            rand = new Random();

            //setupt the timer
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += Render;
            timer.Start();

        }

        private void Render(object sender, EventArgs e)
        {
            //clear the rendersurface
            graphics.Clear(Color.White);

            ultrasoon += (float)(rand.NextDouble() * 300) - 150f;
           // ultrasoon = Math.Min(0f, Math.Max(10000f, ultrasoon));

            //draw ultrasoon
            solidBrush.Color = Color.Black;
            graphics.DrawString("Ultrasoon: ", font, solidBrush, 20, 20);
            graphics.FillRectangle(solidBrush, new Rectangle(20, 45, 700, 40));
            pen.Color = Color.Red;
            graphics.DrawRectangle(pen, new Rectangle(20, 45, 700, 40));
            solidBrush.Color = Color.Red;
            graphics.FillRectangle(solidBrush, new Rectangle(24, 49, (int)(ultrasoon * UltrasoonPerscentage), 32));
            solidBrush.Color = Color.White;
            graphics.DrawString(String.Format("{0}", (int)ultrasoon), font, solidBrush, 320, 50);

            //linefollowers
            solidBrush.Color = Color.Black;
            graphics.DrawString("Linefollowers: ", font, solidBrush, 20, 115);
            graphics.FillRectangle(solidBrush, new Rectangle(20, 140, 40, 40));
            graphics.FillRectangle(solidBrush, new Rectangle(80, 140, 40, 40));
            graphics.FillRectangle(solidBrush, new Rectangle(140, 140, 40, 40));

            pen.Color = Color.Red;
            graphics.DrawRectangle(pen, new Rectangle(20, 140, 40, 40));
            graphics.DrawRectangle(pen, new Rectangle(80, 140, 40, 40));
            graphics.DrawRectangle(pen, new Rectangle(140, 140, 40, 40));

            solidBrush.Color = Color.Red;
            if(lf_Left)
                graphics.FillRectangle(solidBrush, new Rectangle(24, 140, 32, 32));

            if(lf_Middle)
                graphics.FillRectangle(solidBrush, new Rectangle(84, 140, 32, 32));

            if(lf_Right)
                graphics.FillRectangle(solidBrush, new Rectangle(144, 140, 32, 32));

            solidBrush.Color = Color.White;
            graphics.DrawString("L", font, solidBrush, 26, 146);
            graphics.DrawString("M", font, solidBrush, 86, 146);
            graphics.DrawString("R", font, solidBrush, 146, 146);

            //set the picturebox image to rendersurface
            pbx_rendersurface.Image = rendersurface;
        }

        private void Pbx_rendersurface_Resize(object sender, EventArgs e)
        {

        }

        private void Frm_Sensors_FormClosing(object sender, FormClosingEventArgs e)
        {
            graphics.Dispose();
        }
    }
}
