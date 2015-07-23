using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class UserObject
    {
        public int id { get; set; }
        public string screen_name { get; set; }
        public string display_name { get; set; } //optional
        public AvatarObject avatar { get; set; }
        public HeaderObject header { get; set; }
        public string motivation_header { get; set; }
        public string website { get; set; }
        public string location { get; set; }
        public string bio { get; set; }
        public UserFlagsObject flags { get; set; }
        public UserBannedObject banned { get; set; }
        public string locale { get; set; }
        public int friend_count { get; set; }
        public int follower_count { get; set; }
        public int question_count { get; set; }
        public int answer_count { get; set; }
        public int comment_count { get; set; }
        public int smile_count { get; set; }
        public int comment_smile_count { get; set; }
        public bool allow_anonymous_questions { get; set; }
        public bool allow_stranger_answers { get; set; }
        public long member_since { get; set; }

        public TrimmedUserObject toTrimmedUser()
        {
            TrimmedUserObject tuo = new TrimmedUserObject();
            tuo.id = id;
            tuo.screen_name = screen_name;
            tuo.display_name = display_name;
            tuo.avatar = avatar.medium;
            tuo.header = header.web;
            tuo.flags = flags;
            tuo.banned = banned.banned;
            tuo.privacy_allow_stranger_answers = allow_stranger_answers; //???

            return tuo;
        }

        public override string ToString()
        {
            return display_name != null ? display_name : screen_name;
        }
    }

    class AnonymousUserObject : UserObject
    {
        public AnonymousUserObject()
        {
            id = -1;
            screen_name = "Anonymous";
            //TODO: avatar, header to default
        }
    }

    class TrimmedUserObject
    {
        public int id { get; set; }
        public string screen_name { get; set; }
        public string display_name { get; set; } //optional
        public string avatar { get; set; }
        public string header { get; set; }
        public UserFlagsObject flags { get; set; }
        public bool banned { get; set; }
        public bool privacy_allow_stranger_answers { get; set; }

        public override string ToString()
        {
            return display_name != null ? display_name : screen_name;
        }
    }

    class FollowingUserObject
    {
        public TrimmedUserObject user { get; set; }
        public long following_since { get; set; }

        public override string ToString()
        {
            return user.ToString();
        }
    }

    class AvatarObject
    {
        public string large { get; set; }
        public string medium { get; set; }
        public string small { get; set; }
    }

    class HeaderObject
    {
        public string web { get; set; }
        public string mobile { get; set; }
        public string retina { get; set; }
    }

    class UserFlagsObject
    {
        public bool admin { get; set; }
        public bool moderator { get; set; }
        public bool supporter { get; set; }
        public bool blogger { get; set; }
        public bool contributor { get; set; }
        public bool translator { get; set; }
        public bool app_developer { get; set; }
    }

    class UserBannedObject
    {
        public bool banned { get; set; }
        public int until { get; set; }
        public string reason { get; set; }
    }
}
