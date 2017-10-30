using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models.LongPoll
{
    public class Error
    {
        public string falied { get; set; }
        public string ts { get; set; }
        public int min_version { get; set; }
        public int max_version { get; set; }
    }
}
