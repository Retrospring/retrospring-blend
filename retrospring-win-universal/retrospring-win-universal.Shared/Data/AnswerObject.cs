using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class AnswerObject : ResultObject
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
    }
}
