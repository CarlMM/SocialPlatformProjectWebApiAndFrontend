using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using SocialPlatformProjectWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReplyController : Controller
    {
        private readonly IReplyService _replyService;

        public ReplyController(IReplyService replyService)
        {
            _replyService = replyService;
        }

        [HttpGet]
        [Route("GetReplies")]
        public async Task<IEnumerable<Reply>> GetReplies()
        {
            var template = await _replyService.GetReplies();
            return template;
        }

        [HttpGet]
        [Route("GetReply/{userId}")]
        public async Task<IList<Reply>> GetReply(int userId)
        {
            //if (id < 1)
            //{
            //    return BadRequest("Detta id är för lågt");
            //}

            var reply = await _replyService.GetReply(userId);
            return reply;

            //if (reply == null)
            //{
            //    return NotFound();
            //}

            //return await _replyService.GetReply(id);            
        }

        [HttpGet]
        [Route("GetReplyByCategoryThreadId/{categoryThreadId}")]
        public async Task<IList<Reply>> GetReplyByCategoryThreadId(int categoryThreadId)
        {
            var reply = await _replyService.GetReplyByCategoryThreadId(categoryThreadId);
            return reply;
        }

        [HttpPost]
        [Route("AddReply/{Reply}")]
        public async Task<Reply> AddReply([FromBody] Reply reply)
        {
            var template = await _replyService.AddReply(reply);
            return template;
        }

        [HttpDelete]
        [Route("DeleteReply/{id}")]
        public async Task<Reply> DeleteReply(int id)
        {
            var template = await _replyService.DeleteReply(id);
            return template;
        }

         [HttpPut]
         [Route("EditReply/{id, text}")]
         public async Task<Reply> EditReplyText(int id, string text)
        {
            var template = await _replyService.EditReplyText(id, text);
            return template;
        }
    }
}
