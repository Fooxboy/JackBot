using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Files.Commands
{
    public static class Who
    {
        public static string Result(string name, string comment)
        {
            string text = "";
            if (comment == "")
            {
                text = $"Я думаю, что это {name}!";
            } else
            {
                text = $"Я Вам скажу, что {name} - {comment}";
            }
            return text;
        }

        public static string IsNotChat = "Эта команда доступна только в груповых беседах.";

        public static string Help = "Команда выберает рандомного человека из беседы." +
            "ИСПОЛЬЗОВАНИЕ:" +
            "Джек, кто <коммент>" +
            "Примечание: Команда доступна в груповых чатах.";
    }
}
