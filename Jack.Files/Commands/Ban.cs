using System;
using System.Collections.Generic;
using System.Text;
using Jack.API;

namespace Jack.Files.Commands
{
    public static class Ban
    {
        public static string NoTime = "Вы не указали время бана.";
        public static string Compete(User user, string time)
        {
            string text = $"Вы успешно заблокировали {user.Name} на {time} минут.";
            return text;
        }
        public static string NoAccess = "Вы не можете блокировать пользователей. Купите другую привелегию.";
        public static string NoBanThisPrivileges = "Вы не можете блокировать пользователей, у которых привелегия выше Вашей.";
    }
}
