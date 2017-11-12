using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;

namespace Jack.Interfaces
{
    public interface ICommand
    {
        void Execute(Update.NewMessage message, string[] arguments);
        string Name { get; }
        string Help { get; }
    }
}
