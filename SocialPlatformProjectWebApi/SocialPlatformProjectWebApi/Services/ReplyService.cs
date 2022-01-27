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
    public class ReplyService : IReplyService
    {
        private readonly IReplyRepository _replyRepository;

        public ReplyService(IReplyRepository replyRepository)
        {
            _replyRepository = replyRepository;
        }

        public IEnumerable<Reply> GetReplies()
        {
            var template = _replyRepository.GetReplies();

            return template;
        }
        public IEnumerable<Category> GetCategories()
        {
            var template = _replyRepository.GetCategories();

            return template;
        }
    }
}
