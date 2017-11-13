using System;
using System.Collections.Generic;
using System.Text;
using Jack.API;

namespace Jack.Files.Commands
{
    public static class Community
    {
        public static string ReadyCreate = "Сообщество успешно создано! Другие пользователи могут к нему присоедениться по его ID. Узнать его можно, написав Джек, сообщество профиль.";
        public static string ReadyLeave = "Вы успешно покинули сообщество!";
        public static string ReadyJoin = "Вы успешно присоеденились к сообществу!";
        public static string NoCommunity = "Вас нет ни в каком сообществе.";
        public static string CommunityNotFound = "Сообщества с таким ID не существует.";
        public static string NoIdCommunity = "Вы не указали ID сообщества!";
        public static string NoNameCommunity = "Вы не указали название сообщества!";
        public static string NoCommand = "Вы не указали подкоманду для работы с сообществами.";
        public static string NotCommand = "Неизвестная подкоманда.";
        public static string UserIsCommunity = "Вы уже находитесь в сообществе.";

        public static string Profile(Communities commutity)
        {
            string text;

            text = $"ПРОФИЛЬ СООБЩЕСТВА:" +
                $"ID: {commutity.Id}" +
                $"Участники: мне лень пилить" +
                $"Создатель: {commutity.Creator}" +
                $"Количество участников: {commutity.Members.Count}" +
                $"Чтобы другой пользователь присоеденился к вам в сообщество, он должен написать Джек, сообщество просоедениться {commutity.Id}";
            return text;
        }
    }
}
