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
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadUserController : ControllerBase
    {
        private readonly IThreadUserService _threadUserService;

        public ThreadUserController(IThreadUserService threadUserService)
        {
            _threadUserService = threadUserService;
        }

        [HttpGet]
        [Route("GetThreadUsers")]
        public IEnumerable<ThreadUser> GetThreadUsers()
        {
            var template = _threadUserService.GetThreadUsers();
            return template;
        }

        [HttpGet]
        [Route("GetThreadUsersByCategoryId")]
        public async Task<IList<ThreadUser>> GetThreadUsersByCategoryId(int categoryThreadId)
        {
            var template = await _threadUserService.GetThreadUsersByCategoryId(categoryThreadId);
            return template;
        }

        [HttpPost]
        [Route("AddThreadUser")]
        public async Task<IActionResult> AddThreadUser(int categoryThreadId, string userIdSub)
        {
            await _threadUserService.AddThreadUser(categoryThreadId, userIdSub);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteThreadUser")]
        public async Task<IActionResult> DeleteThreadUser(int categoryThreadId, string userIdSub)
        {
            await _threadUserService.DeleteThreadUser(categoryThreadId, userIdSub);
            return Ok();
        }
    }
}
