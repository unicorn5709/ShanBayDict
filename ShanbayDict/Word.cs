using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ShanbayDict
{
    public class Word
    {
        private string _w;
        private bool has_def;
        private string cn_def;
        private bool haslearn;
        private string w_id;
        private string learning_id;

        public Word(JObject w_info)
        {
            _w = "";
            has_def = false;
            cn_def = "查无此词";
            haslearn = false;
            w_id = "";
            load_word(w_info);
        }

        public Word()
        {
            _w = "";
            has_def = false;
            cn_def = "查无此词";
            haslearn = false;
            w_id = "";
        }

        public void load_word(JObject w_info)
        {
            try
            {
                haslearn = (w_info["data"]["retention"].ToString() != "0");
            }
            catch(Exception eh)
            {
                haslearn = false;
            }

            try
            {
                _w = w_info["data"]["content"].ToString().Trim();
                cn_def = w_info["data"]["definition"].ToString().Trim();
                w_id = w_info["data"]["id"].ToString().Trim();
                learning_id = w_info["data"]["learning_id"].ToString().Trim();
            }
            catch (Exception ee)
            {
                has_def = false;
            }

            has_def = true;
        }

        public string WordContent
        {
            get
            {
                return _w;
            }
        }

        public bool Included
        {
            get
            {
                return has_def;
            }
        }

        public string CNDef
        {
            get
            {
                return cn_def;
            }
        }

        public bool Learned
        {
            get
            {
                return haslearn;
            }
        }

        public string WordID
        {
            get
            {
                return w_id;
            }
        }

        public string LearningID
        {
            get
            {
                return learning_id;
            }
        }
    }
}
