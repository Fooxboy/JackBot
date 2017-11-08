using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;

namespace Jack.Commands
{
    public static class MissionDay
    {
        public static void Start(Update.NewMessage message, string[] arguments)
        {
            //TODO: Переписать костыли.
            string command = "-";
            try
            {
                command = arguments[2].ToLower();
            }catch
            {

            }
            //Ха, костыли.
            if(command == "-")
            {
                //не указали подкоманду.
            }else
            {
                if(command == "новый")
                {

                }else if(command == "разгадать")
                {

                }else
                {
                    //Ошибка.
                }
            }
        }

        private static void NewWord(string peer_id)
        {
            long chat_id = API.Convert.PeerIdToChatId(peer_id);
            var chat = new API.Chat(chat_id.ToString());

            if(!chat.Is)
            {
                chat.New();
            }

            if(chat.MissionDay.Type == Enums.API.MissionDayType.NoMissionToday)
            {

            }
        }

        private static void GuessWord()
        {

        }

        public static void Trigger()
        {

        }
    }
}
