using System;
using System.Collections.Generic;
using System.Text;
using Jack.API;

namespace Jack.Files.Commands
{
    public static class Profile
    {
        public static string Info(User user)
        {
            string text = $"Информация о пользователе {user.Name}:" +
                $"-Имя: {user.Name}" +
                $"-В бане ли: {user.Ban}" +
                $"-Количество фоксов: {user.Foxs}" +
                $"-Привелегия: {user.Privileges}";
            return text;
        }

        public static string NoUser = "Этот пользователь не является пользователем бота.";
    }
}
