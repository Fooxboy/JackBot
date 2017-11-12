using System;
using System.Collections.Generic;
using System.Text;
using Jack.Interfaces;

namespace Jack
{
    //public class CompositeCommandExecutor :ICommandExecutor
    //{
    //    Dictionary<string, ICommandExecutor> _processors = new Dictionary<string, ICommandExecutor>();

    //    public void Register(string commandName, ICommandExecutor processor)
    //    {
    //        _processors.Add(commandName, processor);
    //    }

    //    public bool CanProcess(ICommand command)
    //    {
    //        return _processors.ContainsKey(command.Name);
    //    }

    //    public void ProcessCommand(ICommand command)
    //    {
    //        if (!CanProcess(command)) throw new ArgumentException(nameof(command));
    //        _processors[command.Name].ExecuteCommand(command);
    //    }
    //}
}
