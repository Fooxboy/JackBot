using System;
using System.Collections.Generic;
using System.Text;
using Jack.Interfaces;
using Jack.Models.LongPoll;
using Jack.API;

namespace Jack.Commands
{
    public class Story : ICommand
    {
        public string Name => "История";
        public string Help => "Помощь";

        public void Execute(Update.NewMessage message, string[] arguments)
        {
            //RUN
            var vk = Vk.Auth();

            string[] groups =
                {
                "-71729358",
                "-98075100",
                "-92397287",
                "-114566168"
                };

            var random = new Random();
            int IndexGroup = random.Next(0, groups.Length - 1);
            var group = Int64.Parse(groups[IndexGroup]);
            ulong count = 30;
            var WallObj = vk.Wall.Get(new VkNet.Model.RequestParams.WallGetParams
            {
                OwnerId = group,
                Count = count,
                Filter = VkNet.Enums.SafetyEnums.WallFilter.Owner,
                Extended = false
            });
            int IndexPost = random.Next(0, System.Convert.ToInt32(count - 1));
            var post = WallObj.WallPosts[IndexPost];
            var text = post.Text;
            Message.Send(new Models.MessageSendParams
            {
                From = message.From,
                PeerId = System.Convert.ToInt64(message.ExtraFields.PeerId),
                Message = text
            });
        }
    }
}
