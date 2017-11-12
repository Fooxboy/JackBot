using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.API;
using Jack.Interfaces;

namespace Jack.Commands
{
    public  class Nick :ICommand
    {
        public string Name => "Ник";
        public string Help => "Помощь";
        public void Execute(Update.NewMessage message, string[] arguments)
        {
            if(arguments.Length >= 3)
            {
                string command = arguments[2];
                switch (command.ToLower())
                {
                    case "изменить":
                        var messageId = System.Convert.ToUInt64(message.MessageId);
                        var vk = Vk.Auth();
                        var messagevk = vk.Messages.GetById(messageId);
                        string from;

                        if(messagevk.ForwardedMessages.Count == 0)
                        {
                            from = message.From;
                            Main(message, from, arguments);
                        }
                        else
                        {
                            var user = new User(message.From);
                            if(user.Privileges != Enums.Jack.Privileges.User || user.Privileges != Enums.Jack.Privileges.Vip)
                            {
                                int userFromPrivileges = (int)user.Privileges;
                                from = messagevk.ForwardedMessages[0].FromId.ToString();
                                var userFor = new User(from);
                                int userForPrivileges = (int)userFor.Privileges;

                                if(userFromPrivileges <= userForPrivileges)
                                {
                                    API.Message.Send(new Models.MessageSendParams
                                    {
                                        From = message.From,
                                        PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                                        Message = Files.Commands.Nick.NotPermissions
                                    });
                                }
                                else
                                {
                                    Main(message, from, arguments);
                                }                   
                            }
                            else
                            {
                                API.Message.Send(new Models.MessageSendParams
                                {
                                    From = message.From,
                                    PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                                    Message = Files.Commands.Nick.NotPrivileges
                                });
                            }
                        }       
                        break;
                    case "удалить":
                        Delete(message.From, message.ExtraFields.PeerId);
                        break;
                }
            }else
            {
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = Files.Commands.Nick.NotCommand
                });
            }
           
        }

        private static void Main(Update.NewMessage message, string from, string[] arguments)
        {
            if (arguments.Length >= 4)
            {
                Edit(arguments[3], from, message.ExtraFields.PeerId);
            }
            else
            {
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = Files.Commands.Nick.NotNewNick
                });
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
                Message = Files.Commands.Nick.Complete
            });
        }

        private static void Delete(string from, string peer_id)
        {
            var user = new User(from);
            var vk = Vk.Auth();
            var uservk = vk.Users.Get(from);
            user.Name = uservk.FirstName;
            API.Message.Send(new Models.MessageSendParams
            {
                From = from,
                PeerId = System.Convert.ToInt64(peer_id),
                Message = Files.Commands.Nick.CompleteDelete
            });
        }
    }
}
