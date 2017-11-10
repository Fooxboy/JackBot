using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Files.Commands
{
    public static class Rights
    {
        public static string NoAccess = "У Вас нет доступа для работы с кабинетом прав.";
        public static string NoCommand = "Не указана подкоманда.";
        public static string NoPrivileges = "Не указано выдаваемое право.";
        public static string Complete = "Пользователю успешно были выданы права!";
        public static string NoUser = "этот пользователь не является пользователем бота";
        public static string NotForwardMessage = "Вы не переслали сообщение с пользователем.";
        public static string NoPrivilegesValue = "Вы указали неверное право.";
        public static string CompleteDelete = "Вы успешно сбросили привелегии пользователю!";
    }
}
