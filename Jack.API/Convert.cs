using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.API
{
    public static class Convert
    {
        public static long PeerIdToChatId(string peer_id)
        {
            long id = System.Convert.ToInt64(peer_id);

            return id - 2000000000;
        } 
    }
}
