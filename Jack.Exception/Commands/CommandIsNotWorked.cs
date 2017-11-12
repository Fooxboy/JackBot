using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Exception.Commands
{
    public class CommandIsNotWorked: System.Exception
    {
        public CommandIsNotWorked() :base ("Команда ещё в разработке.")
        {

        }
    }
}
