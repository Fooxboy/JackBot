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
            Console.WriteLine("Класс модели");

            WebClient client = new WebClient();
            string token = Files.Jack.Token;
            var url = $"https://api.vk.com/method/messages.getLongPollServer?lp_version=2&access_token={token}&v=5.68";
            Console.WriteLine($"Фулл юрл: {url}");
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            Console.WriteLine($"json: {json}");
            var model = JsonConvert.DeserializeObject<Models.LongPoll.Response>(json).response;
            if(model.server == null)
            {
                Console.WriteLine("Ошибка");
                throw new System.Exception("ааа");
                
            }
            Console.WriteLine("ОК");
            return model;
        }
    }
}
