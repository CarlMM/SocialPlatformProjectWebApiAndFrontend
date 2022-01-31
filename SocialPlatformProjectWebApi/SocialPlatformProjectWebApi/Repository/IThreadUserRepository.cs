using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface IThreadUserRepository
    {
        IEnumerable<ThreadUser> GetThreadUsers();
    }
}
