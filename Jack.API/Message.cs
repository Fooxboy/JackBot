using System;
using System.Collections.Generic;
using System.Text;
using Jack.Models;
using VkNet;

namespace Jack.API
{
    public static class Message
    {
        public static void Send(MessageSendParams sendParams)
        {
            var vk = Vk.Auth();

            string sendText = "";

            if(sendParams.From == null)
            {
                var user = new User(sendParams.From);
                string name = user.Name;
                string text = $"{name}, {sendParams.Message}";
                sendText = text;
            }else
            {
                sendText = sendParams.Message;
            }

            vk.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {
                Message = sendText,
                PeerId = sendParams.PeerId,
                CaptchaKey = sendParams.CaptchaKey,
                CaptchaSid = sendParams.CaptchaSid
            });
        }

        public static void SendPhoto(System.Collections.ObjectModel.ReadOnlyCollection<VkNet.Model.Attachments.Photo> photo, long peer_id)
        {
            var vk = Vk.Auth();
            vk.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
            {
                Attachments = photo,
                PeerId = peer_id
               
            });
        }
    }
}
