using System;
using System.Collections.Generic;
using System.Text;
using Jack.API;
using Newtonsoft.Json.Linq;
using Jack.Models.LongPoll;
using Jack.Render;

namespace Jack.LongPoll
{
    public class Starter
    {
        private string Key = null;
        private string Server = null;
        private ulong Ts = 0;

        public void Start()
        {
            if (Key == null || Server == null || Ts == 0)
            {
                SetKetServerTs();
            }
            var model = GetModelLongPoll.Get(Server, Key, Ts);
            Ts = UInt64.Parse(model.ts);
            var updates = model.updates;
            foreach(var update in updates)
            {
                if(update.Count !=0)
                {
                    int code = (int)update[0];
                    if(code == 4)
                    {
                        var message = new Update.NewMessage();
                        message.MessageId = (string)update[1];
                        message.Flags = (string)update[2];
                        var ExtraFields = new ExtraFields();
                        ExtraFields.PeerId = (string)update[3];
                        ExtraFields.Time = (string)update[4];
                        ExtraFields.Text = (string)update[5];
                        var type_attach = (JObject)update[6];
                        ExtraFields.Attach = type_attach.ToObject<Attach>();
                        message.ExtraFields = ExtraFields;

                        if (message.ExtraFields.Attach.from == null)
                        {
                            //Сообщение в лс.
                            message.From = message.ExtraFields.PeerId;
                            message.Type = Enums.LongPoll.TypeMessage.Dialog;
                        }
                        else
                        {
                            //Сообщение в беседе.
                            message.From = message.ExtraFields.Attach.from;
                            message.Type = Enums.LongPoll.TypeMessage.Chat;
                        }


                        //Выполнение кода дальше...

                        var render = new Jack.Render.Command();
                        render.Execute(message);
                    }
                }   
            }

        }

        private void SetKetServerTs()
        {
            var vk = Vk.Auth();
            var modelLongPollServer = vk.Messages.GetLongPollServer();
            Key = modelLongPollServer.Key;
            Server = modelLongPollServer.Server;
            Ts = modelLongPollServer.Ts;
        }
    }
}
