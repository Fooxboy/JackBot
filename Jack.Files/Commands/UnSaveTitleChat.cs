using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Files.Commands
{
    public static class UnSaveTitleChat
    {
        public static string Ready = "Название груповой беседы раблокированно.";
        public static string NoAccessPrivileges = "У Вас нет доступа к этой команде. Купите привелегию VIP или выше.";
        public static string TitleNotBlocked = "В этой груповой беседе название не заблокированно.";
        public static string NoAccessAdmin = "Вы не являетесь создателем диалога или пользователь, который заблокировал название";
        public static string Help = "Команда, которая раблокирует название беседы." +
            "ИСПОЛЬЗОВАНИЕ:" +
            "Джек, анблок" +
            "Премечание: Разблокировать название могут только создатель груповой беседы или тот, кто заблокировал название." +
            "ДОСТУПНА НА ПРИВЕЛЕГИЯХ:" +
            "-Vip" +
            "-Premium" +
            "-Diamond";
    }
}
