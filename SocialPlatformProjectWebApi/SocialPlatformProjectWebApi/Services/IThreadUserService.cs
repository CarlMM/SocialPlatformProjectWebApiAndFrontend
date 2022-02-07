using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public interface IThreadUserService
    {
        IEnumerable<ThreadUser> GetThreadUsers();

        Task<ThreadUser> AddThreadUser(int threadId, string userId);

        Task<IList<ThreadUser>> DeleteThreadUser(string UserIdSub);
    }
}
