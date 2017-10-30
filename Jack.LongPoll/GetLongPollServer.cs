using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Jack.Models.LongPoll;

namespace Jack.LongPoll
{
    public class GetLongPollServer
    {
        public Jack.Models.LongPoll.GetLongPollServer Start()
        {
            WebClient client = new WebClient();
            const string token = "bfa9879d97d107fad8968a8ec0e521ee1981be66a3f3c82c13976a9a6ebedf7fa18bc7f1d16f40a346b56";
            var url = $"https://api.vk.com/method/messages.getLongPollServer?lp_version=2&access_token={token}&v=5.68";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            var model = JsonConvert.DeserializeObject<Jack.Models.LongPoll.GetLongPollServer>(json);
            return model;
        }
    }
}
