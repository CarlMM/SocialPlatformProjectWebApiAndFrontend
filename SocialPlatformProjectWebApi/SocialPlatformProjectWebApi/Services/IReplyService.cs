using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;

namespace SocialPlatformProjectWebApi.Services
{
    public interface IReplyService
    {
        IEnumerable<Reply> GetReplies();
        IEnumerable<Category> GetCategories();
        IEnumerable<ThreadUser> GetThreadUsers();
    }
}