using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using SocialPlatformProjectWebApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialPlatformProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryThreadController : Controller
    {
        //Comment For Push
        private readonly ICategoryThreadService _categorythreadService;

        public CategoryThreadController(ICategoryThreadService categorythreadService)
        {
            _categorythreadService = categorythreadService;
        }
        // GET: api/<ThreadController>
        [HttpGet]
        //[Authorize(Policy = "GetThreads")] // Admin
        [Route("GetCategoryThreads")]
        public IList<CategoryThread> GetThreads()
        {
            var template = _categorythreadService.GetCategoryThreads();
            return template;
        }

        [HttpGet] //Admin & Normal
        [Authorize(Policy = "GetThreads&Replies&ThreadUsers")]
        [Route("GetCategoryThreadsAndRepliesAndThreadUsers")]
        public async Task<IList<CategoryThread>> GetCategoryThreadsAndThreadUsersByUserId(string userIdSub)
        {
            var template = await _categorythreadService.GetCategoryThreadsAndThreadUsersByUserId(userIdSub);
            return template;
        }

        [HttpGet] //Admin
        [Authorize(Policy = "GetThreadCategoryId")]
        [Route("GetCategoryThreadByCategoryId/{categoryId}")]
        public async Task<IList<CategoryThread>> GetCategoryThreadByCategoryId(int categoryId)
        {
            var template = await _categorythreadService.GetCategoryThreadByCategoryId(categoryId);
            return template;
        }

        [HttpGet] //Admin
       // [Authorize(Policy = "GetThreadByThreadType")]
        [Route("GetCategoryThreadByThreadType/{threadType}")]
        public async Task<IList<CategoryThread>> GetCategoryThreadByThreadType(bool threadType)
        {
            var types = await _categorythreadService.GetCategoryThreadByThreadType(threadType);
            return types;
        }

        [HttpGet] //Admin & Normal
        [Authorize(Policy = "GetGroupThreadByUserId")]
        [Route("GetGroupCategoryThreadByUserid")]
        public async Task<IList<CategoryThread>> GetGroupCategoryThreadByUserId(string userIdSub)
        {
            var result = await _categorythreadService.GetGroupCategoryThreadByUserId(userIdSub);
            return result;
        }

        [HttpGet] //Admin & Normal
        [Authorize(Policy = "GetThreadByUserId")]
        [Route("GetCategoryThreadByUserId/{userId}")]
        public async Task<IList<CategoryThread>> GetCategoryThreadByUserId(string userId)
        {
            var types = await _categorythreadService.GetCategoryThreadByUserId(userId);
            return types;
        }

        [HttpGet] //Admin & Normal
        //[Authorize(Policy = "GetThreadById")]
        [Route("GetCategoryThreadById/{id}")]
        public async Task<IList<CategoryThread>> GetCategoryThreadById(int id)
        {
            var types = await _categorythreadService.GetCategoryThreadById(id);
            return types;
        }


        [HttpPost] //Admin & Normal
        [Authorize(Policy = "PostThread")]
        [Route("AddCategoryThread/{Thread}")]
        public async Task<IActionResult> AddCategoryThread([FromBody] CategoryThread categoryThread)
        {
            await _categorythreadService.AddCategoryThread(categoryThread);
            return Ok();
        }

        [HttpDelete] //Admin & Normal
        [Authorize(Policy = "DeleteThread")]
        [Route("DeleteCategoryThread/{id}")]
        public async Task<IActionResult> DeleteCategoryThread(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid id");
            }
            else
            {
                await _categorythreadService.DeleteCategoryThread(id);
                return Ok();
            }
        }

        [HttpPut] //Admin & Normal
        [Authorize(Policy = "PutThreadText")]
        [Route("EditCategoryThreadText")]
        public async Task<CategoryThread> EditCategoryThreadText(int id, string text)
        {
            var template = await _categorythreadService.EditCategoryThreadText(id, text);
            return template;
        }
    }
}
