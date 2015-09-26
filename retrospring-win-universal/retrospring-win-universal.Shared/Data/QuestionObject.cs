using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class QuestionObject
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int AnswerCount { get; set; }
        public bool IsAnonymous { get; set; }
        private UserObject user;
        public UserObject Questioner
        {
            get { return IsAnonymous ? new AnonymousUserObject() : user; }
            set { user = value; }
        }
        public ApplicationRefObject CreatedWith { get; set; }
        public long CreatedAt { get; set; }
    }
}
