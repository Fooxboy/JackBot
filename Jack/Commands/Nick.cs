using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.API;

namespace Jack.Commands
{
    public static class Nick
    {
        public static void Start(Update.NewMessage message, string[] arguments)
        {
            string command;
            
            switch(command.ToLower())
            {
                case "изменить":
                    var messageId = System.Convert.ToUInt64(message.MessageId);
                    var vk = Vk.Auth();
                    var messagevk = vk.Messages.GetById(messageId);
                    string from;
                    if(messagevk.ForwardedMessages.Count == 0)
                    {
                        from = message.From;
                    }else
                    {
                        from = messagevk.ForwardedMessages[0].FromId.ToString();
                    }
                    Edit(arguments[3], from, message.ExtraFields.PeerId);
                    break;
                case "удалить":
                    break;
            }
        }

        private static void Edit(string newNick, string from, string peer_id)
        {
            var user = new User(from);
            user.Name = newNick;
            API.Message.Send(new Models.MessageSendParams
            {
                From = from,
                PeerId =  System.Convert.ToInt64(peer_id),
                Message = Jack.Files.Commands.Nick.Complete
            });
        }
    }
}
