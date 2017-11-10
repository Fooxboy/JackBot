using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models;

namespace Jack.Files.Commands
{
    public static class Vote
    {
        public static string Complete = "Голосование успешно создано! Чтобы добавить варианты ответа напишите: Джек, голосование вариант <Вариант Ответа>";
        public static string VoteReady = "Голосование уже есть. Чтобы удалить текущее голосование напишите: Джек, голосование конец";
        public static string NoAccess = "Вашей привелегии не доступна эта команда. Получите привелегию от VIP и выше";
        public static string NoComment = "Вы не указали текст голосования.";
        public static string NoCommand = "Вы не указали подкоманду.";
        public static string AddedAnswer = "Вариант ответа добавлен! Чтобы начать голосование напишите: Джек, голосование начать";
        public static string NoVote = "Голосование в этом чате не создано.";
        public static string NoCreator = "Вы не создатель этого голосования.";
        public static string AddBehid = "Ваш голос защитан!";
        public static string NotCommand = "Неизвестная подкоманда.";
        public static string CompleteStart = "Голосование начато! Чтобы узнать количество голосов, напишите: Джек, голосование сейчас";
        public static string CompleteEnd(VoteModel model)
        {
            string text;
            string Answers="";

            List<string> variants = model.AnswersOptions;
            List<int> counts = model.Answers;
            for(int i=0; model.AnswersOptions.Count < i; i++)
            {
                Answers += $"{variants[i]} - {counts[i]}\n";
            }

            text = $"Голосование окончено." +
                $"-{model.Name}" +
                $"Варианты ответа - количество голосов." +
                $"{Answers}";

            return text;
        }

        public static string CompleteNow(VoteModel model)
        {
            string text;
            string Answers = "";

            List<string> variants = model.AnswersOptions;
            List<int> counts = model.Answers;
            for (int i = 0; model.AnswersOptions.Count < i; i++)
            {
                Answers += $"{variants[i]} - {counts[i]}\n";
            }

            text = $"-{model.Name}" +
                $"Варианты ответа - количество голосов." +
                $"{Answers}";

            return text;
        }

    }
}
