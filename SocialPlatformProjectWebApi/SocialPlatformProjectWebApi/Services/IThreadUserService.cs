using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public interface IThreadUserService
    {
        IEnumerable<ThreadUser> GetThreadUsers();

        Task<bool> AddThreadUser(int categoryThreadId, string userIdSub, string threadUserSubId);

        Task<bool> DeleteThreadUser(string userIdSubOfRequestingUser, int currentCategoryThreadId, string threadUserToBeRemoved);

        Task<IList<ThreadUser>> GetThreadUsersByCategoryThreadId(string userId);

        Task<IList<ThreadUser>> GetThreadUsersByPostId(int categoryThreadId);

    }
}
