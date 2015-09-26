using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class AnswersObject
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public List<AnswerObject> Answers { get; set; }
    }
}
