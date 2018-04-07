using System;

using Newtonsoft.Json;

namespace ocssmobile
{
    public class JsonUtil
    {
        public JsonUtil()
        {
        }

        public static string ToString(Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
