using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class FollowingObject
    {
        public int count { get; set; }
        public string next { get; set; }
        public FollowingUserObject[] followings { get; set; }
    }
}
