using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace retrospring_win_universal.Web
{
    class JsonParser
    {
        private static string getJson(string parameter)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://science.retrospring.net/api/sleipnir/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client.GetStringAsync(parameter).Result;
            }
        }

        public static string getPublicTimeline()
        {
            return getJson("user/public.json");
        }

        public static string getUserProfile(int userID)
        {
            return getJson("user/profile/" + userID + ".json");
        }
    }
}
