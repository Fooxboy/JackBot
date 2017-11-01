using System;
using Jack.LongPoll;

namespace Jack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


        }

        private void StartBot()
        {
            Starter starter = new Starter();
            var responseLongPoll =  starter.Start();
            Logger.NewEvent(responseLongPoll);

        }
    }
}
