using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.API
{
    public static class Convert
    {
        public static string PeerIdToChatId(string peer_id)
        {
            string chatIdStep1 = peer_id.Replace('0', ' ');
            string chatId = chatIdStep1.Replace('2', ' ');
            return chatId.Trim();       
        } 
    }
}
