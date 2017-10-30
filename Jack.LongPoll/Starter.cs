using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Jack.LongPoll
{
    public class Starter
    {
        string key = "";
        string server = "";
        string ts = "";

        public void Start()
        {
            if((key == "")&(server == ""))
            {
                var longPollServer = new GetLongPollServer();
                var model = longPollServer.Start();
                key = model.key;
                server = model.server;
                ts = model.ts;
            }

            while(true)
            {
                Main();
            }
        }

        private void Main()
        {
            GetJsonLongPoll objectJson = new GetJsonLongPoll()
            {
                Server = server,
                Key = key,
                Ts = ts
            };

            string json = objectJson.Start();
        }
    }

}
