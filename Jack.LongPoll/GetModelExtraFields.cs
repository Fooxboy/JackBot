using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Jack.Models.LongPoll;

namespace Jack.LongPoll
{
    public static class GetModelExtraFields
    {
        public static ExtraFields Start(List<object> LongPoll)
        {
            var model = new ExtraFields();

            model.PeerId = LongPoll[3].ToString();
            model.Time = LongPoll[4].ToString();
            model.Text = LongPoll[5].ToString();
            var type_attach = (JObject)LongPoll[6];
            model.Attach = type_attach.ToObject<Attach>();

            return model;
        }
    }
}
