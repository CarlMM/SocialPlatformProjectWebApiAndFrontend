using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using hej = Models.Thread;

namespace SocialPlatformProjectWebApi.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SocialplatformContext _dbContext;

        public CategoryRepository()
        {
            _dbContext = new SocialplatformContext();
        }

        public IEnumerable<Category> GetCategories()
        {
            var result = _dbContext.Categories;
            return result;
        }
      
    }
}
