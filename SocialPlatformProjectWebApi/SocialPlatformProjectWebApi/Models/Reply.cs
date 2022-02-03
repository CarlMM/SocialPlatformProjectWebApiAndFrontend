using System;
using System.Collections.Generic;

#nullable disable

namespace SocialPlatformProjectWebApi.Models
{
    public partial class Reply
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long CategoryThreadId { get; set; }
        public string UserIdSub { get; set; }

        public virtual CategoryThread CategoryThread { get; set; }
    }
}
