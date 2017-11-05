using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Files.Commands
{
    public static class UnBan
    {
        public static string NoAccessPrivileges = "Эта команда не доступна Вашей привелегии. Купите привилегию от Премиума или выше.";
        public static string NoArgumentsId = "Вы не написали ID пользователя. Пожалуйста, Напишите ID пользователя или перешлите сообщение с ним.";
        public static string Help = "Команда для раблокировки пользователя." +
            "ИСПОЛЬЗОВАНИЕ:" +
            "Джек, разблокировать <id пользователя>" +
            "Или можно использовать алтернативный вариант:" +
            "Джек, раблокировать (пересланное сообщение с пользователем)";
    }
}
