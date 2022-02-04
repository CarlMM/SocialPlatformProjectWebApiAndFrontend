using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<ThreadUser> AddThreadUser(int threadId, string userId)
        {
            var user = new ThreadUser
            {
                CategoryThreadId = threadId,
                UserIdSub = userId
            };

            await _dbContext.ThreadUsers.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;

        }
    }
}
