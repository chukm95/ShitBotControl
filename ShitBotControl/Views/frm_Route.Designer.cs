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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.editorScene1 = new Orthus.Editor.EditorComponents.EditorScene();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.editorScene1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 511;
            this.splitContainer1.TabIndex = 0;
            // 
            // editorScene1
            // 
            this.editorScene1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editorScene1.Location = new System.Drawing.Point(0, 0);
            this.editorScene1.Name = "editorScene1";
            this.editorScene1.Size = new System.Drawing.Size(511, 450);
            this.editorScene1.TabIndex = 0;
            this.editorScene1.Text = "editorScene1";
            // 
            // frm_Route
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Route";
            this.Text = "frm_Route";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Route_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Route_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Frm_Route_Paint);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Orthus.Editor.EditorComponents.EditorScene editorScene1;
    }
}