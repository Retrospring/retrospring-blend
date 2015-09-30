﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using retrospring_win_universal.Data;
using System.Collections.ObjectModel;

namespace retrospring_win_universal.Web
{
    class JsonParser
    {
        public const string BASE_URL = "https://science.retrospring.net/api/sleipnir/";

        private static dynamic GetResultFromURL(string parameter)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URL);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                using(Stream stream = client.GetStreamAsync(parameter).Result)
                {
                    JsonReader reader = new JsonTextReader(new StreamReader(stream));

                    dynamic result = JObject.Load(reader);

                    return result.result;
                }
            }
        }

        public static AnswersObject GetPublicTimeline()
        {
            dynamic publicTLobj = GetResultFromURL("user/public.json");

            AnswersObject timeline = new AnswersObject();

            timeline.Count = publicTLobj.count;

            ObservableCollection<AnswerObject> answers = new ObservableCollection<AnswerObject>();
            foreach(var answer in publicTLobj.answers)
            {
                answers.Add(AnswerObject.fromDynamic(answer));
            }

            timeline.Answers = answers;

            return timeline;
        }
    }
}
