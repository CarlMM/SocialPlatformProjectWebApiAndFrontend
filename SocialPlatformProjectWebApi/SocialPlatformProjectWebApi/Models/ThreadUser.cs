using System;
using System.Collections.Generic;

#nullable disable

namespace SocialPlatformProjectWebApi.Models
{
    public partial class ThreadUser
    {
        public long Id { get; set; }
        public long CategoryThreadId { get; set; }
        public string UserIdSub { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual CategoryThread CategoryThread { get; set; }
        public virtual User UserIdSubNavigation { get; set; }
    }
}
