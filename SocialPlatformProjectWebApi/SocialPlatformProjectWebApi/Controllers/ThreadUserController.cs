using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy = "GetThreadUsers")]
        [Route("GetThreadUsers")] //Admin 
        public IEnumerable<ThreadUser> GetThreadUsers()
        {
            var template = _threadUserService.GetThreadUsers();
            return template;
        }
        [HttpGet]
        [Authorize(Policy = "GetThreadUsersByCategoryId")]
        [Route("GetThreadUsersByCategoryId")] //Admin & Normal
        public async Task<IList<ThreadUser>> GetThreadUsersByCategoryThreadId(string userId)
        {
            var template = await _threadUserService.GetThreadUsersByCategoryThreadId(userId);
            return template;
        }


        [HttpGet]
        [Authorize(Policy = "GetThreadUsersByPostId")]
        [Route("GetThreadUsersByPostId")]
        public async Task<IList<ThreadUser>> GetThreadUsersByPostId(int categoryThreadId)
        {
            var template = await _threadUserService.GetThreadUsersByPostId(categoryThreadId);
            return template;
        }
        
        [HttpPost] // admin, normal
        [Authorize(Policy = "AddThreadUser")]
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
        [Authorize(Policy = "DeleteThreadUser")]
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
