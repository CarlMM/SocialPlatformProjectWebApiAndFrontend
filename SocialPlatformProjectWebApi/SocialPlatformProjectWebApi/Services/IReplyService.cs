using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public interface IReplyService
    {
        Task<IEnumerable<Reply>> GetReplies();
        Task<IList<Reply>> GetReply(string userId);
        Task<Reply> AddReply([FromBody] Reply reply);
        Task<bool> DeleteReply(int id);
        Task<IList<Reply>> GetReplyByCategoryThreadId(int categoryThreadId);
        Task<Reply> EditReplyText(int id, string text);
    }
}