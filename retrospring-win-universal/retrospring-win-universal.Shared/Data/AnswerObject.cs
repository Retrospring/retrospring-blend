using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class AnswerObject
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int CommentCount { get; set; }
        public int SmileCount { get; set; }
        public UserObject Answerer { get; set; }
        public QuestionObject Question { get; set; }
        public ApplicationRefObject CreatedWith { get; set; }
        public long CreatedAt { get; set; }
    }
}
