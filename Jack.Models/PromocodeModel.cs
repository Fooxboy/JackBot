using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models
{
    public class PromocodeModel
    {
        public string Code { get; set; }
        public Enums.Models.TypePromocode Type { get; set; }
        public object Value { get; set; }
    }
}
