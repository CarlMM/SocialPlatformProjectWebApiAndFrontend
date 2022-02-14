using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Models
{
    public class CategoryThreadVM
    {


        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? CategoryId { get; set; }
        public bool? ThreadType { get; set; }
        public string UserIdSub { get; set; }
        public string UserName { get; set; } 

        

        
        public ICollection<ThreadUser> ThreadUsers { get; set; }
        public ICollection<User> Users { get; set; }


    }
}
