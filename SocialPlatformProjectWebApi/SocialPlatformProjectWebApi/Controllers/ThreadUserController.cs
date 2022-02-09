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

        [HttpPost]
        [Route("AddThreadUser")]
        public async Task<ThreadUser> AddThreadUser(int categoryThreadId, string userId)
        {
            var template = await _threadUserService.AddThreadUser(categoryThreadId, userId);
            return template;
        }

        [HttpDelete]
        [Route("DeleteThreadUser")]
        public async Task<IActionResult> DeleteThreadUser(int categoryThreadID, string userIdSub)
        {
            if(categoryThreadID < 1 || categoryThreadID > 3)
            {
                return BadRequest("Not a valid categoryId");
            }
            else
            {
                await _threadUserService.DeleteThreadUser(categoryThreadID, userIdSub);
                return Ok();
            }

        }
    }
}
