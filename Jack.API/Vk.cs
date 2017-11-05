using System;
using System.Collections.Generic;
using System.Text;
using VkNet;
using Jack.Common;

namespace Jack.API
{
    public class Vk
    {
        public static VkApi Auth()
        {
            var vk = new VkApi();
            string token = Data.AccessToken;
            vk.Authorize(new ApiAuthParams
            {
                AccessToken = token
            });
            return vk;
        }
    }
}
