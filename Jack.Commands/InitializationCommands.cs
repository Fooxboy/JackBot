using System;
using System.Collections.Generic;
using System.Text;
using Jack.Interfaces;

namespace Jack.Commands
{
    public class InitializationCommands
    {
        public static List<ICommand> Commands = new List<ICommand>();
        public static void Initialization()
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
            Commands.Add(new Meme());
            Commands.Add(new Story());
            Commands.Add(new Picture());
            Commands.Add(new Ebalo());
        }
    }
}
