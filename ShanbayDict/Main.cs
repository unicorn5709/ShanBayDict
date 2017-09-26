using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShanbayDict
{
    public partial class Dict : Form
    {
        string token;
        string current_word_id;
        GlobalHook hook;
        PopWindows pop;
        Point mouseOff;//鼠标移动位置变量  
        bool leftFlag;//标签是否为左键  

        string query_word_url = "https://api.shanbay.com/bdc/search/?word={0}";
        string add_forget_word_url = "https://api.shanbay.com/bdc/learning/{0}/";
        string add_new_word_url = "https://api.shanbay.com/bdc/learning/";
        string logon_url = "https://api.shanbay.com/oauth2/authorize/?client_id={0}&response_type=token&redirect_uri=https://api.shanbay.com/oauth2/auth/success/";

        public Dict()
        {
            InitializeComponent();
            current_word_id = "";
            pop = new PopWindows();
            pop.add_cb += new add_word_event(add_word);
        }

        private void Dict_Load(object sender, EventArgs e)
        {
            logon_web.Navigate(string.Format(logon_url,
                                             "4e058024d1090c069be8"));
            if (hook == null)
            {
                hook = new GlobalHook();
                hook.OnMouseActivity += new MouseEventHandler(hook_OnMouseActivity);
            }
            pop.Hide();

            //display_explanation("查无此词", exp_output, 33);
        }

        ///// <summary>
        ///// events for mouse move
        ///// </summary>
        void hook_OnMouseActivity(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    IDataObject data = Clipboard.GetDataObject();
                    if(!((GlobalHook)sender).HasStart)
                    {
                        if(pop.Visible)
                        {
                            var x_min = pop.Location.X;
                            var x_max = x_min + pop.Width;
                            var y_min = pop.Location.Y;
                            var y_max = y_min + pop.Height;

                            if (e.X <= x_min || e.X >= x_max || e.Y <= y_min || e.Y >= y_max)
                            {
                                pop.Hide();
                            }
                        }
                        return;
                    }

                    if (data.GetDataPresent(DataFormats.Text))
                    {
                        string temp = data.GetData(DataFormats.Text).ToString();

                        if (temp.Length > 0)
                        {
                            pop.set_content(get_word(temp));
                            pop.Location = new Point(e.X, e.Y);
                            pop.Show();
                        }
                        else
                        {
                            pop.Hide();
                        }
                    }
                    else
                    {
                        pop.Hide();
                    }
                }
                catch (Exception ee)
                {
                    pop.set_exp("剪贴板错误，请重新选词");
                    pop.Location = new Point(e.X, e.Y);
                    pop.Show();
                    return;
                }
            }
        }

        private void query_btn_Click(object sender, EventArgs e)
        {
            string w = WordInput.Text;
            if(w.Length > 0)
            {
                query_word(w);
            }
        }

        private void query_word(string w)
        {
            Word temp = get_word(w);
            current_word_id = "";

            if (temp.Included)
            {
                current_word_id = temp.WordID;
                display_explanation(temp.CNDef, exp_output, 33);

                add_word_btn.Visible = temp.Included;

                if (temp.Learned)
                {
                    add_word_btn.Text = "我忘了";
                    current_word_id = temp.LearningID;
                }
                else
                {
                    add_word_btn.Text = "添加";
                }
            }
        }

        private Word get_word(string w)
        {
            Word temp = new Word(w);
            if (w.Length > 0)
            {
                JObject w_info = get_result("GET", w);
                temp.load_word(w_info);
            }
            return temp;
        }

        private JObject get_result(string method, string id_str)
        {
            JObject w_info = new JObject();
            string url;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                HttpResponseMessage response = null;
                FormUrlEncodedContent formContent;

                switch(method)
                {
                    case "GET":
                        url = String.Format(query_word_url, id_str);
                        response = client.GetAsync(url).Result;
                        break;
                    case "PUT":
                        url = String.Format(add_forget_word_url, id_str);
                        formContent = new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<string, string>("forget", "1"), 
                        });

                        response = client.PutAsync(url, formContent).Result;
                        break;
                    case "POST":
                        url = add_new_word_url;
                        formContent = new FormUrlEncodedContent(new[]
                        {
                            new KeyValuePair<string, string>("id", id_str)
                        });
                        response = client.PostAsync(url, formContent).Result;
                        break;
                    default:
                        break;
                }

                if (response != null && response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync();
                    w_info = (JObject)JsonConvert.DeserializeObject(data.Result);
                }
            }
            return w_info;
        }

        private void logon_web_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            string nav_to_url = e.Url.ToString();

            int start_ind = nav_to_url.IndexOf("#access_token");

            if (start_ind >= 0)
            {
                string temp = nav_to_url.Substring(start_ind + 14);
                int finish_ind = temp.IndexOf("&token_type");
                string t = temp.Substring(0, finish_ind);
                token = t;
                logon_web.Hide();
            }
        }

        private void add_word_btn_Click(object sender, EventArgs e)
        {
            bool learned = ((Button)sender).Text == "我忘了";
            add_word_btn.Text = add_word(learned, current_word_id) ? "已添加" : "失败";
        }

        public bool add_word(bool learned, string id_str)
        {
            string method = learned ? "PUT" : "POST";
            var result = get_result(method, id_str);
            return result.GetValue("msg").ToString() == "SUCCESS";
        }

        private void quit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void display_explanation(string Text, PictureBox pb, int max_len, int font_size=14)
        {
            pb.Image = new Bitmap(pb.Width, pb.Height);
            using (Graphics g = Graphics.FromImage(pb.Image))
            {
                SolidBrush brush = new SolidBrush(SystemColors.Control);
                g.FillRectangle(brush, 0, 0,
                                pb.Image.Width, pb.Image.Height);
                string[] chunks = Text.Split('\n');

                brush = new SolidBrush(Color.Black);
                var brush_param = new SolidBrush(Color.FromArgb(32, 158, 133));
                Font[] fonts = new Font[]{
                    new Font("微软雅黑", font_size, FontStyle.Bold, GraphicsUnit.Point, ((byte)(134))),
                    new Font("微软雅黑", font_size, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)))
                };
                float y = 0;
                for (int i = 0; i < chunks.Length; i++)
                {
                    string sub_str = chunks[i];
                    int spot_ind = sub_str.LastIndexOf('.');

                    if (spot_ind == -1)
                    {
                        g.DrawString(chunks[i], fonts[1], brush, 0, y);
                    }
                    else
                    {
                        float x = 0;
                        string fore_str = sub_str.Substring(0, spot_ind);
                        string post_str = sub_str.Substring(spot_ind);
                        g.DrawString(fore_str, fonts[0], brush_param, x, y);
                        x += (g.MeasureString(fore_str, fonts[0])).Width;

                        while(post_str.Length > max_len)
                        {
                            var cu_str = post_str.Substring(0, max_len);
                            g.DrawString(cu_str, fonts[1], brush, x, y);
                            y += (g.MeasureString(cu_str, fonts[1])).Height;
                            post_str = post_str.Substring(max_len);
                        }
                            
                        g.DrawString(post_str, fonts[1], brush, x, y);
                    }
                    if (i < (chunks.Length - 1))
                    {
                        g.DrawString("\n", pb.Font, brush, 0, y);
                    }
                    y += (g.MeasureString(chunks[i], fonts[0])).Height;
                }
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值  
                leftFlag = true;                  //点击左键按下时标注为true;  
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X, mouseOff.Y);  //设置移动后的位置  
                Location = mouseSet;
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标后标注为false;  
            }
        }

        /// <summary>
        /// 双击任务栏图标还原界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        /// <summary>
        /// 最小化到任务栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dict_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void minimize_btn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Dict_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                string w = WordInput.Text;
                if (w.Length > 0)
                {
                    query_word(w);
                }
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 打开界面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
                this.Activate();
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }  
    }
}
