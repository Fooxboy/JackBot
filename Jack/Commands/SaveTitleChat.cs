using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.API;

namespace Jack.Commands
{
    public static class SaveTitleChat
    {
        public static void Start(Update.NewMessage message, string[] arguments)
        {
            User user = new User(message.From);
            if(user.Privileges != Enums.Jack.Privileges.User)
            {
                //var getchat = Vk.Auth().Messages.GetChat();
                if (message.Type == Enums.LongPoll.TypeMessage.Chat)
                {
                    string chatId = message.ExtraFields.PeerId;
                    Chat chat = new Chat(chatId);

                    if (!chat.Is)
                    {
                        chat.New(message.From, arguments[2]);
                    } else
                    {
                        chat.Name = arguments[2];
                    }

                    
                }
            } 
        }
    }
}
