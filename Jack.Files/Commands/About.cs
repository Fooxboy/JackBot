using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Files.Commands
{
    public static class About
    {
        public static string Main()
        {
            string text = $"✅ Бот Джек." +
                $"❗ Версия: {Jack.Version}." +
                $"❗ Дата сборки: {Jack.Build}." +
                $"❗ Разработчик: [fooxboy|Славик Смирнов]." +
                $"❗ ЕСЛИ ВЫ НАШЛИ БАГ ИЛИ НЕДОРАБОТКУ СООБЩИТЕ РАЗРАБОТЧИКУ.";
            return text;
        }
    }
}
