using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models
{
    public class PhotoMessageUpload
    {
        public int server { get; set; }
        public string photo { get; set; }
        public string hash { get; set; }
    }
}
