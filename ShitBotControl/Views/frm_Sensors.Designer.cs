namespace ShitBotControl.Views
{
    partial class frm_Sensors
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbx_rendersurface = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_rendersurface)).BeginInit();
            this.SuspendLayout();
            // 
            // pbx_rendersurface
            // 
            this.pbx_rendersurface.BackColor = System.Drawing.SystemColors.Window;
            this.pbx_rendersurface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbx_rendersurface.Location = new System.Drawing.Point(0, 0);
            this.pbx_rendersurface.Name = "pbx_rendersurface";
            this.pbx_rendersurface.Size = new System.Drawing.Size(800, 450);
            this.pbx_rendersurface.TabIndex = 0;
            this.pbx_rendersurface.TabStop = false;
            this.pbx_rendersurface.Resize += new System.EventHandler(this.Pbx_rendersurface_Resize);
            // 
            // frm_Sensors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbx_rendersurface);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Sensors";
            this.Text = "frm_Sensors";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Sensors_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_rendersurface)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbx_rendersurface;
    }
}