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
            this.pb_ultrasoon = new System.Windows.Forms.ProgressBar();
            this.pb_motor_R = new System.Windows.Forms.ProgressBar();
            this.pb_motor_L = new System.Windows.Forms.ProgressBar();
            this.pbx_lf_m = new System.Windows.Forms.PictureBox();
            this.pbx_lf_r = new System.Windows.Forms.PictureBox();
            this.pbx_lf_L = new System.Windows.Forms.PictureBox();
            this.lbl_distance = new System.Windows.Forms.Label();
            this.lbl_motor_R = new System.Windows.Forms.Label();
            this.lbl_motor_L = new System.Windows.Forms.Label();
            this.lbl_lf_L = new System.Windows.Forms.Label();
            this.lbl_lf_M = new System.Windows.Forms.Label();
            this.lbl_lf_R = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_lf_m)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_lf_r)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_lf_L)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_ultrasoon
            // 
            this.pb_ultrasoon.Location = new System.Drawing.Point(15, 25);
            this.pb_ultrasoon.Maximum = 5000;
            this.pb_ultrasoon.Name = "pb_ultrasoon";
            this.pb_ultrasoon.Size = new System.Drawing.Size(179, 23);
            this.pb_ultrasoon.TabIndex = 0;
            // 
            // pb_motor_R
            // 
            this.pb_motor_R.Location = new System.Drawing.Point(15, 67);
            this.pb_motor_R.Maximum = 200;
            this.pb_motor_R.Name = "pb_motor_R";
            this.pb_motor_R.Size = new System.Drawing.Size(179, 23);
            this.pb_motor_R.TabIndex = 1;
            // 
            // pb_motor_L
            // 
            this.pb_motor_L.Location = new System.Drawing.Point(15, 109);
            this.pb_motor_L.Maximum = 200;
            this.pb_motor_L.Name = "pb_motor_L";
            this.pb_motor_L.Size = new System.Drawing.Size(179, 23);
            this.pb_motor_L.TabIndex = 2;
            // 
            // pbx_lf_m
            // 
            this.pbx_lf_m.BackColor = System.Drawing.Color.Red;
            this.pbx_lf_m.Location = new System.Drawing.Point(15, 192);
            this.pbx_lf_m.Name = "pbx_lf_m";
            this.pbx_lf_m.Size = new System.Drawing.Size(23, 22);
            this.pbx_lf_m.TabIndex = 4;
            this.pbx_lf_m.TabStop = false;
            // 
            // pbx_lf_r
            // 
            this.pbx_lf_r.BackColor = System.Drawing.Color.Red;
            this.pbx_lf_r.Location = new System.Drawing.Point(15, 233);
            this.pbx_lf_r.Name = "pbx_lf_r";
            this.pbx_lf_r.Size = new System.Drawing.Size(23, 22);
            this.pbx_lf_r.TabIndex = 5;
            this.pbx_lf_r.TabStop = false;
            // 
            // pbx_lf_L
            // 
            this.pbx_lf_L.BackColor = System.Drawing.Color.Red;
            this.pbx_lf_L.Location = new System.Drawing.Point(15, 151);
            this.pbx_lf_L.Name = "pbx_lf_L";
            this.pbx_lf_L.Size = new System.Drawing.Size(23, 22);
            this.pbx_lf_L.TabIndex = 6;
            this.pbx_lf_L.TabStop = false;
            // 
            // lbl_distance
            // 
            this.lbl_distance.AutoSize = true;
            this.lbl_distance.Location = new System.Drawing.Point(12, 9);
            this.lbl_distance.Name = "lbl_distance";
            this.lbl_distance.Size = new System.Drawing.Size(58, 13);
            this.lbl_distance.TabIndex = 7;
            this.lbl_distance.Text = "Ultrasoon :";
            // 
            // lbl_motor_R
            // 
            this.lbl_motor_R.AutoSize = true;
            this.lbl_motor_R.Location = new System.Drawing.Point(12, 51);
            this.lbl_motor_R.Name = "lbl_motor_R";
            this.lbl_motor_R.Size = new System.Drawing.Size(67, 13);
            this.lbl_motor_R.TabIndex = 8;
            this.lbl_motor_R.Text = "Right motor :";
            // 
            // lbl_motor_L
            // 
            this.lbl_motor_L.AutoSize = true;
            this.lbl_motor_L.Location = new System.Drawing.Point(12, 93);
            this.lbl_motor_L.Name = "lbl_motor_L";
            this.lbl_motor_L.Size = new System.Drawing.Size(60, 13);
            this.lbl_motor_L.TabIndex = 9;
            this.lbl_motor_L.Text = "Left motor :";
            // 
            // lbl_lf_L
            // 
            this.lbl_lf_L.AutoSize = true;
            this.lbl_lf_L.Location = new System.Drawing.Point(12, 135);
            this.lbl_lf_L.Name = "lbl_lf_L";
            this.lbl_lf_L.Size = new System.Drawing.Size(80, 13);
            this.lbl_lf_L.TabIndex = 10;
            this.lbl_lf_L.Text = "leftLineFollower";
            // 
            // lbl_lf_M
            // 
            this.lbl_lf_M.AutoSize = true;
            this.lbl_lf_M.Location = new System.Drawing.Point(12, 176);
            this.lbl_lf_M.Name = "lbl_lf_M";
            this.lbl_lf_M.Size = new System.Drawing.Size(96, 13);
            this.lbl_lf_M.TabIndex = 11;
            this.lbl_lf_M.Text = "middleLineFollower";
            // 
            // lbl_lf_R
            // 
            this.lbl_lf_R.AutoSize = true;
            this.lbl_lf_R.Location = new System.Drawing.Point(12, 217);
            this.lbl_lf_R.Name = "lbl_lf_R";
            this.lbl_lf_R.Size = new System.Drawing.Size(86, 13);
            this.lbl_lf_R.TabIndex = 12;
            this.lbl_lf_R.Text = "rightLineFollower";
            // 
            // frm_Sensors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_lf_R);
            this.Controls.Add(this.lbl_lf_M);
            this.Controls.Add(this.lbl_lf_L);
            this.Controls.Add(this.lbl_motor_L);
            this.Controls.Add(this.lbl_motor_R);
            this.Controls.Add(this.lbl_distance);
            this.Controls.Add(this.pbx_lf_L);
            this.Controls.Add(this.pbx_lf_r);
            this.Controls.Add(this.pbx_lf_m);
            this.Controls.Add(this.pb_motor_L);
            this.Controls.Add(this.pb_motor_R);
            this.Controls.Add(this.pb_ultrasoon);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Sensors";
            this.Text = "frm_Sensors";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Sensors_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Sensors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbx_lf_m)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_lf_r)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_lf_L)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pb_ultrasoon;
        private System.Windows.Forms.ProgressBar pb_motor_R;
        private System.Windows.Forms.ProgressBar pb_motor_L;
        private System.Windows.Forms.PictureBox pbx_lf_m;
        private System.Windows.Forms.PictureBox pbx_lf_r;
        private System.Windows.Forms.PictureBox pbx_lf_L;
        private System.Windows.Forms.Label lbl_distance;
        private System.Windows.Forms.Label lbl_motor_R;
        private System.Windows.Forms.Label lbl_motor_L;
        private System.Windows.Forms.Label lbl_lf_L;
        private System.Windows.Forms.Label lbl_lf_M;
        private System.Windows.Forms.Label lbl_lf_R;
    }
}