using System;
using System.Collections.Generic;

#nullable disable

namespace SocialPlatformProjectWebApi.Models
{
    public class ThreadUser
    {
        public long Id { get; set; }
        public long ThreadId { get; set; }
        public long UserId { get; set; }

        public virtual JsonResult Thread { get; set; }
    }
}
