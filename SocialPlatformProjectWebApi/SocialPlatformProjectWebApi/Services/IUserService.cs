using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public interface IUserService
    {
        Task<IList<User>> GetUsers();

        Task<User> DeleteUser(string idSub);

        Task<User> AddUser(string Id_sub, string userName, string email);
    }
}



