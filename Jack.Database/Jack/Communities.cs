using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Database.Jack
{
    public class Communities
    {
        public string Id;
        Methods method = new Methods("jack", "bans");

        public static void Add(string id, string name, string creator)
        {
            Methods method = new Methods("jack", "communities");
            string fields = @"`id`, `Name`, `Members`, `Level`, `Creator`, `Is`";
            string values = $@"'{id}', '{name}','{creator},', '1', '{creator}', '1'";
            method.Add(fields, values);
        }

        public string Name
        {
            get
            {
                return method.GetFromId(Id, "Name");
            }set
            {
                method.EditField(Id, "Name", value);
            }
        }

        public string Members
        {
            get
            {
                return method.GetFromId(Id, "Members");
            }set
            {
                method.EditField(Id, "Members", value);
            }
        }

        public string Level
        {
            get
            {
                return method.GetFromId(Id, "Level");
            }set
            {
                method.EditField(Id, "Level", value);
            }
        }

        public bool Is
        {
            get
            {
                return method.Check(Id);
            }
        }

        public string Creator
        {
            get
            {
                return method.GetFromId(Id, "Creator");
            }set
            {
                method.EditField(Id, "Creator", value);
            }
        }
    }
}
