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
        public async Task<IList<ThreadUser>> GetThreadUsersByCategoryThreadId(string userId)
        {
            var template = await _threadUserService.GetThreadUsersByCategoryThreadId(userId);
            return template;
        }

        [HttpGet]
        [Route("GetThreadUsersByPostId")]
        public async Task<IList<ThreadUser>> GetThreadUsersByPostId(int categoryThreadId)
        {
            var template = await _threadUserService.GetThreadUsersByPostId(categoryThreadId);
            return template;
        }
        //Comment For push dont mind
        [HttpPost] // admin, normal
        [Route("AddThreadUser")]
        public async Task<IActionResult> AddThreadUser(string threadUserSubId, int categoryThreadId, string userIdSub)
        {
            //if (threadUser.IsAdmin == false)
            //{
            //    return BadRequest("you are not admin");
            //}
            await _threadUserService.AddThreadUser(categoryThreadId, userIdSub, threadUserSubId);
            return Ok();
        }

        [HttpDelete] // admin, normal
        [Route("DeleteThreadUser")]
        public async Task<IActionResult> DeleteThreadUser(string userIdSubOfRequestingUser, int currentCategoryThreadId, string threadUserToBeRemoved)
        {
            //if(threadUserSubId.IsAdmin == false)
            //{
            //    return BadRequest("you are not admin");
            //}
            await _threadUserService.DeleteThreadUser(userIdSubOfRequestingUser, currentCategoryThreadId, threadUserToBeRemoved);
            return Ok();
        }
    }
}
