using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Files.Commands
{
    public static class When
    {
        public static string Complete(int day,int moth,int year, string comment)
        {
            string text;
            text = $"{comment} будет в {day}.{moth}.{comment}!";
            return text;
        }
    }
}
