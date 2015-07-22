using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using retrospring_win_universal.Data;

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

        private static T getResult<T>(string path)
        {
            ApiResultContainer<T> apiResultRef = new ApiResultContainer<T>();

            ApiResultContainer<T> receivedRes = JsonConvert.DeserializeAnonymousType<ApiResultContainer<T>>(getJson(path), apiResultRef);

            return receivedRes.result;
        }

        public static TimelineObject getPublicTimeline()
        {
            return getResult<TimelineObject>("user/public.json");
        }

        public static UserObject getUserProfile(int userID)
        {
            return getResult<UserObject>("user/" + userID + "/profile.json");
        }


        public static QuestionObject getQuestion(int questionID)
        {
            return getResult<QuestionObject>("question/" + questionID + ".json");
        }
    }
}
