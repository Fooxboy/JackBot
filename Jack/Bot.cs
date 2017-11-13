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
        public static void InitializationCommand()
        {
            Commands.Add(new TestExecute());
            Commands.Add(new About());
            Commands.Add(new Ban());
            Commands.Add(new Casino());
            Commands.Add(new Help());
            Commands.Add(new MissionDay());
            Commands.Add(new Nick());
            Commands.Add(new Profile());
            Commands.Add(new Promocode());
            Commands.Add(new Rights());
            Commands.Add(new SaveTitleChat());
            Commands.Add(new UnBan());
            Commands.Add(new UnSaveTitleChat());
            Commands.Add(new Vote());
            Commands.Add(new When());
            Commands.Add(new Who());
            Commands.Add(new Community());
        }
    }
}
