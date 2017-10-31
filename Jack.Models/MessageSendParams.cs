using System;
using System.Collections.Generic;
using System.Text;

namespace Jack.Models
{
    public struct MessageSendParams
    {
        public string From { get; set; }

        public long? PeerId { get; set; }
   
        public string Message { get; set; }
        
        //public IEnumerable<MediaAttachment> Attachments { get; set; }
        
        public IEnumerable<long> ForwardMessages { get; set; }
       
        public uint? StickerId { get; set; }
        
        public long? CaptchaSid { get; set; }
        
        public string CaptchaKey { get; set; }
       
    }
}
