using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Jack.Models.LongPoll;

namespace Jack.Commands
{
    public static class Who
    {
        public static void Start(Update.NewMessage message, string[] arguments)
        {
            if(message.Type == Enums.LongPoll.TypeMessage.Chat)
            {
                long chat_id = API.Convert.PeerIdToChatId(message.ExtraFields.PeerId);
                var vk = Vk.Auth();
                var chatvk = vk.Messages.GetChat(chat_id);
                Collection<long> users = chatvk.Users;
                int count = users.Count;

                Random random = new Random();
                int i = random.Next(count);
                int index = i - 1;
                long id_user = users[index];

                string comment;
                try
                {
                    comment = arguments[2];
                }
                catch
                {
                    comment = "";
                }
                var uservk = vk.Users.Get(id_user);
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = Files.Commands.Who.Result(uservk.FirstName, comment)
                });
            }
            else
            {
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = Files.Commands.Who.IsNotChat
                });
            }
        }
    }
}
