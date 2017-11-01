using System;
using System.Collections.Generic;
using Jack.Models.LongPoll;
using Newtonsoft.Json;
using Jack.Exception.LongPoll;

namespace Jack.LongPoll
{
    public class Starter
    {
        string key = "";
        string server = "";
        string ts = "";

        public ResponseLongPoll Start()
        {
            SetKeyAndServer();

            while(true)
            {
                var response = Main();
                return response;
            } 
        }

        private void SetKeyAndServer()
        {
            var longPollServer = new GetLongPollServer();
            var model = longPollServer.Start();
            key = model.key;
            server = model.server;
            ts = model.ts;
        }

        private ResponseLongPoll Main()
        {
            var MainModel = new ResponseLongPoll();

            GetJsonLongPoll objectJson = new GetJsonLongPoll()
            {
                Server = server,
                Key = key,
                Ts = ts
            };

            string json = objectJson.Start();

            RootLongPoll objectLongPoll = null;
            try
            {
                objectLongPoll = JsonConvert.DeserializeObject<RootLongPoll>(json);
            }catch
            {
                //TODO: Сделать обработку ошибок лонг пулла.
                SetKeyAndServer();
            }

            if(objectLongPoll != null)
            {
                ts = objectLongPoll.ts;
                List<List<object>> LongPoll = objectLongPoll.updates;
                if (LongPoll.Count != 0)
                {
                    for (int i = 0; i < LongPoll.Count; i++)
                    {
                        
                        int code = Convert.ToInt32((string)LongPoll[i][0]);
                        try
                        {
                            ResponseModelLongPoll ModelLongPoll = GetModelLongPoll.Start(code.ToString(), LongPoll[i]);

                            switch (code)
                            {
                                case 4:
                                    var model = (Update.NewMessage)ModelLongPoll.Result;

                                    if (model.ExtraFields.Attach.from == null)
                                    {
                                        //Сообщение в лс.
                                        model.From = model.ExtraFields.PeerId;
                                        model.Type = Enums.LongPoll.TypeMessage.Dialog;
                                    }
                                    else
                                    {
                                        //Сообщение в беседе.
                                        model.From = model.ExtraFields.Attach.from;
                                        model.Type = Enums.LongPoll.TypeMessage.Chat;
                                    }

                                    var response = new ResponseLongPoll();
                                    response.Event = Enums.LongPoll.Events.NewMessage;
                                    response.Message = model;

                                    MainModel = response;
                                    break;
                                default:
                                    throw new CodeNotFound();
                            }
                        }
                        catch (CodeNotFound)
                        {

                        }
                    }
                }
            }
            return MainModel;
        }
    }

    public class ResponseLongPoll
    {
        public Enums.LongPoll.Events Event { get; set; }
        public object Message { get;set; }
    }

}
