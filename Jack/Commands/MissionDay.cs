using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;
using Jack.Interfaces;

namespace Jack.Commands
{
    public class MissionDay: ICommand
    {
        public string Name => "ЕЗ";
        public string Help => "помощь";

        public void Execute(Update.NewMessage message, string[] arguments)
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
                API.Message.Send(new Models.MessageSendParams
                {
                    From = message.From,
                    PeerId = Convert.ToInt64(message.ExtraFields.PeerId),
                    Message = Files.Commands.MissionDay.GameStarted
                });
            }
            else
            {
                if(command == "новый")
                {
                    NewWord(message.ExtraFields.PeerId);
                }else if(command == "разгадать")
                {
                    GuessWord(message.ExtraFields.PeerId, arguments);

                }else if(command == "начать")
                {
                    long chat_id = API.Convert.PeerIdToChatId(message.ExtraFields.PeerId);
                    Trigger(chat_id);
                }
                else
                {
                    throw new System.Exception("Ошибка.");
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

            if(chat.MissionDay.Type == Enums.API.MissionDayType.NoStartGame)
            {
                Trigger(chat_id);

            }else if(chat.MissionDay.Type == Enums.API.MissionDayType.NoMissionToday)
            {
                Trigger(chat_id);
            }else if(chat.MissionDay.Type == Enums.API.MissionDayType.GuessMissionToday)
            {
                Trigger(chat_id);
            }else if(chat.MissionDay.Type == Enums.API.MissionDayType.WordMission)
            {
                API.Message.Send(new Models.MessageSendParams
                {
                    PeerId = Convert.ToInt64(peer_id),
                    Message = Files.Commands.MissionDay.GameStarted
                });
            }
        }

        private static void GuessWord(string peer_id, string[] arguments)
        {
            string word = "";
            int count = arguments.Length;
            for(int i= 3; i < count; i++)
            {
                word += $"{arguments[i]} ";
            }
            int ind = word.Length - 1;
            string result = word.Remove(ind);

            long chat_id = API.Convert.PeerIdToChatId(peer_id);

            var chat = new API.Chat(chat_id.ToString());

            string text;
            if(chat.MissionDay.Type == Enums.API.MissionDayType.WordMission)
            {
                if(chat.MissionDay.Word == result)
                {
                    text = Files.Commands.MissionDay.Winner("11");
                }else
                {
                    text = Files.Commands.MissionDay.Loser;
                }
            }else if(chat.MissionDay.Type == Enums.API.MissionDayType.NoStartGame)
            {
                text = Files.Commands.MissionDay.NoStartGame;
            }else if(chat.MissionDay.Type == Enums.API.MissionDayType.NoMissionToday)
            {
                text = Files.Commands.MissionDay.GuessMissionToday;
            }else if(chat.MissionDay.Type == Enums.API.MissionDayType.GuessMissionToday)
            {
                text = Files.Commands.MissionDay.GuessMissionToday;
            }else
            {
                text = Files.Commands.MissionDay.Error;
            }

            API.Message.Send(new Models.MessageSendParams
            {
                PeerId = chat_id,
                Message = text
            });

        }

        public static void Trigger(long chat_id)
        {
            var chat = new API.Chat(chat_id.ToString());

            string quession;
            string answer;
            var random = new Random();
            int i = random.Next(1, Files.Commands.MissionDay.answers.Length);
            int index = i - 1;
            quession = Files.Commands.MissionDay.quessions[index];
            answer = Files.Commands.MissionDay.answers[index];
            var model = new Models.API.MissionDayResponse();
            model.Type = Enums.API.MissionDayType.WordMission;
            model.Word = answer;
            chat.MissionDay = model;

            API.Message.Send(new Models.MessageSendParams
            {
                PeerId = chat_id,
                Message = Files.Commands.MissionDay.WordGenereted(quession)
            });

        }
    }
}
