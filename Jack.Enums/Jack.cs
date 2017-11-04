using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Enums
{
    public struct Jack
    {
        public enum Privileges
        {
            User = 1,
            Vip = 2,
            Premium = 3,
            Diamond = 4,
            Admin = 5,
            Insider = 6
        }

        public struct Missions
        {
            public enum Type
            {
                LikePhoto = 1,
                Repost = 2,
                AddFriend = 3,
                Write = 4,
                LikeWall = 5
            }
        }
    }
}
