using System;
using System.Collections.Generic;
using System.Text;
using Jack.Interfaces;
using Jack.Commands;

namespace Jack
{
    public static class Bot
    {
        public static List<ICommand> Commands = null;

        public static void Initialization()
        {
            Commands.Add(new TestExecute());
        }
    }
}
