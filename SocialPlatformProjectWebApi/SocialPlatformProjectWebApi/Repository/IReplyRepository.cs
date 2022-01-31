using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface IReplyRepository
    {
        
        Task<IEnumerable<Reply>> GetReplies();

        Task<Reply> GetReply(int id);

    }
    //public interface IRepository <T> where T : class
    //{
    //    Task<IEnumerable<T>> GetAll();
    //}
    

}