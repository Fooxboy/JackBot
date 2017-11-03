using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Jack.Models;

namespace Jack
{
    public static class Missions
    {
        public static bool Add(MissionsAddParams @params)
        {
            Enums.Jack.Missions.Type type = @params.type;

            Models.Missions mission = new Models.Missions();

            if(type == Enums.Jack.Missions.Type.AddFriend)
            {
                mission.By = @params.user;
                mission.Count = @params.count;
                mission.Id = 
                mission.IdComplete = new List<string>();

                //Подписаться или добавить в друзья.
            } else if(type == Enums.Jack.Missions.Type.LikePhoto)
            {
                //Лайк фото.
            }else if(type == Enums.Jack.Missions.Type.Repost)
            {
                //Репост к себе на стену.
            }else if(type == Enums.Jack.Missions.Type.Write)
            {
                //Написать на стене.
            }else if(type == Enums.Jack.Missions.Type.LikeWall)
            {
                //Лайк записи.
            }
            return true;
        }
        
        private static string Read()
        {
            string json;
            using (StreamReader sr = new StreamReader("Missions.json"))
            {
                json = sr.ReadToEnd();
            }
            return json;
        } 

        private static void Write(string text)
        {
            using (StreamWriter sw = new StreamWriter("Missions.json", false, Encoding.Default))
            {
                sw.Write(text);
            }
        }

        private static int GetCountMissions()
        {
            
        }

    }
}
