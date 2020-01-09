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
            this.tp_move = new System.Windows.Forms.TabPage();
            this.tp_map = new System.Windows.Forms.TabPage();
            this.tp_sensors = new System.Windows.Forms.TabPage();
            this.tc_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // tc_main
            // 
            this.tc_main.Controls.Add(this.tp_sensors);
            this.tc_main.Controls.Add(this.tp_move);
            this.tc_main.Controls.Add(this.tp_map);
            this.tc_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_main.Location = new System.Drawing.Point(0, 0);
            this.tc_main.Name = "tc_main";
            this.tc_main.SelectedIndex = 0;
            this.tc_main.Size = new System.Drawing.Size(800, 450);
            this.tc_main.TabIndex = 0;
            this.tc_main.SelectedIndexChanged += new System.EventHandler(this.Tc_main_SelectedIndexChanged);
            // 
            // tp_move
            // 
            this.tp_move.Location = new System.Drawing.Point(4, 22);
            this.tp_move.Name = "tp_move";
            this.tp_move.Size = new System.Drawing.Size(792, 424);
            this.tp_move.TabIndex = 3;
            this.tp_move.Text = "Move";
            this.tp_move.UseVisualStyleBackColor = true;
            // 
            // tp_map
            // 
            this.tp_map.Location = new System.Drawing.Point(4, 22);
            this.tp_map.Name = "tp_map";
            this.tp_map.Size = new System.Drawing.Size(792, 424);
            this.tp_map.TabIndex = 4;
            this.tp_map.Text = "Map";
            this.tp_map.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.TabPage tp_move;
        private System.Windows.Forms.TabPage tp_map;
        private System.Windows.Forms.TabPage tp_sensors;
    }
}