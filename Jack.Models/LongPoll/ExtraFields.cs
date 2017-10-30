using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models.LongPoll
{
    public class ExtraFields
    {
        public string PeerId { get; set; }
        public string Time { get; set; }
        public string Text { get; set; }
        public Attach Attach { get; set; }
    }
}
