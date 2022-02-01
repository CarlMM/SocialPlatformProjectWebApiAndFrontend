using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public interface IThreadService
    {
        IList<Models.Thread> GetThreads();

        Task<IList<Models.Thread>> GetThreadByCategoryId(int categoryId);
    }
}
