using System;
using System.Collections.Generic;
using System.Text;
using Jack.API;
using Jack.Models.LongPoll;
using Jack.Models.API;
using Jack.Interfaces;

namespace Jack.Commands
{
    public class Ban : ICommand
    {
        public string Name => "Бан";
        public string Help => "Помощь";

        public void Execute(Update.NewMessage message, string[] arguments)
        {
            var userFrom = new User(message.From);
            if(userFrom.Privileges != Enums.Jack.Privileges.User)
            {
                long? user_id;
                bool forId = false;
                if (arguments.Length >= 3)
                {
                    var vk = Vk.Auth();
                    user_id = vk.Utils.ResolveScreenName(arguments[2]).Id;
                    forId = true;
                }
                else
                {
                    var vk = Vk.Auth();
                    user_id = vk.Messages.GetById(System.Convert.ToUInt64(message.MessageId)).ForwardedMessages[0].FromId;
                }
                var user = new User(user_id.ToString());

                if((int)userFrom.Privileges >= (int)user.Privileges)
                {
                    if (forId)
                    {
                        if (arguments.Length >= 4)
                        {
                            string time = arguments[3];
                            user.Ban = true;
                            int times = RunBan(user_id.ToString(), time, message.From);
                            API.Message.Send(new Models.MessageSendParams
                            {
                                From = message.From,
                                PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                                Message = Files.Commands.Ban.Compete(user, times.ToString())
                            });
                        }
                        else
                        {
                            API.Message.Send(new Models.MessageSendParams
                            {
                                From = message.From,
                                PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                                Message = Files.Commands.Ban.NoTime
                            });
                        }
                    }
                    else
                    {
                        if (arguments.Length >= 3)
                        {
                            string time = arguments[2];
                            user.Ban = true;
                            int times = RunBan(user_id.ToString(), time, message.From);

                            API.Message.Send(new Models.MessageSendParams
                            {
                                From = message.From,
                                PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                                Message = Files.Commands.Ban.Compete(user, times.ToString())
                            });
                        }
                        else
                        {
                            API.Message.Send(new Models.MessageSendParams
                            {
                                From = message.From,
                                PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                                Message = Files.Commands.Ban.NoTime
                            });
                        }
                    }
                }else
                {
                    API.Message.Send(new Models.MessageSendParams
                    {
                        From = message.From,
                        PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                        Message = Files.Commands.Ban.NoBanThisPrivileges
                    });
                }            
            }else
            {
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = Files.Commands.Ban.NoAccess
                });
            }       
        }

        public static int RunBan(string id, string time, string from_id )
        {
            int timeInt = System.Convert.ToInt32(time);

            API.Ban.New(new NewBansParams
            {
                time = timeInt.ToString(),
                id = id,
                from = from_id,
                count = "1"
            });
            return timeInt;   
        }
    }
}
