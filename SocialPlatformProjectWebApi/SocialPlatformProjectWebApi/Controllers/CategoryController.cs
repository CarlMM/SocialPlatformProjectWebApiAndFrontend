using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using SocialPlatformProjectWebApi.Services;
using System.Collections.Generic;

namespace SocialPlatformProjectWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("GetCategories")]
        public IEnumerable<Category> GetCategories()
        {
            var template = _categoryService.GetCategories();
            return template;
        }


    }
}
