using System;
using System.Collections.Generic;

#nullable disable

namespace SocialPlatformProjectWebApi.Models
{
    public partial class User
    {
        public User()
        {
            ThreadUsers = new HashSet<ThreadUser>();
        }

        public long Id { get; set; }
        public string IdSub { get; set; }
        public string Username { get; set; }
        public string Picture { get; set; }
        public string Email { get; set; }
        public bool? EmailVerified { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual ICollection<ThreadUser> ThreadUsers { get; set; }
    }
}
