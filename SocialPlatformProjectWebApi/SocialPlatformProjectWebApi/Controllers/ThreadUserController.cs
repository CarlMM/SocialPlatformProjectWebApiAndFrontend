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

        [HttpGet] // admin
        [Route("GetThreadUsers")]
        public IEnumerable<ThreadUser> GetThreadUsers()
        {
            var template = _threadUserService.GetThreadUsers();
            return template;
        }

        [HttpGet] // admin, normal
        [Route("GetThreadUsersByCategoryId")]
        public async Task<IList<ThreadUser>> GetThreadUsersByCategoryThreadId(int categoryThreadId)
        {
            var template = await _threadUserService.GetThreadUsersByCategoryThreadId(categoryThreadId);
            return template;
        }
        //Comment For push dont mind
        [HttpPost] // admin, normal
        [Route("AddThreadUser")]
        public async Task<IActionResult> AddThreadUser(int categoryThreadId, string userIdSub, [FromBody] ThreadUser threadUser)
        {
            if (threadUser.IsAdmin == false)
            {
                return BadRequest("you are not admin");
            }
            await _threadUserService.AddThreadUser(categoryThreadId, userIdSub, threadUser);
            return Ok();
        }

        [HttpDelete] // admin, normal
        [Route("DeleteThreadUser")]
        public async Task<IActionResult> DeleteThreadUser(int categoryThreadId, string userIdSub, [FromBody] ThreadUser threadUser)
        {
            if(threadUser.IsAdmin == false)
            {
                return BadRequest("you are not admin");
            }
            await _threadUserService.DeleteThreadUser(categoryThreadId, userIdSub, threadUser);
            return Ok();
        }
    }
}
