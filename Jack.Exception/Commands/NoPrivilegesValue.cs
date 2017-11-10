using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Exception.Commands
{
    public class NoPrivilegesValue: System.Exception
    {
        public NoPrivilegesValue() :base ("Недопустимая привелегия")
        {

        }
    }
}
