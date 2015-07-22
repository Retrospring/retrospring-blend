using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class QuestionObject : ResultObject
    {
        public int id { get; set; }
        public string question { get; set; }
        public int answer_count { get; set; }
        public bool anonymous { get; set; }
        public TrimmedUserObject user { get; set; }
        public int user_id { get; set; }
        public AppObject created_with { get; set; }
        public long created_at { get; set; }
    }
}
