﻿using Microsoft.AspNetCore.Http;
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
            var reply = await _replyService.GetReply(userId);
            return reply;

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
        public async Task<IActionResult> DeleteReply(int id)
        {
            if(id < 0)
            {
                return BadRequest("Not a valid id");
            }
            else
            {
                await _replyService.DeleteReply(id);
                return Ok();
            }

        }

         [HttpPut]
         [Route("EditReply")]
         public async Task<Reply> EditReplyText(int id, string text)
        {
            var template = await _replyService.EditReplyText(id, text);
            return template;
        }
    }
}
