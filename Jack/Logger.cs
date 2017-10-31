using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.API;
using Jack.LongPoll;

namespace Jack 
{
    public static class Logger
    {
        public static void NewEvent(ResponseLongPoll model)
        {
            if(model.Event == Enums.LongPoll.Events.NewMessage)
            {
                var message = (Update.NewMessage)model.Message;
            }
        }

        private static void NewMessage(Update.NewMessage message)
        {
            var user = new User(message.From);
            string name = "Неизвестный";
            if(user.IsUser)
            {
                name = user.Name;
            }

            string text =  $"[{DateTime.Now}] {name} >> {message.ExtraFields.Text} ";
            Console.WriteLine(text);
        }
    }
}
