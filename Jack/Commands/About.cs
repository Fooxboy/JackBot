using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;

namespace Jack.Commands
{
    public static class About
    {
        public static void Start(Update.NewMessage message, string[] arguments) 
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
