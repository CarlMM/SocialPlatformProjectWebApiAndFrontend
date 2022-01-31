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
    [Route("[controller]")]
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
        [Route("GetReply/{id}")]
        public async Task<ActionResult<Reply>>GetReply(int id)
        {
            if (id < 1)
            {
                return BadRequest("Detta id är för lågt");
            }
            
            var reply = await _replyService.GetReply(id);

            if (reply == null)
            {
                return NotFound();
            }
            return reply;


            //return await _replyService.GetReply(id);
            
        }


        [HttpGet]
        [Route("GetThreadUsers")]
        public IEnumerable<ThreadUser> GetThreadUsers()
        {
            var template = _replyService.GetThreadUsers();
            return template;
        }

        [HttpGet]
        [Route("GetThreads")]
        public IList<Models.Thread> GetThreads()
        {
            var template = _replyService.GetThreads();
            return template;
        }



    }
}
