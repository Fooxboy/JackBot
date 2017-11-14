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
            Console.WriteLine("Старт");
            SetKeyAndServer();

            Console.WriteLine("Перед циклом");
            while (true)
            {
                Console.WriteLine("Цикл");
                var response = Main();
                return response;
            } 
        }

        private void SetKeyAndServer()
        {
            Console.WriteLine("УстановкаКЕЙиСЕРВЕР");
            var longPollServer = new GetLongPollServer();
            Console.WriteLine("ПОлучение модели");
            var model = longPollServer.Start();
            Console.WriteLine("Установка кей сервер и т.п");
            key = model.key;
            server = model.server;
            ts = model.ts;
            Console.WriteLine($"кей сервер хуй {key} {server} {ts}");

            Console.WriteLine($"кей сервер с модели {model.key}, {model.server}, {model.ts}");
        }

        private ResponseLongPoll Main()
        {
            //Console.WriteLine("Модель респ");
            var MainModel = new ResponseLongPoll();

            Console.WriteLine($"кей серер ещё раз: {server} {key} {ts}");
            GetJsonLongPoll objectJson = new GetJsonLongPoll()
            {
                Server = server,
                Key = key,
                Ts = ts
            };

            Console.WriteLine("Получение дсон лонг пулла.");
            string json = objectJson.Start();

            Console.WriteLine("Обработка ошибок.. и т.д");
            RootLongPoll objectLongPoll = null;
            try
            {
                objectLongPoll = JsonConvert.DeserializeObject<RootLongPoll>(json);
            }catch
            {
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
                        var codeStr = (string)LongPoll[i][0];
                        int code = Int32.Parse(codeStr);
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
