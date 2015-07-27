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
        // avatars
        // headers
        public string Website { get; set; }
        public string Location { get; set; }
        public string Bio { get; set; }
        // flags
        public bool IsBanned { get; set; }
        // more banned info?
        public long MemberSince { get; set; }
    }
}
