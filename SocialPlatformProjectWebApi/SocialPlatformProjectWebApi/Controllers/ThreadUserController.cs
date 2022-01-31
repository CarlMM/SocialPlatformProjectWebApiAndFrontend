using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using SocialPlatformProjectWebApi.Services;
using System.Collections.Generic;

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
    }
}
