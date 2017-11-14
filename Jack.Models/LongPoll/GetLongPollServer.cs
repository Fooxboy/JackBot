using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models.LongPoll
{
    public class GetLongPollServer
    {
        public string key { get; set; }
        public string server { get; set; }
        public string ts { get; set; }
    }

    public class Response
    {
        public GetLongPollServer response { get; set; }
    }

   
}
