using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models
{
    public struct Mission
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public string By { get; set; }
        public int Type { get; set; }
        public string IdType { get; set; }
        public int Count { get; set; }
        public List<string> IdComplete { get; set; }
        public string TimeAdd { get; set; }
        public string Price { get; set; }
        public bool Complete { get; set; }
    }

    public struct Missions
    {
        public List<Mission> Mission { get; set; }
        public string Title { get; set; }
    }
}
