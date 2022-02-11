using Microsoft.EntityFrameworkCore;
using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IList<ThreadUser>> GetThreadUsersByCategoryThreadId(int categoryThreadId)
        {
            var result = await _dbContext.ThreadUsers.Where(x => x.CategoryThreadId == categoryThreadId).ToListAsync();
            return result;
        }

        public async Task<bool> AddThreadUser(ThreadUser threadUser)
        {
            var result = await _dbContext.ThreadUsers.Where(x => x.UserIdSub == threadUser.UserIdSub).ToListAsync();

            var newCategoryThreadId = threadUser.CategoryThreadId;

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].CategoryThreadId == newCategoryThreadId)
                {
                    return false;
                }
            }
            await _dbContext.ThreadUsers.AddAsync(threadUser);
            return (await _dbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> DeleteThreadUser(int categoryThreadId, string userIdSub)
        {
            var deleteThreadUser = await _dbContext.ThreadUsers.Where(x => x.UserIdSub == userIdSub && x.CategoryThreadId == categoryThreadId).ToListAsync();

            if(deleteThreadUser == null)
            {
                return false;
            }

            for (int i = deleteThreadUser.Count - 1; i >= 0; i--)
            {
                _dbContext.ThreadUsers.Remove(deleteThreadUser[i]);
            }

            return (await _dbContext.SaveChangesAsync() > 0);                 
        }
    }
}
