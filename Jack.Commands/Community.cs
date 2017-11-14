using System;
using System.Collections.Generic;
using System.Text;
using Jack.Interfaces;
using Jack.Models.LongPoll;
using Jack.Exception.Commands;
using static Jack.Files.Commands.Community;

namespace Jack.Commands
{
    public class Community : ICommand
    {
        public string Name => "Сообщество";
        public string Help => "Хелп";

        public void Execute(Update.NewMessage message, string[] arguments)
        {
            //throw new CommandIsNotWorked();
            string text;
            if(arguments.Length  >= 3)
            {
                string command = arguments[2];

                switch(command.ToLower())
                {
                    case "создать":
                        text = Create(message.From, arguments);
                        break;
                    case "присоединиться":
                        text = Join(message.From, arguments);
                        break;
                    case "покинуть":
                        text = Leave(message.From);
                        break;
                    case "профиль":
                        text = Profile(message.From);
                        break;
                    default:
                        text = NotCommand;
                        break;
                }
            }else
            {
                text = NoCommand;
            }

            API.Message.Send(new Models.MessageSendParams
            {
                From = message.From,
                PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                Message = text
            });
        }

        private string Profile(string from)
        {
            string text;
            var user = new API.User(from);
            if(user.Community != "0")
            {
                var community = new API.Communities(user.Community);
                text = Files.Commands.Community.Profile(community);
            }else
            {
                text = NoCommunity;
            }
           
            return text;
        }

        private string Leave(string from)
        {
            string text = "Ошибка.";
            var user = new API.User(from);
            string id;
            id = user.Community;

            var communities = new API.Communities(id);
                if(communities.Is)
                {
                    if(user.Community != "0")
                    {
                        user.Community = "0";
                        List<string> members = communities.Members;
                        members.Remove(from);
                        communities.Members = members;
                    text = ReadyLeave;
                    }
                    else
                    {
                    text = NoCommunity;
                    }       
                }
                else
                {
                text = CommunityNotFound;
                }

            return text;
        }

        private string Join(string from, string[] array)
        {
            string text = "ошибка.";

            if(array.Length >= 4)
            {
                string id = array[3];
                var communities = new API.Communities(id);
                if(communities.Is)
                {
                    var user = new API.User(from);
                    if(user.Community == "0")
                    {
                        user.Community = id;
                        List<string> members = communities.Members;
                        members.Add(from);
                        communities.Members = members;
                        text = ReadyJoin;
                    }else
                    {
                        text = UserIsCommunity;
                    }
                }
                else
                {
                    text = CommunityNotFound;
                }
            }else
            {
                text = NoIdCommunity;
            }
            return text;

        }

        private string Create(string from, string[] array)
        {
            string text= "ошибка.";

            if(array.Length >= 4)
            {
                var user = new API.User(from);
                if(user.Community == "0")
                {
                    string name = array[3];
                    //генерация id
                    string id = "1";
                    API.Communities.New(id, name, from);
                    text = ReadyCreate;
                }else
                {
                    text = UserIsCommunity;
                }
            }
            else
            {
                text = NoNameCommunity;
            }
            return text;
        }
    }
}
