using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using SocialPlatformProjectWebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        public IList<Models.Thread> GetThreads()
        {
            var template = _threadService.GetThreads();
            return template;
        }

        [HttpGet]
        [Route("GetThreadByCategoryId/{categoryId}")]
        public async Task<IList<Models.Thread>> GetThreadByCategoryId(int categoryId)
        {
            var template = await _threadService.GetThreadByCategoryId(categoryId);
            return template;
        }


    }
}
