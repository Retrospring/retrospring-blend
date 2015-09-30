using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace retrospring_win_universal.Data
{
    class FollowersObject
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public ObservableCollection<FollowObject> Followers { get; set; }
    }
}
