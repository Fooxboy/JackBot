﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Jack.LongPoll
{
    public class GetJsonLongPoll
    {
        public string Key;
        public string Ts;
        public string Server;

        public string Start()
        {
            WebClient client = new WebClient();

            Console.WriteLine($"KEY {Key}  TS {Ts} Server {Server}");

            string url = $"https://{Server}?act=a_check&key={Key}&ts={Ts}&wait=25&mode=2&version=2";
            Console.WriteLine($"Full URL: {url}");
            client.Encoding = Encoding.UTF8;
            string json = client.DownloadString(url);
            return json;
        }
    }
}
