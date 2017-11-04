using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.API;

namespace Jack.Commands
{
    public static class Profile
    {
        public static void Start(Update.NewMessage message, string[] arguments) 
        {
            long? user_id;
            if(arguments.Length == 3)
            {
                var vk = Vk.Auth();
                user_id = vk.Utils.ResolveScreenName(arguments[3]).Id;
            }else
            {
                var vk = Vk.Auth();
                user_id = vk.Messages.GetById(System.Convert.ToUInt64(message.MessageId)).ForwardedMessages[0].FromId;
            }
            var user = new User(user_id.ToString());
            API.Message.Send(new Models.MessageSendParams
            {
                From = message.From,
                PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                Message = Files.Commands.Profile.Info(user)
            });
        }
    }
}
