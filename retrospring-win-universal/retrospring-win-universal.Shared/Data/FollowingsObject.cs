using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace retrospring_win_universal.Data
{
    class FollowingsObject
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public ObservableCollection<FollowObject> Followings { get; set; }
    }
}
