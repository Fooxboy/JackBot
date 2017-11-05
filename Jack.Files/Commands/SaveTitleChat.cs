using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Files.Commands
{
    public static class SaveTitleChat
    {
        public static string NoAdmin = "Вы не являетесь админом беседы или админом сохранённого названия.";
        public static string TitleBlocked = "Название в этой груповой беседе уже заблокировано. Разблокируйте сначала.";
        public static string NoChat = "Команда доступна только в групповых беседах. ";
        public static string NoAccess = "Ваша привелегия не позволяет Вам использовать эту команду.";
        public static string Compete = "Название груповой беседы успешно сохранено.";
        public static string NoEdit = "Название этой груповой беседе Вам нельзя изменить.";
        public static string Help = "Команда для блокировки названия груповой беседы." +
            "ИСПОЛЬЗОВАНИЕ:" +
            "Чтобы сохранить текущее название:" +
            "Джек, блок" +
            "Чтобы сохранить новое название:" +
            "Джек, блок <новое название>" +
            "ПРИВИЛЕГИИ НА КОТОРЫХ ДОСТУПНА КОМАНДА:" +
            "-Vip" +
            "-Premium" +
            "-Diamond" +
            "Примечание: Изменить название может будет только создатель диалога и тот, кто заблокировал название.";
    }
}
