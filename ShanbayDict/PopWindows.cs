using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShanbayDict
{
    public delegate bool add_word_event(bool learned, string id_str);
    public partial class PopWindows : Form
    {
        public event add_word_event add_cb;
        string word_id;
        public PopWindows()
        {
            InitializeComponent();
        }

        public void set_word(string word)
        {
            popword.Text = word;
        }

        public void set_exp(string exp)
        {
            popexp.Text = exp;
        }

        public void set_content(Word w)
        {
            if (w.Included)
            {
                popword.Text = w.WordContent;
                popexp.Text = "";
                popexp.Text = w.CNDef;
                if (w.Learned)
                {
                    control_btn.Text = "我忘了";
                    word_id = w.LearningID;
                }
                else
                {
                    control_btn.Text = "添加";
                    word_id = w.WordID;
                }
            }
            else
            {
                popword.Text = "查无此词";
                control_btn.Enabled = false;
            }
        }

        private void control_btn_Click(object sender, EventArgs e)
        {
            bool su = add_cb(((Button)sender).Text == "我忘了", word_id);
            control_btn.Text = su ? "已添加" : "失败";
            if(su)
            {
                this.Hide();
            }
        }
    }
}
