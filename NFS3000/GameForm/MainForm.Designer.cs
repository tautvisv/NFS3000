namespace GameForm
{
    partial class MainForm
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
            this.MainBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MainBox
            // 
            this.MainBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainBox.Enabled = false;
            this.MainBox.Font = new System.Drawing.Font("Consolas", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.MainBox.Location = new System.Drawing.Point(0, 0);
            this.MainBox.Multiline = true;
            this.MainBox.Name = "MainBox";
            this.MainBox.ReadOnly = true;
            this.MainBox.ShortcutsEnabled = false;
            this.MainBox.Size = new System.Drawing.Size(664, 333);
            this.MainBox.TabIndex = 0;
            this.MainBox.WordWrap = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 333);
            this.Controls.Add(this.MainBox);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(680, 372);
            this.Name = "MainForm";
            this.Text = "NFS3000";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.MainForm_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox MainBox;
    }
}

