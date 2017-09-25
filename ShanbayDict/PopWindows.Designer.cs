namespace ShanbayDict
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
            this.control_btn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.test_display = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.test_display)).BeginInit();
            this.SuspendLayout();
            // 
            // popword
            // 
            this.popword.AutoSize = true;
            this.popword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.popword.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.popword.Location = new System.Drawing.Point(15, 13);
            this.popword.Name = "popword";
            this.popword.Size = new System.Drawing.Size(0, 22);
            this.popword.TabIndex = 0;
            // 
            // popexp
            // 
            this.popexp.AutoSize = true;
            this.popexp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.popexp.Location = new System.Drawing.Point(15, 46);
            this.popexp.MaximumSize = new System.Drawing.Size(280, 0);
            this.popexp.Name = "popexp";
            this.popexp.Size = new System.Drawing.Size(0, 21);
            this.popexp.TabIndex = 1;
            this.popexp.Visible = false;
            // 
            // control_btn
            // 
            this.control_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(158)))), ((int)(((byte)(133)))));
            this.control_btn.FlatAppearance.BorderSize = 0;
            this.control_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.control_btn.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.control_btn.ForeColor = System.Drawing.Color.White;
            this.control_btn.Location = new System.Drawing.Point(15, 161);
            this.control_btn.Name = "control_btn";
            this.control_btn.Size = new System.Drawing.Size(260, 29);
            this.control_btn.TabIndex = 2;
            this.control_btn.Text = "添加";
            this.control_btn.UseVisualStyleBackColor = false;
            this.control_btn.Click += new System.EventHandler(this.control_btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.test_display);
            this.panel1.Controls.Add(this.control_btn);
            this.panel1.Controls.Add(this.popword);
            this.panel1.Controls.Add(this.popexp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(15);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(290, 202);
            this.panel1.TabIndex = 3;
            // 
            // test_display
            // 
            this.test_display.Location = new System.Drawing.Point(15, 45);
            this.test_display.Name = "test_display";
            this.test_display.Size = new System.Drawing.Size(260, 110);
            this.test_display.TabIndex = 3;
            this.test_display.TabStop = false;
            // 
            // PopWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(158)))), ((int)(((byte)(133)))));
            this.ClientSize = new System.Drawing.Size(290, 205);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PopWindows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PopWindows";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.test_display)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label popword;
        private System.Windows.Forms.Label popexp;
        private System.Windows.Forms.Button control_btn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox test_display;
    }
}