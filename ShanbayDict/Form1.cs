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

        string query_word_url = "https://api.shanbay.com/bdc/search/?word={0}";
        string add_forget_word_url = "https://api.shanbay.com/bdc/learning/{0}/";
        string add_new_word_url = "https://api.shanbay.com/bdc/learning/";

        public Dict()
        {
            InitializeComponent();
            current_word_id = "";
            pop = new PopWindows();
            pop.add_cb += new add_word_event(add_word);
        }

        private void Dict_Load(object sender, EventArgs e)
        {
            logon_web.Navigate(string.Format("https://api.shanbay.com/oauth2/authorize/?client_id={0}&response_type=token&redirect_uri=https://api.shanbay.com/oauth2/auth/success/",
                                             "4e058024d1090c069be8"));
            if (hook == null)
            {
                hook = new GlobalHook();
                hook.OnMouseActivity += new MouseEventHandler(hook_OnMouseActivity);
            }

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
                            //pop.Hide();
                        }
                    }
                    else
                    {
                        pop.Hide();
                    }

                }
                catch(Exception ee)
                {
                    pop.set_exp("剪贴板错误，请重新选词");
                    pop.Location = new Point(e.X, e.Y);
                    return;
                }
            }
            
        }

        private void query_btn_Click(object sender, EventArgs e)
        {
            string w = WordInput.Text;
            Word temp = get_word(w);
            current_word_id = "";

            if(temp.Included)
            {
                current_word_id = temp.WordID;
                exp_label.Text = temp.CNDef;

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
            Word temp = new Word();
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
    }
}
