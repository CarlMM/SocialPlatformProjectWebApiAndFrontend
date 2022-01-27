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
    [Route("[controller]")]
    public class SocialPlatformController : Controller
    {
        private readonly IReplyService _replyService;

        public SocialPlatformController(IReplyService replyService)
        {
            _replyService = replyService;

        }

        [HttpGet("{id}")]
        public IEnumerable<Reply> GetReplies()
        {
            var template = _replyService.GetReplies();

            return template;
        }
        [HttpGet]
        [Route("GetCategories")]
        public IEnumerable<Category> GetCategories()
        {
            var template = _replyService.GetCategories();

            return template;
        }
    }
}
