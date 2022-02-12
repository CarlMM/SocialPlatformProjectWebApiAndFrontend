using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public interface IThreadUserService
    {
        IEnumerable<ThreadUser> GetThreadUsers();

        Task<bool> AddThreadUser(int categoryThreadId, string userIdSub, ThreadUser threadUser);

        Task<bool> DeleteThreadUser(int categoryThreadID, string userIdSub, ThreadUser threadUser);

        Task<IList<ThreadUser>> GetThreadUsersByCategoryThreadId(string userId);

        Task<IList<ThreadUser>> GetThreadUsersByPostId(int categoryThreadId);

    }
}
