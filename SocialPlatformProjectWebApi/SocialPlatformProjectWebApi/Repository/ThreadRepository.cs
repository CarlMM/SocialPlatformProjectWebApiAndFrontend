using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Linq;


namespace SocialPlatformProjectWebApi.Repository
{
    public class ThreadRepository : IThreadRepository
    {

        private readonly socialplatformContext _dbContext;

        public ThreadRepository()
        {
            _dbContext = new socialplatformContext();
        }

        public IList<Models.Thread> GetThreads()
        {
            var result = _dbContext.Threads;
            return result.ToList();
        }
    }
}
