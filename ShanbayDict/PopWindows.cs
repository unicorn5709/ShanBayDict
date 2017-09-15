using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShanbayDict
{
    public partial class PopWindows : Form
    {
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
            popword.Text = w.WordContent;
            popexp.Text = "";
            popexp.Text = w.CNDef;

            //if(w.Included)
            //{
                
            //}
        }
    }
}
