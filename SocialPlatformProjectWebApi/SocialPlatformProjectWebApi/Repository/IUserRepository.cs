using SocialPlatformProjectWebApi.Models;
using SocialPlatformProjectWebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface IUserRepository
    {
        Task<IList<User>> GetUsers();

        Task<User> DeleteUserByIdSub(string idSub);

        Task<User> AddUser(string Id_sub, string userName, string email);
    }
}
