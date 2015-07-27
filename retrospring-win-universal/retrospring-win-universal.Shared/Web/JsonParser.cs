using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using retrospring_win_universal.Data;

namespace retrospring_win_universal.Web
{
    class JsonParser
    {
        private static dynamic GetResultFromURL(string parameter)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://science.retrospring.net/api/sleipnir/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                using(Stream stream = client.GetStreamAsync(parameter).Result)
                {
                    JsonReader reader = new JsonTextReader(new StreamReader(stream));

                    dynamic result = JObject.Load(reader);

                    // structure of the result should be:
                    // bool success
                    // int code
                    // object result
                    // (some exception stuff)

                    return result.result;
                }
            }
        }

        public static TimelineObject LoadPublicTimeline()
        {
            dynamic timeline = GetResultFromURL("user/public.json");

            if (timeline == null) return null;

            TimelineObject tl = new TimelineObject();
            tl.Count = timeline.count;

            List<AnswerObject> answers = new List<AnswerObject>();
            foreach (var answer in timeline.answers)
            {
                UserObject answerer = new UserObject()
                {
                    Id = answer.user.id,
                    ScreenName = answer.user.screen_name,
                    OptionalName = answer.user.display_name,
                    IsBanned = answer.user.banned
                };

                QuestionObject question = LoadAndGetQuestion(answer.question_id);

                answers.Add(new AnswerObject()
                {
                    Id = answer.id,
                    Answer = answer.answer,
                    Answerer = answerer,
                    CreatedAt = answer.created_at,
                    Question = question
                });
            }

            tl.Answers = answers;

            return tl;
        }

        public static QuestionObject LoadAndGetQuestion(dynamic id)
        {
            dynamic question = GetResultFromURL("question/" + id + ".json");

            /*UserObject questioner = new UserObject()
            {
                Id = question.user.id,
                ScreenName = question.user.screen_name,
                OptionalName = question.user.display_name,
                IsBanned = question.user.banned
            };*/

            QuestionObject qu = new QuestionObject()
            {
                Id = question.id,
                Question = question.question,
                AnswerCount = question.answer_count
                //Questioner = questioner
            };

            return qu;
        }
    }
}
