using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class TimelineObject : ResultObject
    {
        public int count { get; set; }
        public string next { get; set; }
        public AnswerObject[] answers { get; set; }
    }
}
