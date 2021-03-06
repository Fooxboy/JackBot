using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.API;
using Jack.Interfaces;

namespace Jack.Commands
{
    public class Profile:ICommand
    {
        public string Name => "профиль";
        public string Help => "помощь";

        public void Execute(Update.NewMessage message, string[] arguments) 
        {
            long? user_id;
            if(arguments.Length == 3)
            {
                var vk = Vk.Auth();
                user_id = vk.Utils.ResolveScreenName(arguments[2]).Id;
            }else
            {
                var vk = Vk.Auth();
                user_id = vk.Messages.GetById(System.Convert.ToUInt64(message.MessageId)).ForwardedMessages[0].FromId;
            }
            var user = new User(user_id.ToString());

            if(user.IsUser)
            {
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = Files.Commands.Profile.Info(user)
                });
            }else
            {
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = Files.Commands.Profile.NoUser
                });
            }  
        }
    }
}
