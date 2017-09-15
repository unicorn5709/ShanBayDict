﻿using System;
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
        Word current_word;

        public Dict()
        {
            InitializeComponent();
            current_word_id = "";
            pop = new PopWindows();
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
                            pop.Hide();
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

        private void button1_Click(object sender, EventArgs e)
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
                string query_url = string.Format("https://api.shanbay.com/bdc/search/?word={0}", w);

                JObject w_info = get_result(query_url, "GET");
                temp.load_word(w_info);
            }
            return temp;
        }

        private JObject get_result(string url, string method, string msg="")
        {
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = method;
            request.Headers["Authorization"] = "Bearer " + token;

            if (msg.Length > 0)
            {
                request.ContentLength = msg.Length;
                StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
                writer.Write(msg);
                writer.Flush();
            }

            JObject w_info = new JObject();
            try
            {
                using(var response = (HttpWebResponse)request.GetResponse())
                {
                    using(var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        string res = reader.ReadToEnd();
                        w_info = (JObject)JsonConvert.DeserializeObject(res);
                    }
                }
                
            }
            catch(WebException we)
            {
                logon_web.Show();
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
            if(((Button)sender).Text == "我忘了")
            {
                string Url = " https://api.shanbay.com/bdc/learning/49140802237/";

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Url);
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                    var response = client.PutAsync(Url, null).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        add_word_btn.Text = "已添加";
                    }
                    else
                    {
                        add_word_btn.Text = "失败";
                    }
                }
            }
            if(current_word_id.Length > 0)
            {
                //add_word();
                //string query_url = "https://api.shanbay.com/bdc/learning";
                
                //StringWriter sw = new StringWriter();
                //JsonWriter writer = new JsonTextWriter(sw);
                //writer.WriteStartObject();
                //writer.WritePropertyName("id");
                //writer.WriteValue(current_word_id);
                //writer.WriteEndObject();
                //writer.Flush();
                //string postDataStr = sw.GetStringBuilder().ToString();

                //JObject w_i = get_result(query_url, "POST", postDataStr);

                
            }
        }

        public JObject add_word()
        {
            HttpWebRequest request = null;
            //HTTPSQ请求  
            request = WebRequest.Create("https://api.shanbay.com/bdc/learning") as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            StringBuilder buffer = new StringBuilder();
            buffer.AppendFormat("&{0}={1}", "access_token", token);
            buffer.AppendFormat("&{0}={1}", "id", current_word_id);

            byte[] data = Encoding.ASCII.GetBytes(buffer.ToString());

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            //如果需要POST数据     
            JObject w_info = new JObject();
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        string res = reader.ReadToEnd();
                        w_info = (JObject)JsonConvert.DeserializeObject(res);
                    }
                }

            }
            catch (WebException we)
            {
                logon_web.Show();
            }
            return w_info;  
        }
    }
}
