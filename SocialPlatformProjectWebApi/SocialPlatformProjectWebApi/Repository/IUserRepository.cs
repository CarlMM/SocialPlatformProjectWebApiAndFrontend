using SocialPlatformProjectWebApi.Models;
using SocialPlatformProjectWebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();

        Task<User> DeleteUserByIdSub(string idSub);
    }
}
