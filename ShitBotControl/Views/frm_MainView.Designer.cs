namespace ShitBotControl.Views
{
    partial class frm_MainView
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
            this.tc_main = new System.Windows.Forms.TabControl();
            this.tp_sensors = new System.Windows.Forms.TabPage();
            this.tp_linefollowing = new System.Windows.Forms.TabPage();
            this.tp_settings = new System.Windows.Forms.TabPage();
            this.tc_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_main
            // 
            this.tc_main.Controls.Add(this.tp_sensors);
            this.tc_main.Controls.Add(this.tp_linefollowing);
            this.tc_main.Controls.Add(this.tp_settings);
            this.tc_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_main.Location = new System.Drawing.Point(0, 0);
            this.tc_main.Name = "tc_main";
            this.tc_main.SelectedIndex = 0;
            this.tc_main.Size = new System.Drawing.Size(800, 450);
            this.tc_main.TabIndex = 0;
            // 
            // tp_sensors
            // 
            this.tp_sensors.Location = new System.Drawing.Point(4, 22);
            this.tp_sensors.Name = "tp_sensors";
            this.tp_sensors.Padding = new System.Windows.Forms.Padding(3);
            this.tp_sensors.Size = new System.Drawing.Size(792, 424);
            this.tp_sensors.TabIndex = 0;
            this.tp_sensors.Text = "Sensors";
            this.tp_sensors.UseVisualStyleBackColor = true;
            // 
            // tp_linefollowing
            // 
            this.tp_linefollowing.Location = new System.Drawing.Point(4, 22);
            this.tp_linefollowing.Name = "tp_linefollowing";
            this.tp_linefollowing.Padding = new System.Windows.Forms.Padding(3);
            this.tp_linefollowing.Size = new System.Drawing.Size(792, 424);
            this.tp_linefollowing.TabIndex = 1;
            this.tp_linefollowing.Text = "LineFollowing";
            this.tp_linefollowing.UseVisualStyleBackColor = true;
            // 
            // tp_settings
            // 
            this.tp_settings.Location = new System.Drawing.Point(4, 22);
            this.tp_settings.Name = "tp_settings";
            this.tp_settings.Size = new System.Drawing.Size(792, 424);
            this.tp_settings.TabIndex = 2;
            this.tp_settings.Text = "Settings";
            this.tp_settings.UseVisualStyleBackColor = true;
            // 
            // frm_MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tc_main);
            this.DoubleBuffered = true;
            this.Name = "frm_MainView";
            this.ShowIcon = false;
            this.Text = "ShitBot";
            this.tc_main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_main;
        private System.Windows.Forms.TabPage tp_sensors;
        private System.Windows.Forms.TabPage tp_linefollowing;
        private System.Windows.Forms.TabPage tp_settings;
    }
}