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

        public async Task<IEnumerable<Reply>> GetReplies()
        {
            var template = await _replyRepository.GetReplies();
            return template;
        }     

        public async Task<IList<Reply>> GetReply(int userId)
        {
            var template = await _replyRepository.GetReply(userId);
            return template;
        }

        public async Task<IList<Reply>> GetReplyByCategoryThreadId(int categoryThreadId)
        {
            var template = await _replyRepository.GetReplyByCategoryThreadId(categoryThreadId);
            return template;
        }


        public async Task<Reply> AddReply(Reply reply)
        {
            var template = await _replyRepository.AddReply(reply);
            return template;
        }

        public async Task<Reply> DeleteReply(int id)
        {
            var template = await _replyRepository.DeleteReply(id);
            return template;
        }
    }
}
