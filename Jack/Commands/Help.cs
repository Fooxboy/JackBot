using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;

namespace Jack.Commands
{
    public static class Help
    {
        public static void Start(Update.NewMessage message, string[] arguments)
        {
            if(arguments.Length == 2)
            {
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = Jack.Files.Commands.Help.Main
                });
            }
            else
            {
                string command = arguments[2];
                //Вывод справки по командам.
                string help;
                switch(command.ToLower())
                {
                    case "оботе":
                        help = Files.Commands.About.Help;
                        break;
                    case "блок":
                        help = Files.Commands.SaveTitleChat.Help;
                        break;
                    case "бан":
                        help = Files.Commands.Ban.Help;
                        break;
                    case "разбан":
                        help = Files.Commands.UnBan.Help;
                        break;
                    case "казино":
                        help = Files.Commands.Casino.Help;
                        break;
                    case "профиль":
                        help = Files.Commands.Profile.Help;
                        break;
                    case "анблок":
                        help = "В разработке";
                        break;
                    default:
                        help = Files.Commands.Help.NotCommand;
                        break;
                }
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = help
                });
            }
        }
    }
}
