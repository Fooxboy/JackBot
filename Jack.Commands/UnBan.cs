using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.API;
using Jack.Interfaces;

namespace Jack.Commands
{
    public class UnBan: ICommand
    {
        public string Name => "разбан";
        public string Help => "помощь";

        public void Execute(Update.NewMessage message, string[] arguments)
        {
            var userFrom = new User(message.From);
            if(userFrom.Privileges != Enums.Jack.Privileges.User || userFrom.Privileges != Enums.Jack.Privileges.Vip)
            {
                long? user_id;
                if (arguments.Length >= 3)
                {
                    var vk = Vk.Auth();
                    user_id = vk.Utils.ResolveScreenName(arguments[2]).Id;
                }
                else
                {
                    var vk = Vk.Auth();
                    if(vk.Messages.GetById(System.Convert.ToUInt64(message.MessageId)).ForwardedMessages.Count == 0)
                    {
                        API.Message.Send(new Models.MessageSendParams
                        {
                            From = message.From,
                            PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                            Message = Files.Commands.UnBan.NoArgumentsId
                        });
                    }
                    else
                    {
                        user_id = vk.Messages.GetById(System.Convert.ToUInt64(message.MessageId)).ForwardedMessages[0].FromId;
                        var user = new User(user_id.ToString());
                        user.Ban = false;
                        UnBanRun(user_id.ToString());
                    }
                }              
            }
            else
            {
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = Files.Commands.UnBan.NoAccessPrivileges
                });
            }
        }

        public static void UnBanRun(string id)
        {
            API.Ban.Delete(id);
        }
    }
}
