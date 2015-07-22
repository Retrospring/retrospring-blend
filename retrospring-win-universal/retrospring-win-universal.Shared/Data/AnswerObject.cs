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
        public UserObject user { get; set; }
        public int question_id { get; set; }
        public AppObject created_with { get; set; }
        public long created_at { get; set; }
    }
}
