using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.API
{
    public class Chat
    {

        Database.Jack.Dialog chat;
        string Id;
        public Chat(string id)
        {
            chat = new Database.Jack.Dialog()
            {
                Id = id
            };
            Id = id;
        }

        public void New(string admin, string title)
        {
            string id = Id;

            Database.Jack.Dialog.Add(id, title, admin);
        }

        public string Name
        {
            get
            {
                return chat.Name;
            }set
            {
                chat.Name = Name;
            }
        }

        public string Admin
        {
            get
            {
                return chat.Admin;
            }set
            {
                chat.Admin = Admin;
            }
        }

        public bool Is
        {
            get
            {
                return chat.IsDialog;
            }
        }
    }
}
