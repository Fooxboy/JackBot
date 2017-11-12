using System;
using System.Collections.Generic;
using System.Text;
using Jack.Interfaces;

namespace Jack.Helpers
{
    public static class Command
    {
        public static bool CanExecute(this ICommand comand, string com)
        {
            if (com == comand.Name.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
