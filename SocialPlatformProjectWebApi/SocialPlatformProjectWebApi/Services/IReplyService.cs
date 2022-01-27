using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading;

namespace SocialPlatformProjectWebApi.Services
{
    public interface IReplyService
    {
        IEnumerable<Reply> GetReplies();
        IEnumerable<Category> GetCategories();
        IEnumerable<ThreadUser> GetThreadUsers();
        IEnumerable<Thread> GetThreads();
    }
}