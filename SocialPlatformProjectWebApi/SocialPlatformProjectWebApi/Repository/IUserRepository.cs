using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;


namespace SocialPlatformProjectWebApi.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
    }
}
