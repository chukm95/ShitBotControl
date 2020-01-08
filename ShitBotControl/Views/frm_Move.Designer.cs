namespace ShitBotControl.Views
{
    partial class frm_Move
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
            this.btn_forward = new System.Windows.Forms.Button();
            this.btn_left = new System.Windows.Forms.Button();
            this.btn_right = new System.Windows.Forms.Button();
            this.btn_Rotate = new System.Windows.Forms.Button();
            this.btn_infiniteEight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_forward
            // 
            this.btn_forward.Location = new System.Drawing.Point(473, 164);
            this.btn_forward.Name = "btn_forward";
            this.btn_forward.Size = new System.Drawing.Size(75, 23);
            this.btn_forward.TabIndex = 0;
            this.btn_forward.Text = "forward";
            this.btn_forward.UseVisualStyleBackColor = true;
            this.btn_forward.Click += new System.EventHandler(this.Btn_forward_Click);
            // 
            // btn_left
            // 
            this.btn_left.Location = new System.Drawing.Point(392, 193);
            this.btn_left.Name = "btn_left";
            this.btn_left.Size = new System.Drawing.Size(75, 23);
            this.btn_left.TabIndex = 1;
            this.btn_left.Text = "left";
            this.btn_left.UseVisualStyleBackColor = true;
            this.btn_left.Click += new System.EventHandler(this.Btn_left_Click);
            // 
            // btn_right
            // 
            this.btn_right.Location = new System.Drawing.Point(554, 193);
            this.btn_right.Name = "btn_right";
            this.btn_right.Size = new System.Drawing.Size(75, 23);
            this.btn_right.TabIndex = 2;
            this.btn_right.Text = "right";
            this.btn_right.UseVisualStyleBackColor = true;
            this.btn_right.Click += new System.EventHandler(this.Btn_right_Click);
            // 
            // btn_Rotate
            // 
            this.btn_Rotate.Location = new System.Drawing.Point(473, 193);
            this.btn_Rotate.Name = "btn_Rotate";
            this.btn_Rotate.Size = new System.Drawing.Size(75, 23);
            this.btn_Rotate.TabIndex = 3;
            this.btn_Rotate.Text = "rotate180";
            this.btn_Rotate.UseVisualStyleBackColor = true;
            this.btn_Rotate.Click += new System.EventHandler(this.Btn_Rotate_Click);
            // 
            // btn_infiniteEight
            // 
            this.btn_infiniteEight.Location = new System.Drawing.Point(473, 222);
            this.btn_infiniteEight.Name = "btn_infiniteEight";
            this.btn_infiniteEight.Size = new System.Drawing.Size(75, 23);
            this.btn_infiniteEight.TabIndex = 4;
            this.btn_infiniteEight.Text = "infiniteEight";
            this.btn_infiniteEight.UseVisualStyleBackColor = true;
            this.btn_infiniteEight.Click += new System.EventHandler(this.Btn_infiniteEight_Click);
            // 
            // frm_Move
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_infiniteEight);
            this.Controls.Add(this.btn_Rotate);
            this.Controls.Add(this.btn_right);
            this.Controls.Add(this.btn_left);
            this.Controls.Add(this.btn_forward);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Move";
            this.Text = "frm_Move";
            this.Load += new System.EventHandler(this.Frm_Move_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_forward;
        private System.Windows.Forms.Button btn_left;
        private System.Windows.Forms.Button btn_right;
        private System.Windows.Forms.Button btn_Rotate;
        private System.Windows.Forms.Button btn_infiniteEight;
    }
}