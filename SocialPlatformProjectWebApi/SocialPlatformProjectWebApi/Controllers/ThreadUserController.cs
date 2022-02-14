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
        public async Task<IList<ThreadUser>> GetThreadUsersByCategoryThreadId(int categoryThreadId)
        {
            var template = await _threadUserService.GetThreadUsersByCategoryThreadId(categoryThreadId);
            return template;
        }

        [HttpPost]
        [Authorize(Policy = "AddThreadUser")]
        [Route("AddThreadUser")] //Admin & Normal
        public async Task<IActionResult> AddThreadUser(int categoryThreadId, string userIdSub)
        {
            await _threadUserService.AddThreadUser(categoryThreadId, userIdSub);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Policy = "DeleteThreadUser")]
        [Route("DeleteThreadUser")] //Admin & Normal
        public async Task<IActionResult> DeleteThreadUser(int categoryThreadId, string userIdSub)
        {
            await _threadUserService.DeleteThreadUser(categoryThreadId, userIdSub);
            return Ok();
        }
    }
}
