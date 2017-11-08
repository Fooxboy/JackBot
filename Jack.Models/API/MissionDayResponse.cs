using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models.API
{
    public class MissionDayResponse
    {
        public Enums.API.MissionDayType Type { get; set; }
        public string Word { get; set; }
    }
}
