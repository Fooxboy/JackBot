using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Jack.Models;
using Newtonsoft.Json;

namespace Jack
{
    public static class Missions
    {
        public static bool Add(MissionsAddParams @params)
        {
            Enums.Jack.Missions.Type type = @params.Type;

            var mission = new Mission();
            mission.Id = GetCountMissions() + 1;
            mission.IdComplete = new List<string>();
            mission.IdType = @params.IdType;
            mission.Title = @params.Title;
            mission.Price = @params.Price;
            mission.By = @params.By;
            mission.Complete = false;

            string json = Read();
            Models.Missions missions;
            try
            {
               missions = JsonConvert.DeserializeObject<Models.Missions>(json);
            }catch
            {
                missions = new Models.Missions();
                missions.Title = "Задания Джека";
            }
            
            if (type == Enums.Jack.Missions.Type.AddFriend)
            {
                mission.Type = 3;
               
            } else if(type == Enums.Jack.Missions.Type.LikePhoto)
            {
                mission.Type = 1;
            }
            else if(type == Enums.Jack.Missions.Type.Repost)
            {
                mission.Type = 2;
            }
            else if(type == Enums.Jack.Missions.Type.Write)
            {
                mission.Type = 4;
            }
            else if(type == Enums.Jack.Missions.Type.LikeWall)
            {
                mission.Type = 5;
            }

            missions.Mission.Add(mission);
            string out_json = JsonConvert.SerializeObject(missions);
            Write(out_json);
            return true;
        }

        public static bool Complete(MissionsCompleteParams @params)
        {
            var missions = JsonConvert.DeserializeObject<Models.Missions>(Read());

           for(int i=0; missions.Mission.Count < i; i++)
           {
                if(missions.Mission[i].Id == @params.Id)
                {
                    var miss = missions.Mission[i];
                    miss.IdComplete.Add(@params.Id_Copleted_User);
                    if(miss.Count == 1)
                    {
                        miss.IdComplete.Add(@params.Id_Copleted_User);
                        miss.Complete = true;
                    }
                    else
                    {
                        miss.Count -= 1;
                        miss.IdComplete.Add(@params.Id_Copleted_User);
                    }
                    missions.Mission[i] = miss;
                }
           }

            var json = JsonConvert.SerializeObject(missions);

            Write(json);

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
            return Statistics.Missions.Count;
        }

    }
}
