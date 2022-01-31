using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;

namespace SocialPlatformProjectWebApi.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
    }
}



