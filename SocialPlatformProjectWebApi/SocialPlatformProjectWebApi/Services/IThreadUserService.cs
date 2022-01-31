using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;

namespace SocialPlatformProjectWebApi.Services
{
    public interface IThreadUserService
    {
        IEnumerable<ThreadUser> GetThreadUsers();
    }
}
