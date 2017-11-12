using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.Interfaces;

namespace Jack.Commands
{
    public  class Casino : ICommand
    {
        public string Name => "Казино";
        public string Help => "Помощь";

        public void Execute(Update.NewMessage message, string[] arguments)
        {
            if(arguments.Length >= 3)
            {
               string command = arguments[2].ToLower();
               var user = new API.User(message.From);
                if(command == "ставка")
                {  
                    if(arguments.Length >= 4)
                    {
                        int countFoxs;
                        countFoxs = System.Convert.ToInt32(arguments[3]);
                        if (countFoxs < user.Foxs)
                        {
                            API.Message.Send(new Models.MessageSendParams
                            {
                                From = message.From,
                                PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                                Message = Files.Commands.Casino.NoFoxs
                            });
                        }
                        else
                        {
                            Random rand = new Random();
                            int i = rand.Next(10);

                            if (i == 2 || i == 4 || i == 6 || i == 8 || i == 10||i ==0)
                            {
                                int i2 = rand.Next(2);

                                if (i2 == 2 || i2 == 0)
                                {
                                    API.Message.Send(new Models.MessageSendParams
                                    {
                                        From = message.From,
                                        PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                                        Message = Files.Commands.Casino.Winner(countFoxs)
                                    });

                                    user.Foxs += countFoxs; 
                                }
                                else
                                {
                                    API.Message.Send(new Models.MessageSendParams
                                    {
                                        From = message.From,
                                        PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                                        Message = Files.Commands.Casino.Loser(countFoxs)
                                    });
                                }
                            }else
                            {
                                API.Message.Send(new Models.MessageSendParams
                                {
                                    From = message.From,
                                    PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                                    Message = Files.Commands.Casino.Loser(countFoxs)
                                });
                            }
                        }
                    }else
                    {
                        API.Message.Send(new Models.MessageSendParams
                        {
                            From = message.From,
                            PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                            Message = Files.Commands.Casino.NoArgFoxs
                        });
                    }

                }else if(command == "играть")
                {

                }
            }else
            {
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = Files.Commands.Casino.NoArgFoxs
                });
            }
        }
    }
}
