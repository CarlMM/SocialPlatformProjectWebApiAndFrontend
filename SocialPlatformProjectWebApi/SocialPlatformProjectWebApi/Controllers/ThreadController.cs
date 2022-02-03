using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using SocialPlatformProjectWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Thread = SocialPlatformProjectWebApi.Models.Thread;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialPlatformProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadController : Controller
    {

        private readonly IThreadService _threadService;

        public ThreadController(IThreadService threadService)
        {
            _threadService = threadService;
        }
        // GET: api/<ThreadController>
        [HttpGet]
        [Route("GetThreads")]
        public IList<Thread> GetThreads()
        {
            var template = _threadService.GetThreads();
            return template;
        }

        [HttpGet]
        [Route("GetThreadByCategoryId/{categoryId}")]
        public async Task<IList<Thread>> GetThreadByCategoryId(int categoryId)
        {
            var template = await _threadService.GetThreadByCategoryId(categoryId);
            return template;
        }

        [HttpGet]
        [Route("GetThreadByThreadType/{threadType}")]

        public async Task<IList<Models.Thread>> GetThreadByThreadType(bool threadType)
        {
            var types = await _threadService.GetThreadByThreadType(threadType);
            return types;
        }
    }
}
