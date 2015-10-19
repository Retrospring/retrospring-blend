using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data.DataObjects
{
    public class CommentObject
    {
        public static CommentObject fromDynamic(dynamic comData)
        {
            CommentObject comment = new CommentObject()
            {
                Id = comData.id,
                Comment = comData.comment,
                Smiles = comData.smiles,
                Answer = AnswerObject.fromDynamic(comData.answer),
                User = UserObject.fromDynamicSlim(comData.user),
                CreatedWith = ApplicationRefObject.fromDynamic(comData.created_with),
                CreatedAt = comData.created_at
            };

            return comment;
        }

        public int Id { get; set; }
        public string Comment { get; set; }
        public int Smiles { get; set; }
        public AnswerObject Answer { get; set; }
        public UserObject User { get; set; }
        public ApplicationRefObject CreatedWith { get; set; }
        public long CreatedAt { get; set; }
    }
}
