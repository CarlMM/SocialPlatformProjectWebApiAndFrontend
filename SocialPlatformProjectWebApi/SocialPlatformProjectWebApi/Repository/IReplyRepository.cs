using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface IReplyRepository
    {
        
        Task<IEnumerable<Reply>> GetReplies();

        Task<IList<Reply>> GetReply(string userId);

        Task<bool> AddReply(Reply template);

        Task<bool> DeleteReply(int id);

        Task<IList<Reply>> GetReplyByCategoryThreadId(int categoryThreadId);

        Task<Reply> EditReplyText(int id, string text);

    }
    //public interface IRepository <T> where T : class
    //{
    //    Task<IEnumerable<T>> GetAll();
    //}
}