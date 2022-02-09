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

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IList<User>> GetUsers()
        {
            var template = await _userService.GetUsers();
            return template;
        }

        [HttpDelete]
        [Route("DeleteUserByIdSub/{idSub}")]
        public async Task<User> DeleteUser(string idSub)
        {
            var template = await _userService.DeleteUser(idSub);
            return template;
        }

        [HttpPost]
        [Route("AddUser")]
        public async Task<User> AddUser(string Id_sub, string userName, string email)
        {
            var template = await _userService.AddUser(Id_sub, userName, email);
            return template;    
        }
    }
}
