﻿using System;
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

            ApiResultContainer<T> receivedRes = JsonConvert.DeserializeAnonymousType(getJson(path), apiResultRef);
            
            if(receivedRes.code != 200)
            {
                //TODO: add alternative result for errors and stuff
                System.Diagnostics.Debug.WriteLine(receivedRes.exception);
                return default(T);
            }

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

        public static FollowerObject getUserFollower(int userID)
        {
            return getResult<FollowerObject>("user/" + userID + "/followers.json");
        }

        public static FollowingObject getUserFollowing(int userID)
        {
            return getResult<FollowingObject>("user/" + userID + "/following.json");
        }

        public static QuestionObject getQuestion(int questionID)
        {
            return getResult<QuestionObject>("question/" + questionID + ".json");
        }

        public static AnswerObject getAnswer(int answerID)
        {
            return getResult<AnswerObject>("answer/" + answerID + ".json");
        }
    }
}
