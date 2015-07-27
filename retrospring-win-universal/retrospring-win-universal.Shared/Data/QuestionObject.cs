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
        public UserObject Questioner { get; set; }
        // created with
        public long CreatedAt { get; set; }
    }
}
