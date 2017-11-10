using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Files.Commands
{
    public static class Nick
    {
        public static string Complete = "Вы успешно сменили ник!";
        public static string CompleteDelete = "Вы успешно сбросили свой ник до дефолтного!";
        public static string NotCommand = "Вы не указали подкоманду!";
        public static string NotNewNick = "Вы не указали новый ник!";
        public static string NotPrivileges = "Вы не можете изменять другим пользователям ники! Купите привелегию выше.";
        public static string NotPermissions = "Вы не можете изменить ник пользователю, у которого привелегия выше Вашей.";
    }
}
