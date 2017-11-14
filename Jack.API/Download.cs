using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Jack.Enums;

namespace Jack.API
{
    public class Download
    {
        public static string Photo(Uri url, Enums.API.TypeDownload type)
        {
            using(var client = new WebClient())
            {
                string name = "";
                if(type == Enums.API.TypeDownload.Meme)
                {
                    name += "Meme_";
                }

                var random = new Random();
                int result = random.Next(1, 2345);
                name += result;
                name += @".jpg";
                client.DownloadFile(url, name);

                return name;
            }
        }
    }
}
