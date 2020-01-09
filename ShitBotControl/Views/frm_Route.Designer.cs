namespace ShitBotControl.Views
{
    partial class frm_Route
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
            this.btn_drive = new System.Windows.Forms.Button();
            this.editorScene1 = new ShitBotControl.EditorComponents.EditorScene();
            this.SuspendLayout();
            // 
            // btn_drive
            // 
            this.btn_drive.Location = new System.Drawing.Point(12, 315);
            this.btn_drive.Name = "btn_drive";
            this.btn_drive.Size = new System.Drawing.Size(75, 23);
            this.btn_drive.TabIndex = 3;
            this.btn_drive.Text = "Drive";
            this.btn_drive.UseVisualStyleBackColor = true;
            this.btn_drive.Click += new System.EventHandler(this.Btn_drive_Click);
            // 
            // editorScene1
            // 
            this.editorScene1.Location = new System.Drawing.Point(1, 0);
            this.editorScene1.Name = "editorScene1";
            this.editorScene1.Size = new System.Drawing.Size(550, 309);
            this.editorScene1.TabIndex = 1;
            this.editorScene1.Text = "editorScene1";
            this.editorScene1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.EditorScene1_MouseDoubleClick);
            // 
            // frm_Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_drive);
            this.Controls.Add(this.editorScene1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Route";
            this.Text = "frm_Route";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Route_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Route_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private EditorComponents.EditorScene editorScene1;
        private System.Windows.Forms.Button btn_drive;
    }
}