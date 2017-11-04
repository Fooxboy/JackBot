using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace Jack.Statistics
{
    public static class Missions
    {
        public static void Start()
        {
            Models.Statistics.Missions mission = new Models.Statistics.Missions();

            try
            {
                string json;
                using (StreamReader sr = new StreamReader("Missions.json"))
                {
                    json = sr.ReadToEnd();
                }

                mission = JsonConvert.DeserializeObject<Models.Statistics.Missions>(json);
            }catch
            {
                mission.Count = 0;

                var json = JsonConvert.SerializeObject(mission);
            }
        }

        public static int Count
        {
            get
            { 
                return JsonConvert.DeserializeObject<Models.Statistics.Missions>(Read()).Count;
            }
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
    }
}
