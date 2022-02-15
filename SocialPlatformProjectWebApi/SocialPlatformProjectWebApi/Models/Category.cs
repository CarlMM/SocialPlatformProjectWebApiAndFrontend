using System;
using System.Collections.Generic;

#nullable disable

namespace SocialPlatformProjectWebApi.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryThreads = new HashSet<CategoryThread>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CategoryThread> CategoryThreads { get; set; }
    }
}
