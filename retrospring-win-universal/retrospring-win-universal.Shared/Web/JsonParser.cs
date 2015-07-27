using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace retrospring_win_universal.Web
{
    class JsonParser
    {
        private async static Task<string> getJson(string parameter)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://science.retrospring.net/api/sleipnir/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string result = await client.GetStringAsync(parameter);

                return result;
            }
        }
    }
}
