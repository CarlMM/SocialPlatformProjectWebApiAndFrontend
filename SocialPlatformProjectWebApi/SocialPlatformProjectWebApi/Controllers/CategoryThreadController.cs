﻿using Microsoft.AspNetCore.Authorization;
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

        private readonly ICategoryThreadService _categorythreadService;

        public CategoryThreadController(ICategoryThreadService categorythreadService)
        {
            _categorythreadService = categorythreadService;
        }
        // GET: api/<ThreadController>
        [HttpGet]
        [Authorize(Policy = "CheckThreads")]
        [Route("GetCategoryThreads")]
        public IList<CategoryThread> GetThreads()
        {
            var template = _categorythreadService.GetCategoryThreads();
            return template;
        }

        [HttpGet]
        [Route("GetCategoryThreadByCategoryId/{categoryId}")]
        public async Task<IList<CategoryThread>> GetCategoryThreadByCategoryId(int categoryId)
        {
            var template = await _categorythreadService.GetCategoryThreadByCategoryId(categoryId);
            return template;
        }

        [HttpGet]
        [Route("GetCategoryThreadByThreadType/{threadType}")]
        public async Task<IList<CategoryThread>> GetCategoryThreadByThreadType(bool threadType)
        {
            var types = await _categorythreadService.GetCategoryThreadByThreadType(threadType);
            return types;
        }

        [HttpGet]
        [Route("GetCategoryThreadByUserId/{userId}")]
        public async Task<IList<CategoryThread>> GetCategoryThreadByUserId(string userId)
        {
            var types = await _categorythreadService.GetCategoryThreadByUserId(userId);
            return types;
        }

        [HttpGet]
        [Route("GetCategoryThreadById/{id}")]
        public async Task<IList<CategoryThread>> GetCategoryThreadById(int id)
        {
            var types = await _categorythreadService.GetCategoryThreadById(id);
            return types;
        }

        [HttpGet]
        [Route("GetGroupCategoryThreadByUserId)")]
        public async Task<IList<CategoryThread>> GetGroupCategoryThreadByUserId(string IdSub)
        {
            var getGroupCategoryThreadByUserId = await _categorythreadService.GetGroupCategoryThreadByUserId(IdSub);
            return getGroupCategoryThreadByUserId;
        }


        [HttpPost]
        [Route("AddCategoryThread/{CategoryThread}")]
        public async Task<CategoryThread> AddCategoryThread([FromBody] CategoryThread categoryThread)
        {
            var template = await _categorythreadService.AddCategoryThread(categoryThread);
            return template;
        }

        [HttpDelete]
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

        [HttpPut]
        [Route("EditCategoryThreadText")]

        public async Task<CategoryThread> EditCategoryThreadText(int id, string text)
        {
            var template = await _categorythreadService.EditCategoryThreadText(id, text);
            return template;
        }
    }
}
