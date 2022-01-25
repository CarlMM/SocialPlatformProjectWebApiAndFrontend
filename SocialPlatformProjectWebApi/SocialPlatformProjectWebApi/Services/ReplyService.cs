using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using SocialPlatformProjectWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public class ReplyService : Controller
    {
        private readonly ReplyRepository _replyRepository;

        public ReplyService(ReplyRepository replyRepository) 
        {
            _replyRepository = replyRepository;
        }

        public IEnumerable<Reply> GetReplies()
        {
            var template = GetReplies();

            return template;
        }
    }
}
