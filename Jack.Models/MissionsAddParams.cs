using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models
{
    public struct MissionsAddParams
    {
        public Enums.Jack.Missions.Type type { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public string id { get; set; }
        public string user { get; set; }
        public string price { get; set; }
        public string code { get; set; }
    }
}
