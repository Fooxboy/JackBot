using System;
using System.Collections.Generic;
using System.Text;
using xNet;
using Newtonsoft.Json;
using Jack.Models.LongPoll;

namespace Jack.LongPoll
{
    public  struct GetModelLongPoll
    {
        public static RootLongPoll Get(string Server, string Key, ulong Ts)
        {
            using(var client = new HttpRequest())
            {
                var response = client.Get($"https://{Server}?act=a_check&key={Key}&ts={Ts}&wait=25&mode=2&version=2");
                string json = response.ToString();
                var model = JsonConvert.DeserializeObject<RootLongPoll>(json);
                if (model.ts == null)
                {
                    throw new System.Exception("Какая-то ошибка");
                }
                return model;
            }
        }
    }
}
