﻿namespace ShanbayDict
{
    partial class PopWindows
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
            this.popword = new System.Windows.Forms.Label();
            this.popexp = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // popword
            // 
            this.popword.AutoSize = true;
            this.popword.Location = new System.Drawing.Point(13, 13);
            this.popword.Name = "popword";
            this.popword.Size = new System.Drawing.Size(0, 12);
            this.popword.TabIndex = 0;
            // 
            // popexp
            // 
            this.popexp.AutoSize = true;
            this.popexp.Location = new System.Drawing.Point(15, 46);
            this.popexp.Name = "popexp";
            this.popexp.Size = new System.Drawing.Size(0, 12);
            this.popexp.TabIndex = 1;
            // 
            // PopWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.popexp);
            this.Controls.Add(this.popword);
            this.Name = "PopWindows";
            this.Text = "PopWindows";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label popword;
        private System.Windows.Forms.Label popexp;
    }
}