using System;

using System.Net.Http;
using System.Threading.Tasks;
using System.Text;

using Newtonsoft.Json;

namespace ocssmobile
{
    public class HttpUtil
    {
        private static HttpUtil instance;

        private HttpClient client;

        private HttpUtil()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
        }

        public static HttpUtil Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HttpUtil();
                }
                return instance;
            }
        }

        public void AddToken()
        {
            if (client.DefaultRequestHeaders.Contains("Authorization"))
            {
                client.DefaultRequestHeaders.Remove("Authorization");
            }
            if (App.Current.Properties.ContainsKey("token"))
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {App.Current.Properties["token"]}");
            }
        }

        public async Task<Result> GetAsync(string url)
        {
            AddToken();
            var response = await client.GetStringAsync(url);
            var result = JsonConvert.DeserializeObject<Result>(response);
            return result;
        }

        public async Task<Result> PostAsync(string url, Object obj)
        {
            AddToken();
            var data = JsonConvert.SerializeObject(obj);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            var result = JsonConvert.DeserializeObject<Result>(response.Content.ReadAsStringAsync().Result);
            return result;
        }
    }
}


