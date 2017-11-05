using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Database.Jack
{
    public class Ban
    {
        public string Id;
        Methods method = new Methods("jack", "bans");

        public static void Add(string id, string time, string from, string count)
        {
            Methods method = new Methods("jack", "bans");
            string fields = @"`id`, `Time`, `From`, `Count`";
            string values = $@"'{id}', '{time}','{from}', '{count}'";
            method.Add(fields, values);
        }

        public static void Delete(string id)
        {
            Methods method = new Methods("jack", "bans");
            method.Delete(id);
        }

        public string Time
        {
            get
            {
                return method.GetFromId(Id, "Time");
            }
            set
            {
                method.EditField(Id, "Time", Time);
            }
        }
        public string From
        {
            get
            {
                return method.GetFromId(Id, "From");
            }
            set
            {
                method.EditField(Id, "From", From);
            }
        }
        public string Count
        {
            get
            {
                return method.GetFromId(Id, "Count");
            }
            set
            {
                method.EditField(Id, "Count", Count);
            }
        }
    }
}
