using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface IReplyRepository
    {
        IEnumerable<Reply> GetReplies();
    }
}