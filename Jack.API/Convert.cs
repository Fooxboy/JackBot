using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.API
{
    public static class Convert
    {
        public static long PeerIdToChatId(string peer_id)
        {
            ulong id = System.Convert.ToUInt64(peer_id);
            var response = id - 2000000000;
            return System.Convert.ToInt64(response);
        } 
    }
}
