using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class UserObject
    {
        public int Id { get; set; }
        public string ScreenName { get; set; }
        public string OptionalName { get; set; }
        public AvatarObject Avatar { get; set; }
        public HeaderObject Header { get; set; }
        public string MotivationHeader { get; set; }
        public string Website { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }
        public UserFlagObject Flags { get; set; }
        public UserBannedObject Banned { get; set; }
        public string Locale { get; set; }
        public int FriendCount { get; set; }
        public int FollowerCount { get; set; }
        public int QuestionCount { get; set; }
        public int AnswerCount { get; set; }
        public int CommentCount { get; set; }
        public int SmileCount { get; set; }
        public int CommentSmileCount { get; set; }
        public bool AllowAnonymousQuestions { get; set; }
        public bool AllowStrangerAnswers { get; set; }
        public long MemberSince { get; set; }

        public override string ToString()
        {
            if (OptionalName == null)
            {
                return ScreenName;
            }
            else
            {
                return OptionalName + " (" + ScreenName + ")";
            }
        }
    }

    class AvatarObject
    {
        public string Large { get; set; }
        public string Medium { get; set; }
        public string Small { get; set; }
    }

    class HeaderObject
    {
        public string Web { get; set; }
        public string Mobile { get; set; }
        public string Retina { get; set; }
    }

    class UserFlagObject
    {
        public bool Admin { get; set; }
        public bool Moderator { get; set; }
        public bool Supporter { get; set; }
        public bool Blogger { get; set; }
        public bool Contributor { get; set; }
        public bool Translator { get; set; }
        public bool AppDeveloper { get; set; }
    }

    class UserBannedObject
    {
        public bool IsBanned { get; set; }
        public int Until { get; set; }
        public string Reason { get; set; }
    }
}
