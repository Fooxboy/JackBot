using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models
{
    public struct MissionsAddParams
    {
        public string Title { get; set; }
        public string By { get; set; }
        public Enums.Jack.Missions.Type Type { get; set; }
        public string IdType { get; set; }
        public int Count { get; set; }
        public List<string> IdComplete { get; set; }
        public string TimeAdd { get; set; }
        public string Price { get; set; }
    }
}
