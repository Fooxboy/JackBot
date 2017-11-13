using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Database.Jack
{
    public class User
    {
        public string Id;
        Methods method = new Methods("mike", "users");

        public static void Add(string id, string name, string Privileges, string PrivilegesTime)
        {
            Methods method = new Methods("jack", "users");
            string fields = @"`id`, `Name`, `Ban`, `Is`, `Privileges`, `PrivilegesTime`, `Money`, `Community`";
            string first_name = name;
            string values = $@"'{id}', '{first_name}','0', '1', '{Privileges}', '{PrivilegesTime}', '0', '0'";
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
                method.EditField(Id, "Name", value);
            }
        }
        public bool Ban
        {
            get
            {
                var value = method.GetFromId(Id, "Ban");

                if (value == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set
            {
                var values = "0";
                if (value == true)
                {
                    values = "1";
                }

                method.EditField(Id, "Ban", values);
            }
        }
        public bool IsUser
        {
            get
            {
                return method.Check(Id);
            }
        }
        public string Privileges
        {
            get
            {
                return method.GetFromId(Id, "Privileges");
            }
            set
            {
                method.EditField(Id, "Privileges", value);
            }
        }
        public string PrivilegesTime
        {
            get
            {
                return method.GetFromId(Id, "PrivilegesTime");

            }
            set
            {
                method.EditField(Id, "PrivilegesTime", value);
            }
        }

        public string Money
        {
            get
            {
                return method.GetFromId(Id, "Money");
            }
            set
            {
                method.EditField(Id, "Money", value);
            }
        }

        public string Community
        {
            get
            {
                return method.GetFromId(Id, "Community");
            }set
            {
                method.EditField(Id, "Community", value);
            }
        }

    }
}
