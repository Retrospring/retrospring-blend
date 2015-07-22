using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class UserObject
    {
        public int id { get; set; }
        public string screen_name { get; set; }
        public string display_name { get; set; }
        public AvatarObject avatar { get; set; }
        public HeaderObject header { get; set; }
        public string motivation_header { get; set; }
        public string website { get; set; }
        public string location { get; set; }
        public string bio { get; set; }
        public UserFlagsObject flags { get; set; }
        public UserBannedObject banned { get; set; }
        public string locale { get; set; }
        //todo
    }

    class AvatarObject
    {

    }

    class HeaderObject
    {

    }

    class UserFlagsObject
    {

    }

    class UserBannedObject
    {

    }
}
