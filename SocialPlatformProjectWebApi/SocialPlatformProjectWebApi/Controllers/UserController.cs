using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using SocialPlatformProjectWebApi.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet] // admin
        [Route("GetUsers")]
        public async Task<IList<User>> GetUsers()
        {
            var template = await _userService.GetUsers();
            return template;
        }

        [HttpDelete] // admin
        [Route("DeleteUserByIdSub/{idSub}")]
        public async Task<IActionResult> DeleteUser(string idSub)
        {
            await _userService.DeleteUser(idSub);
            return Ok();
        }

        [HttpPost] // admin
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(string Id_sub, string userName, string email)
        {
            await _userService.AddUser(Id_sub, userName, email);
            return Ok();    
        }
    }
}
