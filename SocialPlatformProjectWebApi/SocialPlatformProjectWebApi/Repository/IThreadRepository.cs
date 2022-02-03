using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface IThreadRepository
    {
        IList<Models.Thread> GetThreads();

        Task<IList<Models.Thread>> GetThreadByCategoryId(int categoryId);

        Task<IList<Models.Thread>> GetThreadByThreadType(bool threadType);

        Task<IList<Models.Thread>> GetThreadByUserId(string userId);
    }
}
