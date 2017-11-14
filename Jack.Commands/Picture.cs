using System;
using System.Collections.Generic;
using System.Text;
using Jack.Interfaces;
using Jack.Models.LongPoll;

namespace Jack.Commands
{
    public class Picture: ICommand
    {
        public string Name => "Пикча";
        public string Help => "помощь";

        public void Execute(Update.NewMessage message, string[] arguments)
        {
            var vk = Vk.Auth();
            long group = -145597354;
            var random = new Random();
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

            var image = (VkNet.Model.Attachments.Photo)post.Attachment.Instance;
            var urlImage = image.BigPhotoSrc;
            var file = API.Download.Photo(urlImage, Enums.API.TypeDownload.Picture);
            var server = vk.Photo.GetMessagesUploadServer().UploadUrl;
            var json = API.Upload.Photo(file, server);
            var photo = vk.Photo.SaveMessagesPhoto(json);
            API.Message.SendPhoto(photo, Int64.Parse(message.ExtraFields.PeerId));
            System.IO.File.Delete(file);
        }
    }
}
