using System;
using Models;
using System.Net.Http;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClientMethods
{
    public class Server
    {
        public static async Task<HttpResponseMessage>  PostAsync(object obj, string reqestUri)
        {
            HttpClient client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30)
            };

            var resp = await client.PostAsync(reqestUri,
                    new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));

            string res = resp.Content.ReadAsStringAsync().Result;
            return resp;
        }
    }
}
