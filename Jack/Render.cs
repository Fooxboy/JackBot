using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.LongPoll;

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
            
        }
    }
}
