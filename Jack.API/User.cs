using System;
using Jack.Database.Jack;
using VkNet;

namespace Jack.API
{
    public class User
    {
        Database.Jack.User user;
        string Id;
        public User(string id)
        {
            user = new Database.Jack.User()
            {
                Id = id
            };
            Id = id;
        }

        public string Name
        {
            get
            {
                return user.Name;
            }set
            {
                user.Name = Name;
            }
        }

        public bool IsUser
        {
            get
            {
                return user.IsUser;
            }
        }

        public bool Ban
        {
            get
            {
                return user.Ban;
            } set
            {
                user.Ban = Ban;
            }
        }

        public void New(Enums.Jack.Privileges modelPrivileges, string time = "-1")
        {
            string id = Id;
            int privileges = (int)modelPrivileges;

            string name = Vk.Auth().Users.Get(Convert.ToInt64(id)).FirstName;

            Database.Jack.User.Add(id, name, privileges.ToString(), time);
        }
    }
}
