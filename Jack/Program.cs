using System;
using Jack.LongPoll;
using System.Threading;

namespace Jack
{
    class Program
    {
        static void Main(string[] args)
        {
            //Инициализация.
            Console.WriteLine("Бот стартед.");
            Statistics.Missions.Start();
            Console.Title = $"JackBot Run. Version {Files.Jack.Version}";
            Jack.Commands.InitializationCommands.Initialization();

            Thread ThreadLongPoll = new Thread(StartBot);
            ThreadLongPoll.Name = "LongPoll";
            ThreadLongPoll.Start(); 
            StartBot();
        }

        private static void StartBot()
        {
            Starter starter = new Starter();
            while (true)
            {
                starter.Start();
            }      
        }

        //private static void RenderMode(object res)
        //{
        //    var responseLongPoll = (ResponseLongPoll)res;
        //    var render = new Render();
        //    render.Start(responseLongPoll);
        //}
    }
}
