using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;

namespace SocialPlatformProjectWebApi.Repository
{
    public class ThreadUserRepository : IThreadUserRepository
    {
        private readonly socialplatformContext _dbContext;

        public ThreadUserRepository()
        {
            _dbContext = new socialplatformContext();
        }

        public IEnumerable<ThreadUser> GetThreadUsers()
        {
            var result = _dbContext.ThreadUsers;
            return result;
        }
    }
}
