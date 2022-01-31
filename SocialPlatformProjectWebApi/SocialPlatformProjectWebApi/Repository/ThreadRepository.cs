using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace SocialPlatformProjectWebApi.Repository
{
    public class ThreadRepository : IThreadRepository
    {

        private readonly SocialplatformContext _dbContext;

        public ThreadRepository()
        {
            _dbContext = new SocialplatformContext();
        }

        public IList<Models.Thread> GetThreads()
        {
            var result = _dbContext.Threads;
            return result.ToList();
        }
    }
}
