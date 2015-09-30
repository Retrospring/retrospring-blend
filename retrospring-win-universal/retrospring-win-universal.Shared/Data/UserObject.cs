using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class UserObject
    {
        protected UserObject()
        {
            //for AnonymousUserObject and fromDynamic-method
        }

        /// <summary>
        /// Constructor of the UserObject.
        /// Contains all arguments the SlimUserObject always has, so those have to be set.
        /// </summary>
        public UserObject(int id, string screen_name, string display_name, string def_avatar, string def_header, UserFlagObject flags, bool banned, bool allow_stranger_answers)
        {
            Id = id;
            ScreenName = screen_name;
            OptionalName = display_name;
            Avatar = new AvatarObject(def_avatar);
            Header = new HeaderObject(def_header);
            Flags = flags;
            Banned = new UserBannedObject(banned);
            AllowStrangerAnswers = allow_stranger_answers;
        }

        public static UserObject fromDynamic(dynamic userData)
        {
            UserObject user = fromDynamicSlim(userData);

            //id, screen_name, display_name set in slim
            user.Avatar = new AvatarObject()
            {
                Large = userData.avatar.large,
                Medium = userData.avatar.medium,
                Small = userData.avatar.small
            };
            user.Header = new HeaderObject()
            {
                Web = userData.header.web,
                Mobile = userData.header.mobile,
                Retina = userData.header.retina
            };
            user.MotivationHeader = userData.motivation_header;
            user.Website = userData.website;
            user.Location = userData.location;
            user.Bio = userData.bio;
            //flags set in slim
            user.Banned = new UserBannedObject()
            {
                IsBanned = userData.banned.banned,
                Until = userData.banned.until,
                Reason = userData.banned.reason
            };
            user.Locale = userData.locale;
            user.FriendCount = userData.friend_count;
            user.FollowerCount = userData.follower_count;
            user.QuestionCount = userData.question_count;
            user.AnswerCount = userData.answer_count;
            user.CommentCount = userData.comment_count;
            user.SmileCount = userData.smile_count;
            user.CommentSmileCount = userData.comment_smile_count;
            user.AllowAnonymousQuestions = userData.allow_anonymous_questions;
            //stranger answers set in slim
            user.MemberSince = userData.member_since;

            return user;
        }

        public static UserObject fromDynamicSlim(dynamic userData)
        {
            if (userData == null) return null;

            UserObject user = new UserObject()
            {
                Id = userData.id,
                ScreenName = userData.screen_name,
                OptionalName = userData.display_name,
                Avatar = new AvatarObject((string) userData.avatar),
                Header = new HeaderObject((string) userData.header),
                Flags = UserFlagObject.fromDynamic(userData.flags),
                Banned = new UserBannedObject((bool) userData.banned),
                AllowStrangerAnswers = userData.privacy_allow_stranger_answers
            };

            return user;
        }

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

    class AnonymousUserObject : UserObject
    {
        public AnonymousUserObject()
        {
            Id = -1;
            ScreenName = "Anonymous Coward";
        }
    }

    class AvatarObject
    {
        public AvatarObject()
        {
            //empty
        }

        public AvatarObject(string defaultVal)
        {
            Medium = defaultVal;
        }

        public string Large { get; set; }
        public string Medium { get; set; }
        public string Small { get; set; }
    }

    class HeaderObject
    {
        public HeaderObject()
        {
            //empty
        }

        public HeaderObject(string defaultVal)
        {
            Web = defaultVal;
        }

        public string Web { get; set; }
        public string Mobile { get; set; }
        public string Retina { get; set; }
    }

    class UserFlagObject
    {
        public UserFlagObject()
        {
            //empty
        }

        public UserFlagObject(bool admin, bool mod, bool sup, bool blog, bool contr, bool trans, bool app_dev)
        {
            Admin = admin;
            Moderator = mod;
            Supporter = sup;
            Blogger = blog;
            Contributor = contr;
            Translator = trans;
            AppDeveloper = app_dev;
        }

        public static UserFlagObject fromDynamic(dynamic userflagData)
        {
            UserFlagObject flags = new UserFlagObject()
            {
                Admin = userflagData.admin,
                Moderator = userflagData.moderator,
                Supporter = userflagData.supporter,
                Blogger = userflagData.blogger,
                Contributor = userflagData.contributor,
                Translator = userflagData.translator,
                AppDeveloper = userflagData.app_developer
            };

            return flags;
        }

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
        public UserBannedObject()
        {
            //empty
        }

        public UserBannedObject(bool banned)
        {
            IsBanned = banned;
            Until = -1;
        }

        public bool IsBanned { get; set; }
        public int Until { get; set; }
        public string Reason { get; set; }
    }
}
