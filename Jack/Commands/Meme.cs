using System;
using System.Collections.Generic;
using System.Text;
using Jack.Interfaces;
using Jack.Models.LongPoll;
using Jack.API;
using Newtonsoft.Json;

namespace Jack.Commands
{
    public class Meme: ICommand
    {
        public string Name => "Мем";
        public string Help => "Помощь";

        public void Execute(Update.NewMessage message, string[] arguments)
        {
            var vk = Vk.Auth();
            string[] groups = 
            {
                "-144899507",
                "-141549647",
                "-146716837",
                "-113502491"
            };

            var rand = new Random();
            int index = rand.Next(0, groups.Length);
            long group = Int64.Parse(groups[index]);
            ulong count = 30;
            var wallObj = vk.Wall.Get(new VkNet.Model.RequestParams.WallGetParams()
            {
                OwnerId = group,
                Count = count,
                Filter = VkNet.Enums.SafetyEnums.WallFilter.Owner,
                Extended = false
            });

            int index2 = getIntPost(wallObj, count);
            var post = wallObj.WallPosts[index2];
            var image = (VkNet.Model.Attachments.Photo)post.Attachment.Instance;
            var image_url = image.Photo604;
            var file = Download.Photo(image_url, Enums.API.TypeDownload.Meme);
            var server = vk.Photo.GetMessagesUploadServer().UploadUrl;
            var json = Upload.Photo(file, server);
            var photo = vk.Photo.SaveMessagesPhoto(json);
            Message.SendPhoto(photo);

        }

        private int getIntPost(VkNet.Model.WallGetObject wallObj, ulong count)
        {
            var value = false;
            int i=0;
            while(!value)
            {        
                var random = new Random();
                int result = random.Next(0, System.Convert.ToInt32(count));
                var post = wallObj.WallPosts[result];

                var type = post.Attachment.Type;
                if (type == typeof(VkNet.Model.Attachments.Photo))
                {
                    value = true;
                    i = result;
                }
                else
                {
                    value = false;
                }
                
            }

            return i;
        }

    }
}
