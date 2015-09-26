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

                    // structure of the result should be:
                    // bool success
                    // int code
                    // object result
                    // (some exception stuff)

                    return result.result;
                }
            }
        }

        public static AnswersObject GetPublicTimeline()
        {
            dynamic publicTLobj = GetResultFromURL("user/public.json");

            AnswersObject timeline = new AnswersObject();

            timeline.Count = publicTLobj.count;

            List<AnswerObject> answers = new List<AnswerObject>();
            foreach(var answer in publicTLobj.answers)
            {
                UserObject answerer = new UserObject()
                {
                    Id = answer.user.id,
                    ScreenName = answer.user.screen_name,
                    OptionalName = answer.user.display_name,
                    Banned = new UserBannedObject()
                    {
                        IsBanned = answer.user.banned
                    }
                };

                UserObject questionerer = null;
                if (answer.question.user != null)
                {
                    questionerer = new UserObject()
                    {
                        Id = answer.question.user.id,
                        ScreenName = answer.question.user.screen_name,
                        OptionalName = answer.question.user.display_name,
                        Banned = new UserBannedObject()
                        {
                            IsBanned = answer.question.user.banned
                        }
                    };
                }

                QuestionObject question = new QuestionObject()
                {
                    Id = answer.question.id,
                    Question = answer.question.question,
                    AnswerCount = answer.question.answer_count,
                    IsAnonymous = answer.question.anonymous,
                    Questioner = questionerer
                };

                answers.Add(new AnswerObject()
                {
                    Id = answer.id,
                    Answer = answer.answer,
                    CommentCount = answer.comment_count,
                    SmileCount = answer.smile_count,
                    Answerer = answerer,
                    Question = question
                });
            }

            timeline.Answers = answers;

            return timeline;
        }
    }
}
