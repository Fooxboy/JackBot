using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models.LongPoll
{
    public class Update
    {
        public class NewMessage
        {
            public string MessageId { get; set; }
            public string Flags { get; set; }
            public Enums.LongPoll.TypeMessage Type { get; set; }
            public string From { get; set; }
            public ExtraFields ExtraFields { get; set; }
        }
    }
}
