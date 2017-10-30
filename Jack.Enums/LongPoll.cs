using System;

namespace Jack.Enums
{
    public struct LongPoll
    {
        public enum Events
        {
            EditFlags = 1,
            SetFlags = 2,
            OffFlags = 3,
            NewMessage = 4,
            ReadInMessage = 6,
            ReadOutMessage = 7,
            UserOnline = 8,
            UserOffline = 9,
            DeleteMessage = 13,
            ReestablishMessage = 14,
            ChatEdit = 51,
            WriteMessage = 61,
            WriteMessageChat = 62
        }

        public enum TypeMessage
        {
            Dialog = 1,
            Chat = 2
        }

    }
}
