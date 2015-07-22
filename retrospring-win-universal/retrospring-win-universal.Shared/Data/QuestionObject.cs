﻿using System;
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
        public UserObject user { get; set; }
        public AppObject created_with { get; set; }
        public long created_at { get; set; }
    }
}
