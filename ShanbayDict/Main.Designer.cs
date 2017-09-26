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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dict));
            this.WordInput = new System.Windows.Forms.TextBox();
            this.query_btn = new System.Windows.Forms.Button();
            this.exp_label = new System.Windows.Forms.Label();
            this.logon_web = new System.Windows.Forms.WebBrowser();
            this.add_word_btn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.quit_btn = new System.Windows.Forms.Panel();
            this.minimize_btn = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exp_output = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.iconrightclick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打开界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exp_output)).BeginInit();
            this.iconrightclick.SuspendLayout();
            this.SuspendLayout();
            // 
            // WordInput
            // 
            this.WordInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WordInput.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WordInput.Location = new System.Drawing.Point(2, 4);
            this.WordInput.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.WordInput.Name = "WordInput";
            this.WordInput.Size = new System.Drawing.Size(285, 29);
            this.WordInput.TabIndex = 0;
            this.WordInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Dict_KeyPress);
            // 
            // query_btn
            // 
            this.query_btn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.query_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.query_btn.FlatAppearance.BorderSize = 0;
            this.query_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.query_btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.query_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.query_btn.Location = new System.Drawing.Point(290, 3);
            this.query_btn.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.query_btn.Name = "query_btn";
            this.query_btn.Size = new System.Drawing.Size(73, 30);
            this.query_btn.TabIndex = 2;
            this.query_btn.Text = "查询";
            this.query_btn.UseVisualStyleBackColor = false;
            this.query_btn.Click += new System.EventHandler(this.query_btn_Click);
            // 
            // exp_label
            // 
            this.exp_label.AutoSize = true;
            this.exp_label.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exp_label.Location = new System.Drawing.Point(270, 4);
            this.exp_label.Margin = new System.Windows.Forms.Padding(10, 10, 3, 0);
            this.exp_label.MaximumSize = new System.Drawing.Size(420, 0);
            this.exp_label.Name = "exp_label";
            this.exp_label.Size = new System.Drawing.Size(0, 25);
            this.exp_label.TabIndex = 3;
            // 
            // logon_web
            // 
            this.logon_web.Location = new System.Drawing.Point(0, -47);
            this.logon_web.MinimumSize = new System.Drawing.Size(20, 20);
            this.logon_web.Name = "logon_web";
            this.logon_web.ScrollBarsEnabled = false;
            this.logon_web.Size = new System.Drawing.Size(439, 385);
            this.logon_web.TabIndex = 4;
            this.logon_web.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.logon_web_Navigated);
            // 
            // add_word_btn
            // 
            this.add_word_btn.BackColor = System.Drawing.SystemColors.ControlDark;
            this.add_word_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.add_word_btn.FlatAppearance.BorderSize = 0;
            this.add_word_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_word_btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.add_word_btn.ForeColor = System.Drawing.SystemColors.Control;
            this.add_word_btn.Location = new System.Drawing.Point(365, 3);
            this.add_word_btn.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.add_word_btn.Name = "add_word_btn";
            this.add_word_btn.Size = new System.Drawing.Size(73, 30);
            this.add_word_btn.TabIndex = 5;
            this.add_word_btn.Text = "添加";
            this.add_word_btn.UseVisualStyleBackColor = false;
            this.add_word_btn.Click += new System.EventHandler(this.add_word_btn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(439, 325);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.Controls.Add(this.query_btn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.add_word_btn, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.WordInput, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(439, 36);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(158)))), ((int)(((byte)(133)))));
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.quit_btn, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.minimize_btn, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(439, 30);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(158)))), ((int)(((byte)(133)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.exp_label);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 30);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shanbay Dict";
            // 
            // quit_btn
            // 
            this.quit_btn.BackColor = System.Drawing.Color.Transparent;
            this.quit_btn.BackgroundImage = global::ShanbayDict.Properties.Resources.close;
            this.quit_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.quit_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quit_btn.Location = new System.Drawing.Point(414, 5);
            this.quit_btn.Margin = new System.Windows.Forms.Padding(5);
            this.quit_btn.Name = "quit_btn";
            this.quit_btn.Size = new System.Drawing.Size(20, 20);
            this.quit_btn.TabIndex = 1;
            this.quit_btn.Click += new System.EventHandler(this.quit_btn_Click);
            // 
            // minimize_btn
            // 
            this.minimize_btn.BackgroundImage = global::ShanbayDict.Properties.Resources.minimize;
            this.minimize_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.minimize_btn.Location = new System.Drawing.Point(384, 5);
            this.minimize_btn.Margin = new System.Windows.Forms.Padding(5);
            this.minimize_btn.Name = "minimize_btn";
            this.minimize_btn.Size = new System.Drawing.Size(20, 20);
            this.minimize_btn.TabIndex = 2;
            this.minimize_btn.Click += new System.EventHandler(this.minimize_btn_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 66);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 3;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(439, 259);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.exp_output);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 20);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 219);
            this.panel2.TabIndex = 0;
            // 
            // exp_output
            // 
            this.exp_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exp_output.Location = new System.Drawing.Point(0, 0);
            this.exp_output.Margin = new System.Windows.Forms.Padding(0);
            this.exp_output.Name = "exp_output";
            this.exp_output.Size = new System.Drawing.Size(399, 219);
            this.exp_output.TabIndex = 0;
            this.exp_output.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.iconrightclick;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ShanbayDict";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // iconrightclick
            // 
            this.iconrightclick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开界面ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.iconrightclick.Name = "iconrightclick";
            this.iconrightclick.Size = new System.Drawing.Size(153, 70);
            // 
            // 打开界面ToolStripMenuItem
            // 
            this.打开界面ToolStripMenuItem.Name = "打开界面ToolStripMenuItem";
            this.打开界面ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.打开界面ToolStripMenuItem.Text = "打开界面";
            this.打开界面ToolStripMenuItem.Click += new System.EventHandler(this.打开界面ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // Dict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(439, 325);
            this.Controls.Add(this.logon_web);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Dict";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shanbay Dict";
            this.Load += new System.EventHandler(this.Dict_Load);
            this.SizeChanged += new System.EventHandler(this.Dict_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exp_output)).EndInit();
            this.iconrightclick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox WordInput;
        private System.Windows.Forms.Button query_btn;
        private System.Windows.Forms.Label exp_label;
        private System.Windows.Forms.WebBrowser logon_web;
        private System.Windows.Forms.Button add_word_btn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel quit_btn;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Panel minimize_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox exp_output;
        private System.Windows.Forms.ContextMenuStrip iconrightclick;
        private System.Windows.Forms.ToolStripMenuItem 打开界面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
    }
}

