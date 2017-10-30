using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models.LongPoll
{
    public class RootLongPoll
    {
        public string ts { get; set; }
        public List<List<object>> updates { get; set; }   
    }
}
