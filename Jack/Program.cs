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
            Statistics.Missions.Start();
            Console.Title = $"JackBot Run. Version {Files.Jack.Version}";
            Bot.InitializationCommand();

            Thread ThreadLongPoll = new Thread(StartBot);
            ThreadLongPoll.Name = "LongPoll";
            ThreadLongPoll.Start(); 
        }

        private static void StartBot()
        {
            while(true)
            {
                Starter starter = new Starter();
                var responseLongPoll = starter.Start();
                Logger.NewEvent(responseLongPoll);
                
                var ThreadRender = new Thread(new ParameterizedThreadStart(RenderMode));
                ThreadRender.Name = "Render Message";
                ThreadRender.Start(responseLongPoll);
            }      
        }

        private static void RenderMode(object res)
        {
            var responseLongPoll = (ResponseLongPoll)res;
            var render = new Render();
            render.Start(responseLongPoll);
        }
    }
}
