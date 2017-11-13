using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.API;

namespace Jack.API
{
    public class Chat
    {
        Database.Jack.Dialog chat;
        public string Id;
        public Chat(string id)
        {
            chat = new Database.Jack.Dialog()
            {
                Id = id
            };
            Id = id;
        }

        public void New(string admin = "", string title = "")
        {
            string id = Id;

            Database.Jack.Dialog.Add(id, title, admin);
        }

        public string Name
        {
            get
            {
                return chat.Name;
            }set
            {
                chat.Name = value;
            }
        }

        public string Admin
        {
            get
            {
                return chat.Admin;
            }set
            {
                chat.Admin = value;
            }
        }

        public bool Is
        {
            get
            {
                return chat.IsDialog;
            }
        }

        public bool Block
        {
            get
            {
                string result = chat.Block;
                if(result == "0")
                {
                    return false;
                }else
                {
                    return true;
                }
            }set
            {
                if(value)
                {
                    chat.Block = "1";
                }else
                {
                    chat.Block = "0";
                }
            }
        }

        public MissionDayResponse MissionDay
        {
            get
            {
                var model = new MissionDayResponse();

                string result = chat.MissionDay;
                if (result == "1")
                {
                    model.Type = Enums.API.MissionDayType.NoMissionToday;
                }else if(result == "2"){
                    model.Type = Enums.API.MissionDayType.GuessMissionToday;
                }else if(result == "0")
                {
                    model.Type = Enums.API.MissionDayType.NoStartGame;
                } else
                {
                    model.Type = Enums.API.MissionDayType.WordMission;
                    model.Word = result;
                }
                return model;
            }set
            {
                var model = value;
                string text;

                if(model.Type == Enums.API.MissionDayType.NoMissionToday)
                {
                    text = "1";
                }else if(model.Type == Enums.API.MissionDayType.GuessMissionToday)
                {
                    text = "2";
                }else if(model.Type == Enums.API.MissionDayType.WordMission)
                {
                    text = model.Word;
                }else if(model.Type == Enums.API.MissionDayType.NoStartGame)
                {
                    text = "0";
                }else
                {
                    text = "0";
                }

                chat.MissionDay = text;
            }
        }
    }
}
