using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models.Yandex
{
    public class Translate
    {
        public int code { get; set; }
        public string lang { get; set; }
        public List<string> text { get; set; }
    }
}
