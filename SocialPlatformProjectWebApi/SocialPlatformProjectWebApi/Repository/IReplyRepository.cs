using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface IReplyRepository
    {
        IEnumerable<Reply> GetReplies();
        IEnumerable<Category> GetCategories();
        IEnumerable<ThreadUser> GetThreadUsers();
        IEnumerable<Thread> GetThreads();
    }
    

}