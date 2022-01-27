using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public class ReplyRepository : IReplyRepository
    {
        private readonly SocialplatformContext _dbContext;

        public ReplyRepository()
        {
            _dbContext = new SocialplatformContext();
        }

        public IEnumerable<Reply> GetReplies()
        {
            var result = _dbContext.Replies;
            return result;
        }

        public IEnumerable<Category> GetCategories()
        {
            var result = _dbContext.Categories;
            return result;
        }

        public IEnumerable<ThreadUser> GetThreadUsers()
        {
            var result = _dbContext.ThreadUsers;
            return result;
        }

        public IEnumerable<Thread> GetThreads()
        {
            var result = _dbContext.Threads;
            return (IEnumerable<Thread>)result;
        }
    }
}
