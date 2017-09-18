namespace ShanbayDict
{
    partial class Dict
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.WordInput = new System.Windows.Forms.TextBox();
            this.query_btn = new System.Windows.Forms.Button();
            this.exp_label = new System.Windows.Forms.Label();
            this.logon_web = new System.Windows.Forms.WebBrowser();
            this.add_word_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WordInput
            // 
            this.WordInput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WordInput.Location = new System.Drawing.Point(12, 12);
            this.WordInput.Name = "WordInput";
            this.WordInput.Size = new System.Drawing.Size(339, 29);
            this.WordInput.TabIndex = 0;
            // 
            // query_btn
            // 
            this.query_btn.Location = new System.Drawing.Point(357, 12);
            this.query_btn.Name = "query_btn";
            this.query_btn.Size = new System.Drawing.Size(75, 29);
            this.query_btn.TabIndex = 2;
            this.query_btn.Text = "Query";
            this.query_btn.UseVisualStyleBackColor = true;
            this.query_btn.Click += new System.EventHandler(this.query_btn_Click);
            // 
            // exp_label
            // 
            this.exp_label.AutoSize = true;
            this.exp_label.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exp_label.Location = new System.Drawing.Point(12, 52);
            this.exp_label.Name = "exp_label";
            this.exp_label.Size = new System.Drawing.Size(0, 25);
            this.exp_label.TabIndex = 3;
            // 
            // logon_web
            // 
            this.logon_web.Location = new System.Drawing.Point(12, 52);
            this.logon_web.MinimumSize = new System.Drawing.Size(20, 20);
            this.logon_web.Name = "logon_web";
            this.logon_web.ScrollBarsEnabled = false;
            this.logon_web.Size = new System.Drawing.Size(420, 420);
            this.logon_web.TabIndex = 4;
            this.logon_web.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.logon_web_Navigated);
            // 
            // add_word_btn
            // 
            this.add_word_btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.add_word_btn.Location = new System.Drawing.Point(173, 421);
            this.add_word_btn.Name = "add_word_btn";
            this.add_word_btn.Size = new System.Drawing.Size(75, 40);
            this.add_word_btn.TabIndex = 5;
            this.add_word_btn.Text = "添加";
            this.add_word_btn.UseVisualStyleBackColor = true;
            this.add_word_btn.Click += new System.EventHandler(this.add_word_btn_Click);
            // 
            // Dict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 484);
            this.Controls.Add(this.add_word_btn);
            this.Controls.Add(this.exp_label);
            this.Controls.Add(this.logon_web);
            this.Controls.Add(this.query_btn);
            this.Controls.Add(this.WordInput);
            this.Name = "Dict";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Dict_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WordInput;
        private System.Windows.Forms.Button query_btn;
        private System.Windows.Forms.Label exp_label;
        private System.Windows.Forms.WebBrowser logon_web;
        private System.Windows.Forms.Button add_word_btn;
    }
}

