using System;
using System.Collections.Generic;
using System.Text;

namespace retrospring_win_universal.Data
{
    class ApiResultContainer<T>
    {
        public bool success { get; set; }
        public int code { get; set; }
        public T result { get; set; }

        //in case of an error
        public string message { get; set; }
        public string[] trace { get; set; }
        public string exception { get; set; }
    }
}
