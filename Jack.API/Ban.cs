using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.API;


namespace Jack.API
{
    public class Ban
    {
        Database.Jack.Ban ban;
        string Id;
        public Ban(string id)
        {
            ban = new Database.Jack.Ban()
            {
                Id = id
            };
            Id = id;
        }

        public static void New(NewBansParams @params)
        {
            string id = @params.id;
            string from = @params.from;
            string time = @params.time;
            string count = @params.count;
            Database.Jack.Ban.Add(id, time, from, count);
        }

        public static void Delete(string id)
        {
            Database.Jack.Ban.Delete(id);
        }

        public string From
        {
            get
            {
                return ban.From;
            }set
            {
                ban.From = value;
            }
        }

        public string Time
        {
            get
            {
                return ban.Time;
            }set
            {
                ban.Time = value;
            }
        }

        public string Count
        {
            get
            {
                return ban.Count;
            }set
            {
                ban.Count = value;
            }
        }
    }
}
