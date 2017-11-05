using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.API;

namespace Jack.Commands
{
    public static class UnSaveTitleChat
    {
        public static void Start(Update.NewMessage message, string[] arguments)
        {
            string text;

            var user = new User(message.From);

            if(user.Privileges != Enums.Jack.Privileges.User)
            {
                var chat = new Chat(API.Convert.PeerIdToChatId(message.ExtraFields.PeerId).ToString());
                if(chat.Is)
                {
                    var getchat = Vk.Auth().Messages.GetChat(API.Convert.PeerIdToChatId(message.ExtraFields.PeerId));

                    if (message.From == chat.Admin || message.From == getchat.AdminId.ToString())
                    {
                        if (chat.Block)
                        {
                            chat.Block = false;
                            text = Files.Commands.UnSaveTitleChat.Ready;
                        }else
                        {
                            text = Files.Commands.UnSaveTitleChat.TitleNotBlocked;
                        }
                    }else
                    {
                        text = Files.Commands.UnSaveTitleChat.NoAccessAdmin;
                    }      
                }else
                {
                    text = Files.Commands.UnSaveTitleChat.TitleNotBlocked;
                }
            }else
            {
                text = Files.Commands.UnSaveTitleChat.NoAccessPrivileges;
            }
            API.Message.Send(new Models.MessageSendParams
            {
                From = message.From,
                PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                Message = text
            });
        }
    }
}
