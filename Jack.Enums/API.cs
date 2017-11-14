﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Enums
{
    public struct API
    {
        public enum MissionDayType
        {
            NoMissionToday = 1,
            GuessMissionToday = 2,
            WordMission = 3,
            NoStartGame = 4
        }

        public enum TypeDownload
        {
            Meme =1,
            Picture =2,
            Ebalo = 3
        }
    }
}
