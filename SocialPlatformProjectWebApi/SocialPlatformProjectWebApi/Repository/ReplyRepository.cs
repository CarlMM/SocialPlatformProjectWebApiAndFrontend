using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public class ReplyRepository : Controller
    {
        private readonly SocialplatformContext _dbContext;

        public ReplyRepository()
        {
            _dbContext = new SocialplatformContext();
        }

        public IEnumerable<Reply> GetReplies()
        {
            var template = _dbContext.Replies;
            return (IEnumerable<Reply>)template;
        }
    }
}
