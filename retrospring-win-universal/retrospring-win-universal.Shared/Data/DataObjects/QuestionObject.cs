using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data.DataObjects
{
    public class QuestionObject
    {
        public static QuestionObject fromDynamic(dynamic quData)
        {
            QuestionObject question = new QuestionObject()
            {
                Id = quData.id,
                Question = quData.question,
                AnswerCount = quData.answer_count,
                IsAnonymous = quData.anonymous,
                Questioner = UserObject.fromDynamicSlim(quData.user),
                CreatedWith = ApplicationRefObject.fromDynamic(quData.created_with),
                CreatedAt = quData.created_at
            };

            return question;
        }

        public int Id { get; set; }
        public string Question { get; set; }
        public int AnswerCount { get; set; }
        public bool IsAnonymous { get; set; }
        private UserObject user;
        public UserObject Questioner
        {
            get { return IsAnonymous ? new AnonymousUserObject() : user; }
            set { user = value; }
        }
        public ApplicationRefObject CreatedWith { get; set; }
        public long CreatedAt { get; set; }
    }
}
