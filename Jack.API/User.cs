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
                user.Name = value;
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
                user.Ban = value;
            }
        }

        public int Foxs
        {
            get
            {
                return System.Convert.ToInt32(user.Money);
            }set
            {
                user.Money = value.ToString();
            }
        }

        public Enums.Jack.Privileges Privileges
        {
            get
            {
                int privileges = System.Convert.ToInt32(user.Privileges);

                if (privileges == 1)
                {
                    return Enums.Jack.Privileges.User;
                } else if (privileges == 2)
                {
                    return Enums.Jack.Privileges.Vip;
                }else if(privileges == 3)
                {
                    return Enums.Jack.Privileges.Premium;
                }else if(privileges == 4)
                {
                    return Enums.Jack.Privileges.Diamond;
                }else if(privileges == 5)
                {
                    return Enums.Jack.Privileges.Admin;
                }else if(privileges == 6)
                {
                    return Enums.Jack.Privileges.Insider;
                } else
                {
                    throw new Exception("hou");
                }

            }set
            {
                int priv = (int)value;
                user.Privileges = priv.ToString();
            }
        }

        public string Community
        {
            get
            {
                return user.Community;
            }set
            {
                user.Community = value;
            }
        }

        public void New(Enums.Jack.Privileges modelPrivileges, string time = "-1")
        {
            string id = Id;
            int privileges = (int)modelPrivileges;

            string name = Vk.Auth().Users.Get(System.Convert.ToInt64(id)).FirstName;

            Database.Jack.User.Add(id, name, privileges.ToString(), time);
        }
    }
}
