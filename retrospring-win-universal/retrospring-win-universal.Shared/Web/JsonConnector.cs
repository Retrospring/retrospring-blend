using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using retrospring_win_universal.Data.DataObjects;
using System.Collections.ObjectModel;

namespace retrospring_win_universal.Web
{
    class JsonConnector
    {
        public const string BASE_URL = "https://science.retrospring.net/api/sleipnir/";
        public const string USER_PATH = "user/";
        public const string QUESTION_PATH = "question/";
        public const string ANSWER_PATH = "answer/";

        private async static Task<dynamic> GetResultFromURL(string parameter)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BASE_URL);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                using(Stream stream = await client.GetStreamAsync(parameter))
                {
                    JsonReader reader = new JsonTextReader(new StreamReader(stream));

                    dynamic result = JObject.Load(reader);

                    return result.result;
                }
            }
        }

        #region User Methods
        public async static Task<AnswersObject> GetPublicTimeline()
        {
            return await GetAnswersObject(USER_PATH + "public.json");
        }

        public async static Task<UserObject> GetUserProfile(int userId)
        {
            dynamic dynUserObj = await GetResultFromURL(USER_PATH + userId + "/profile.json");

            return UserObject.fromDynamic(dynUserObj);
        }

        public async static Task<UserObject> GetUserProfileByName(string screenName)
        {
            dynamic dynUserObj = await GetResultFromURL("util/resolve/" + screenName + ".json");

            return UserObject.fromDynamic(dynUserObj);
        }

        public async static Task<QuestionsObject> GetQuestionsOfUser(int userId)
        {
            return await GetQuestionsObject(USER_PATH + userId + "/questions.json");
        }

        public async static Task<AnswersObject> GetAnswersOfUser(int userId)
        {
            return await GetAnswersObject(USER_PATH + userId + "/answers.json");
        }

        public async static Task<FollowersObject> GetFollowersOfUser(int userId)
        {
            dynamic dynFollowersObj = await GetResultFromURL(USER_PATH + userId + "/followers.json");

            FollowersObject followersObj = new FollowersObject();

            followersObj.Count = dynFollowersObj.count;

            ObservableCollection<FollowObject> followers = new ObservableCollection<FollowObject>();
            foreach (var follower in dynFollowersObj.followers)
            {
                followers.Add(FollowObject.fromDynamic(follower));
            }

            followersObj.Followers = followers;

            return followersObj;
        }

        public async static Task<FollowingsObject> GetFollowingsOfUser(int userId)
        {
            dynamic dynFollowingsObj = await GetResultFromURL(USER_PATH + userId + "/following.json");

            FollowingsObject followingsObj = new FollowingsObject();

            followingsObj.Count = dynFollowingsObj.count;

            ObservableCollection<FollowObject> followings = new ObservableCollection<FollowObject>();
            foreach (var following in dynFollowingsObj.followers)
            {
                followings.Add(FollowObject.fromDynamic(following));
            }

            followingsObj.Followings = followings;

            return followingsObj;
        }
        
        //left out GetAvatarOfUser and GetHeaderOfUser on purpose
        #endregion

        #region Question Methods
        public async static Task<QuestionObject> GetQuestion(int quId)
        {
            dynamic dynQuestionObj = await GetResultFromURL(QUESTION_PATH + quId + ".json");

            return QuestionObject.fromDynamic(dynQuestionObj);
        }

        public async static Task<AnswersObject> GetAnswersOfQuestion(int quId)
        {
            return await GetAnswersObject(USER_PATH + quId + "/answers.json");
        }
        
        public async static Task<QuestionsObject> GetQuestionsObject(string path)
        {
            dynamic dynQuestionsObj = await GetResultFromURL(path);

            QuestionsObject questionsObj = new QuestionsObject();

            questionsObj.Count = dynQuestionsObj.count;

            ObservableCollection<QuestionObject> questions = new ObservableCollection<QuestionObject>();
            foreach (var question in dynQuestionsObj.questions)
            {
                questions.Add(QuestionObject.fromDynamic(question));
            }

            questionsObj.Questions = questions;

            return questionsObj;
        }
        #endregion

        #region Answer Methods
        public async static Task<AnswerObject> GetAnswer(int ansId)
        {
            dynamic dynAnsObj = await GetResultFromURL(ANSWER_PATH + ansId + ".json");

            return AnswerObject.fromDynamic(dynAnsObj);
        }

        public async static Task<CommentsObject> GetCommentsOfAnswer(int ansId)
        {
            dynamic dynComObj = await GetResultFromURL(ANSWER_PATH + ansId + "/comments.json");

            CommentsObject commentsObj = new CommentsObject();

            commentsObj.Count = dynComObj.count;

            ObservableCollection<CommentObject> comments = new ObservableCollection<CommentObject>();
            foreach (var comment in dynComObj.comments)
            {
                comments.Add(CommentObject.fromDynamic(comment));
            }

            commentsObj.Comments = comments;

            return commentsObj;
        }

        //TODO: Add GetSmilesOfAnswer

        public async static Task<AnswersObject> GetAnswersObject(string path)
        {
            dynamic dynAnswersobj = await GetResultFromURL(path);

            AnswersObject answersObj = new AnswersObject();

            answersObj.Count = dynAnswersobj.count;

            ObservableCollection<AnswerObject> answers = new ObservableCollection<AnswerObject>();
            foreach(var answer in dynAnswersobj.answers)
            {
                answers.Add(AnswerObject.fromDynamic(answer));
            }

            answersObj.Answers = answers;

            return answersObj;
        }
        #endregion
    }
}
