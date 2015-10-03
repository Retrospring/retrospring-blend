using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data.DataObjects
{
    public class AnswerObject
    {
        public static AnswerObject fromDynamic(dynamic ansData)
        {
            AnswerObject answer = new AnswerObject()
            {
                Id = ansData.id,
                Answer = ansData.answer,
                CommentCount = ansData.comment_count,
                SmileCount = ansData.smile_count,
                Answerer = UserObject.fromDynamicSlim(ansData.user),
                Question = QuestionObject.fromDynamic(ansData.question),
                CreatedWith = ApplicationRefObject.fromDynamic(ansData.created_with),
                CreatedAt = ansData.created_at
            };

            return answer;
        }

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
