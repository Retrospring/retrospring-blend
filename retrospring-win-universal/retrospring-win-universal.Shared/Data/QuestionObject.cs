using retrospring_win_universal.Web;
using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class QuestionObject
    {
        public int id { get; set; }
        public string question { get; set; }
        public int answer_count { get; set; }
        public bool anonymous { get; set; }
        public TrimmedUserObject user { get; set; }//probably this will be set, but who knows
        public int user_id { get; set; } //or this is set (probably)
        public AppObject created_with { get; set; }
        public long created_at { get; set; }

        public UserObject getActualUser()
        {
            if(anonymous)
            {
                return new AnonymousUserObject();
            }
            else if (user == null)
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
            string questionStr = "";

            questionStr = "\"" + question + "\"";

            return questionStr;
        }
    }
}
