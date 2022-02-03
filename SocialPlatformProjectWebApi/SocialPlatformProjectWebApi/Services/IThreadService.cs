using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public interface IThreadService
    {
        IList<Thread> GetThreads();

        Task<IList<Thread>> GetThreadByCategoryId(int categoryId);

        Task<IList<Thread>> GetThreadByThreadType(bool threadType);

        Task<IList<Models.Thread>> GetThreadByUserId(string userId);
    }
}
