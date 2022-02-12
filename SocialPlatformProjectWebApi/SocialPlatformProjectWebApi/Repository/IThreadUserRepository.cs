using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface IThreadUserRepository
    {
        IEnumerable<ThreadUser> GetThreadUsers();

        Task<bool> AddThreadUser(ThreadUser newThreadUser, ThreadUser threadUser);

        Task<bool> DeleteThreadUser(int categoryThreadID, string userIdSub, ThreadUser threadUser);

        Task<IList<ThreadUser>> GetThreadUsersByCategoryThreadId(int categoryThreadId);
    }
}
