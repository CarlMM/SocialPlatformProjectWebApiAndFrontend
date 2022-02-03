using Microsoft.EntityFrameworkCore;
using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public class ThreadRepository : IThreadRepository
    {

        private readonly socialplatformContext _dbContext;

        public ThreadRepository()
        {
            _dbContext = new socialplatformContext();
        }

        public IList<Thread> GetThreads()
        {
            var result = _dbContext.Threads;
            return result.ToList();
        }

        public async Task<IList<Thread>> GetThreadByCategoryId(int categoryId)
        {
            var template = await _dbContext.Threads.Where(x => x.CategoryId == categoryId).ToListAsync();
            return template;
        }

        public async Task<IList<Thread>> GetThreadByThreadType(bool threadType)
        {
            var types = await _dbContext.Threads.Where(x => x.ThreadType == threadType).ToListAsync();
            return types;
        }

        public async Task<IList<Thread>> GetThreadByUserId(string userId)
        {
            var result = await _dbContext.Threads.Where(x => x.UserIdSub == userId).ToListAsync();
            return result;
        }
    }
}
