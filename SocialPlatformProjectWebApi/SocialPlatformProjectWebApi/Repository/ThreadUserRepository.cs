using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;

namespace SocialPlatformProjectWebApi.Repository
{
    public class ThreadUserRepository : IThreadUserRepository
    {
        private readonly SocialplatformContext _dbContext;

        public ThreadUserRepository()
        {
            _dbContext = new SocialplatformContext();
        }

        public IEnumerable<ThreadUser> GetThreadUsers()
        {
            var result = _dbContext.ThreadUsers;
            return result;
        }
    }
}
