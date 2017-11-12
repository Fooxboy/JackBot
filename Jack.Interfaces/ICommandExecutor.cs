using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models.LongPoll;

namespace Jack.Interfaces
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(ICommand command);
        bool CanExecute(ICommand command);
    }
}
