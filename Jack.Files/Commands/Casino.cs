using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Files.Commands
{
    public static class Casino
    {
        public static string NoCommand = "Вы не ввели подкоманду." +
            "Доступные команды казино:" +
            "-Ставка <количество фоксов>";
        public static string NoArgFoxs = "Вы не указали количество фоксов." +
            "Правильный вид команды:" +
            "-Ставка <количество фоксов>";
        public static string NoFoxs = "На Вашем счету недостаточно фоксов. Пополните, пожалуйста, баланс.";

        public static string Loser(int count)
        {
            string text = $"Увы, но вы проиграли {count} фоксов.";
            return text;
        }

        public static string Winner(int count)
        {
            string text = $"Поздравляю! Вы выграли {count} фоксов!";
            return text;
        }

        public static string Help = "Команда для игры в казино." +
            "ИСПОЛЬЗОВАНИЕ:" +
            "Джек, казино <количество фоксов>";
    }
}
