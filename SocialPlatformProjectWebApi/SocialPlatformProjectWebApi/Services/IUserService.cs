using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();

        Task<User> DeleteUser(string idSub);

    }
}



