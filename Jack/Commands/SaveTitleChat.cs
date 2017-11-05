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
                if (message.Type == Enums.LongPoll.TypeMessage.Chat)
                {
                    var getchat = Vk.Auth().Messages.GetChat(API.Convert.PeerIdToChatId(message.ExtraFields.PeerId));
                    long chatId = API.Convert.PeerIdToChatId(message.ExtraFields.PeerId);

                    Chat chat = new Chat(chatId.ToString());

                    if (!chat.Is)
                    {
                        chat.New(message.From, getchat.Title);
                    } 
                    
                    if(chat.Block)
                    {
                        API.Message.Send(new Models.MessageSendParams
                        {
                            From = message.From,
                            PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                            Message = Files.Commands.SaveTitleChat.TitleBlocked
                        });
                    }
                    else
                    {
                        if ((message.From == getchat.AdminId.ToString()) || (message.From == chat.Admin))
                        {
                            var title = "title";
                            try
                            {
                                title = arguments[2];
                            }
                            catch
                            {
                                title = getchat.Title;
                            }
                            chat.Name = title;

                            API.Message.Send(new Models.MessageSendParams
                            {
                                From = message.From,
                                PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                                Message = Files.Commands.SaveTitleChat.Compete
                            });
                        }
                        else
                        {
                            API.Message.Send(new Models.MessageSendParams
                            {
                                From = message.From,
                                PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                                Message = Files.Commands.SaveTitleChat.NoAdmin
                            });
                        }
                    }
                } else
                {
                    API.Message.Send(new Models.MessageSendParams
                    {
                        From = message.From,
                        PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                        Message = Files.Commands.SaveTitleChat.NoChat
                    });
                }
            }else
            {
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = Files.Commands.SaveTitleChat.NoAccess
                });
            }
        }

        public static void TriggerEditChat(Update.NewMessage message)
        {
            long chatId = API.Convert.PeerIdToChatId(message.ExtraFields.PeerId);

            Chat chat = new Chat(chatId.ToString());

            if(chat.Is)
            {
                var getchat = Vk.Auth().Messages.GetChat(API.Convert.PeerIdToChatId(message.ExtraFields.PeerId));
                string id = message.From;
                if (id != getchat.AdminId.ToString() || id != chat.Admin)
                {
                    //Нельзя изменить типа
                    Vk.Auth().Messages.EditChat(chatId, chat.Name);
                    API.Message.Send(new Models.MessageSendParams
                    {
                        From = message.From,
                        PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                        Message = Files.Commands.SaveTitleChat.NoEdit
                    });
                }
            }
        }
    }
}
