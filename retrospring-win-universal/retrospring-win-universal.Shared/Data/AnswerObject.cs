using retrospring_win_universal.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class AnswerObject
    {
        public int id { get; set; }
        public string answer { get; set; }
        public int comment_count { get; set; }
        public int smile_count { get; set; }
        public TrimmedUserObject user { get; set; } //either this
        public int user_id { get; set; } //or this is set (probably)
        public int question_id { get; set; }
        public AppObject created_with { get; set; }
        public long created_at { get; set; }

        public string answererText
        {
            get { return "Answered by " + getActualUser(); }
        }

        public string questionerText
        {
            get { return question.getActualUser() + " asked"; }
        }

        public QuestionObject question
        {
            get { return JsonParser.getQuestion(question_id); }
        }

        public UserObject getActualUser()
        {
            if (user == null)
            {
                return JsonParser.getUserProfile(user_id);
            }
            else
            {
                return JsonParser.getUserProfile(user.id);
            }
        }

        public override string ToString()
        {
            string answerStr = "";

            answerStr = "\"" + answer + "\"";

            return answerStr;
        }
    }
}
