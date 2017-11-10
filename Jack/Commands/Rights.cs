using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.API;
using Jack.Exception.Commands;

namespace Jack.Commands
{
    public static class Rights
    {
        public static void Start(Update.NewMessage message, string[] arguments)
        {
            string text;
            if(message.From == "308764786")
            {
                if(arguments.Length >= 3)
                {
                    string command = arguments[2];
                    var vk = Vk.Auth();
                    var messagevk = vk.Messages.GetById(System.Convert.ToUInt64(message.MessageId));

                    if(messagevk.ForwardedMessages.Count == 0)
                    {
                        text = Files.Commands.Rights.NotForwardMessage;
                    } else
                    {
                        if (arguments.Length >= 4)
                        {
                            var userId = messagevk.ForwardedMessages[0].FromId;
                            switch (command)
                            {
                                case "выдать":
                                    string privileges = arguments[3];
                                    try
                                    {
                                        text = Set(userId.ToString(), privileges);
                                    }catch(NoPrivilegesValue)
                                    {
                                        text = Files.Commands.Rights.NoPrivilegesValue;
                                    }
                                    break;
                                case "сбросить":
                                    text = Delete(userId.ToString());
                                    break;
                            }
                        }
                        else
                        {
                            text = Files.Commands.Rights.NoPrivileges;
                        }
                    }             
                }else
                {
                    text = Files.Commands.Rights.NoCommand;
                }
            }else
            {
                text = Files.Commands.Rights.NoAccess;
            }
        }

        private static string Set(string from, string privileges)
        {
            Enums.Jack.Privileges right;
            switch(privileges.ToLower())
            {
                case "vip":
                    right = Enums.Jack.Privileges.Vip;
                    break;
                case "premium":
                    right = Enums.Jack.Privileges.Premium;
                    break;
                case "diamond":
                    right = Enums.Jack.Privileges.Diamond;
                    break;
                case "insider":
                    right = Enums.Jack.Privileges.Insider;
                    break;
                case "user":
                    right = Enums.Jack.Privileges.User;
                    break;
                default:
                    throw new Jack.Exception.Commands.NoPrivilegesValue();
            }
            string text;
            var user = new User(from);
            if(user.IsUser)
            {
                user.Privileges = right;
                text = Files.Commands.Rights.Complete;
            }else
            {
                text = Files.Commands.Rights.NoUser;
            }

            return text;
        }

        private static string Delete(string user_id)
        {
            var user = new User(user_id);
            string text;
            if(user.IsUser)
            {
                user.Privileges = Enums.Jack.Privileges.User;
                text = Files.Commands.Rights.CompleteDelete;
            }else
            {
                text = Files.Commands.Rights.NoUser;
            }
            return text;
        }
    }
}
