using System;
using System.Collections.Generic;
using System.Text;
using VkNet;

namespace Jack.API
{
    public class Vk
    {
        public static VkApi Auth()
        {
            var vk = new VkApi();
            string token = Files.Jack.Token;
            vk.Authorize(new ApiAuthParams
            {
                AccessToken = token
            });
            return vk;
        }
    }
}
