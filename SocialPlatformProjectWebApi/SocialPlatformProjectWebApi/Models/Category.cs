using System;
using System.Collections.Generic;

#nullable disable

namespace SocialPlatformProjectWebApi.Models
{
    public  class Category
    {
        public Category()
        {
            Threads = new HashSet<Thread>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Thread> Threads { get; set; }
    }
}
