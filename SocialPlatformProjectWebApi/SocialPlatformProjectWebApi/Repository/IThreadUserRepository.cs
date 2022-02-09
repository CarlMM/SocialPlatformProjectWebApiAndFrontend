using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface IThreadUserRepository
    {
        IEnumerable<ThreadUser> GetThreadUsers();

        Task<ThreadUser> AddThreadUser(int threadId, string userId);

        Task<bool> DeleteThreadUser(int categoryThreadID, string userIdSub);
    }
}
