using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.LongPoll;
using Jack.API;

namespace Jack
{
    public class Render
    {
        public void Start(ResponseLongPoll model)
        {
            if(model.Event == Enums.LongPoll.Events.NewMessage)
            {
                var modelMessage = (Update.NewMessage)model.Message;
                NewMessage(modelMessage);

            } else if(model.Event == Enums.LongPoll.Events.DeleteMessage)
            {

            }else
            {
                //Ничего не делаем.
            }
        }

        private void NewMessage(Update.NewMessage message)
        {
            string[] arrayTextMessage = Split(message.ExtraFields.Text);

            string name = arrayTextMessage[0].ToLower();
            if((name == "джек")||(name == "jack")|| (name == "джек,"))
            {
                var user = new User(message.From);
                bool isUser = user.IsUser;
                if(isUser)
                {
                   if(!user.Ban)
                   {
                        //Отвечаем на сообщение. 
                        ChoiseCommand(message, arrayTextMessage);
                   }
                }else
                {
                    user.New(Enums.Jack.Privileges.User);
                }
            }
        }

        private void ChoiseCommand(Update.NewMessage message, string[] array)
        {
            if(array.Length != 1)
            {
                string command = array[1].ToLower();

                switch(command)
                {
                    case "оботе":
                        break;
                    case "помощь":
                        break;
                    case "команды":
                        break;
                }
            }
        }

        private string[] Split(string message)
        {
            string[] response = message.Split(' ');
            return response;
        }
    }
}
