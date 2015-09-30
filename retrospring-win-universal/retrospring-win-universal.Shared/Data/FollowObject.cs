using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class FollowObject
    {
        public static FollowObject fromDynamic(dynamic folData)
        {
            FollowObject fol = new FollowObject()
            {
                User = UserObject.fromDynamicSlim(folData.user),
                FollowingSince = folData.following_since
            };

            return fol;
        }

        public UserObject User { get; set; }
        public long FollowingSince { get; set; }
    }
}
