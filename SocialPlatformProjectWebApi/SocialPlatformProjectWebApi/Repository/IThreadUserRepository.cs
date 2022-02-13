using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface IThreadUserRepository
    {
        IEnumerable<ThreadUser> GetThreadUsers();

        Task<bool> AddThreadUser(ThreadUser newThreadUser, string threadUserSubId);

        Task<bool> DeleteThreadUser(string userIdSubOfRequestingUser, int currentCategoryThreadId, string threadUserToBeRemoved);

        Task<IList<ThreadUser>> GetThreadUsersByCategoryThreadId(string userID);

        Task<IList<ThreadUser>> GetThreadUsersByPostId(int categoryThreadId);
    }
}
