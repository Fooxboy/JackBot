using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Exception.LongPoll
{
    public class CodeNotFound : System.Exception
    {
        public CodeNotFound() :base ("Код не найден.")
        {

        }
    }
}
