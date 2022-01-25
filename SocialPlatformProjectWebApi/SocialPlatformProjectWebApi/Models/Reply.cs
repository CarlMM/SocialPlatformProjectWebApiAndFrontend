using System;
using System.Collections.Generic;

#nullable disable

namespace SocialPlatformProjectWebApi.Models
{
    public class Reply
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public byte[] CreatedDate { get; set; }
        public long? UserId { get; set; }
        public long ThreadId { get; set; }

        public virtual Thread Thread { get; set; }
    }
}
