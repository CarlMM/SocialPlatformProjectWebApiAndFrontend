using System;
using System.Collections.Generic;

#nullable disable

namespace SocialPlatformProjectWebApi.Models
{
    public partial class Thread
    {
        public Thread()
        {
            Replies = new HashSet<Reply>();
            ThreadUsers = new HashSet<ThreadUser>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? CategoryId { get; set; }
        public bool? ThreadType { get; set; }
        public string UserIdSub { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<ThreadUser> ThreadUsers { get; set; }
    }
}
