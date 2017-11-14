using System;
using System.Collections.Generic;
using System.Text;
using Jack.Interfaces;
using Jack.Models.LongPoll;

namespace Jack.Commands
{
    public class Ebalo : ICommand
    {
        public string Name => "Ебало";
        public string Help => "Помощь";

        public void Execute(Update.NewMessage message, string[] arguments)
        {
            var vk = Vk.Auth();
            long[] groups =
            {
                -150039235,
                -153076752
            };
            var random = new Random();
            int IndexGroup = random.Next(0, groups.Length - 1);
            long group = groups[IndexGroup];
            ulong count = 30;
            var WallObj = vk.Wall.Get(new VkNet.Model.RequestParams.WallGetParams
            {
                OwnerId = group,
                Count = count,
                Filter = VkNet.Enums.SafetyEnums.WallFilter.Owner,
                Extended = false
            });

            var IndexPost = random.Next(0, System.Convert.ToInt32(count - 1));
            var post = WallObj.WallPosts[IndexPost];
            var image = (VkNet.Model.Attachments.Photo)post.Attachment.Instance;
            var urlImage = image.Photo604;
            var file = API.Download.Photo(urlImage, Enums.API.TypeDownload.Ebalo);
            var server = vk.Photo.GetMessagesUploadServer().UploadUrl;
            var json = API.Upload.Photo(file, server);
            var photo = vk.Photo.SaveMessagesPhoto(json);
            API.Message.SendPhoto(photo, Int64.Parse(message.ExtraFields.PeerId));
            System.IO.File.Delete(file);
        }
    }
}
