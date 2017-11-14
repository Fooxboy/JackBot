using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.Interfaces;

namespace Jack.Commands
{
    public class About :ICommand
    {
        public string Name => "Оботе";
        public string Help => "Помощь";

        public void Execute(Update.NewMessage message, string[] arguments) 
        {
            API.Message.Send(new Models.MessageSendParams
            {
                From = message.From,
                PeerId = Convert.ToInt64(message.ExtraFields.PeerId),
                Message = Jack.Files.Commands.About.Main()
            });
        }
    }
}
