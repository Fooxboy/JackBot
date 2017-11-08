using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Database.Jack
{
    public class Dialog
    {
        public string Id;
        Methods method = new Methods("jack", "dialogs");

        public static void Add(string id, string name, string admin)
        {
            Methods method = new Methods("jack", "dialogs");
            string fields = @"`id`, `Name`, `Admin`, `Is`";
            string first_name = name;
            string values = $@"'{id}', '{first_name}','{admin}', '1'";
            method.Add(fields, values);
        }

        public string Name
        {
            get
            {
                return method.GetFromId(Id, "Name");
            }
            set
            {
                method.EditField(Id, "Name", Name);
            }
        }
        public string Admin
        {
            get
            {
                return method.GetFromId(Id, "Admin");
            }
            set
            {
                method.EditField(Id, "Admin", Admin);
            }
        }
        public bool IsDialog
        {
            get
            {
                return method.Check(Id);
            }
        }

        public string Block
        {
            get
            {
                return method.GetFromId(Id, "Block");
            }set
            {
                method.EditField(Id, "Block", Block);
            }
        }

        public string MissionDay
        {
            get
            {
                return method.GetFromId(Id, "MissionDay");
            }set
            {
                method.EditField(Id, "MissionDay", MissionDay);
            }
        }
    }
}
