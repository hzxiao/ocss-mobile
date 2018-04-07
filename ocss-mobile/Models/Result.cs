using System;

using System.Collections.Generic;
using Newtonsoft.Json;

namespace ocssmobile
{
    public class Result
    {
        public int code { get; set; }
        public Dictionary<string, Object> data { get; set; }
        public string msg { get; set; }
        public string err { get; set; }


        public int GetInt(string key)
        {
            if (data == null)
            {
                return 0;
            }

            if (!data.ContainsKey(key))
            {
                return 0;
            }

            int v = (int)data[key];
            return v;
        }

        public string GetString(string key)
        {
            if (data == null)
            {
                return "";
            }

            if (!data.ContainsKey(key))
            {
                return "";
            }

            var v = (string)data[key];
            return v;
        }

        public Dictionary<string, Object> GetDict(string key)
        {
            if (data == null)
            {
                return null;
            }

            if (!data.ContainsKey(key))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Dictionary<string, Object>>(JsonUtil.ToString(data[key]));
        }
    }
}
