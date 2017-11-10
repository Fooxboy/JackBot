using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;

namespace Jack.Commands
{
    public static class When
    {
        public static void Start(Update.NewMessage message, string[] arguments)
        {
            string comment = "";

            for(int i=2; arguments.Length < i;i++)
            {
                comment += $"{arguments[i]} ";
            }
            var random = new Random();
            int date = random.Next(1, 29);
            int moth = random.Next(1, 12);
            int year = random.Next(2017, 2100);
            API.Message.Send(new Models.MessageSendParams
            {
                From = message.From,
                PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                Message = Files.Commands.When.Complete(date,moth,year,comment)
            });
        }
    }
}
