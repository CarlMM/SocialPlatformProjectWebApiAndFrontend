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
        private readonly ReplyService _replyService;

        public ReplyController(ReplyService replyService)
        {
            _replyService = replyService;
        }

        [HttpGet]
        public IEnumerable<Reply> GetReplies()
        {
            var template = _replyService.GetReplies();

            return template;
        }
    }
}
