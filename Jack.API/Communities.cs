using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.API
{
    public class Communities
    {
        Database.Jack.Communities communities;
        public string Id;

        public static void New(string id, string name, string creator)
        {
            Database.Jack.Communities.Add(id, name, creator);   
        }

        public Communities(string id)
        {
            communities = new Database.Jack.Communities()
            {
                Id = id
            };

            Id = id;
        }

        public string Name
        {
            get
            {
                return communities.Name;
            }set
            {
                communities.Name = value;
            }
        }

        public bool Is
        {
            get
            {
                return communities.Is;
            }
        }

        public List<string> Members
        {
            get
            {
                string members = communities.Members;
                string[] resp = members.Split(',');
                List<string> response = new List<string>();
                foreach(string s in resp)
                {
                    response.Add(s);
                }
                return response;
            }
            set
            {
                string text = "";
                foreach(string s in value)
                {
                    text += $"{s},";
                }
                communities.Members = text;
            }
        }

        public int Level
        {
            get
            {
                string text = communities.Level;
                return Int32.Parse(text);
            }set
            {
                communities.Level = value.ToString();
            }
        }

        public string Creator
        {
            get
            {
                return communities.Creator;
            }set
            {
                communities.Creator = value;
            }
        }
    }
}
