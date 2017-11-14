using System;
using System.Collections.Generic;
using System.Text;
using Jack.Interfaces;
using Jack.Models.LongPoll;

namespace Jack.Commands
{
    public class TestExecute : ICommand
    {
        public string Name => "testExecute";

        public string Help => "помощь";

        public void Execute(Update.NewMessage message, string[] argumetns)
        {
            //
        }
    }
}
