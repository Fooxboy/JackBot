using System;
using Jack.LongPoll;

namespace Jack
{
    class Program
    {
        static void Main(string[] args)
        {
           
        }

        private void StartBot()
        {
            Starter starter = new Starter();
            var responseLongPoll =  starter.Start();
            Logger.NewEvent(responseLongPoll);
            Statistics.Missions.Start();
            var render = new Render();
            render.Start(responseLongPoll);

        }
    }
}
