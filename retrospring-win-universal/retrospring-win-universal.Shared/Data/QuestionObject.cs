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
        public TrimmedUserObject user { get; set; } //either this
        public int user_id { get; set; } //or this is set (probably)
        public AppObject created_with { get; set; }
        public long created_at { get; set; }
    }
}
