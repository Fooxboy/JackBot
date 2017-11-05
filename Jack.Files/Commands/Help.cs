using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Files.Commands
{
    public static class Help
    {
        public static string Main = $"Jack BOT version {Jack.Version}" +
            $"Дата сборки: {Jack.Build}" +
            $"СПИСОК КОМАНД:" +
            $"-Оботе" +
            $"-Бан" +
            $"-Разбан" +
            $"-Казино" +
            $"-Профиль" +
            $"-Блок" +
            $"-АнБлок" +
            $"Для подробного описания напишите: Джек, помощь <название команды>";
        public static string NotCommand = "Неизвестная подкоманда. Чтобы узнать список всех команд напишите:" +
            "Джек помощь";
    }
}
