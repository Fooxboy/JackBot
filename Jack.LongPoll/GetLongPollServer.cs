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
            string token = Files.Jack.Token;
            var url = $"https://api.vk.com/method/messages.getLongPollServer?lp_version=2&access_token={token}&v=5.68";
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            var model = JsonConvert.DeserializeObject<Jack.Models.LongPoll.GetLongPollServer>(json);
            return model;
        }
    }
}
