using Microsoft.EntityFrameworkCore;
using SocialPlatformProjectWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SocialPlatformProjectWebApi.Repository
{
    public class CategoryThreadRepository : ICategoryThreadRepository
    {

        private readonly socialplatformContext _dbContext;

        public CategoryThreadRepository()
        {
            _dbContext = new socialplatformContext();
        }

        public IList<CategoryThread> GetCategoryThreads()
        {
            var result = _dbContext.CategoryThreads;
            return result.ToList();
        }

        public async Task<IList<CategoryThread>> GetCategoryThreadByCategoryId(int categoryId)
        {
            var template = await _dbContext.CategoryThreads.Where(x => x.CategoryId == categoryId).ToListAsync();
            return template;
        }

        public async Task<IList<CategoryThread>> GetCategoryThreadByThreadType(bool threadType)
        {
            var types = await _dbContext.CategoryThreads.Where(x => x.ThreadType == threadType).ToListAsync();
            return types;
        }

        public async Task<IList<CategoryThread>> GetCategoryThreadByUserId(string userId)
        {
            var result = await _dbContext.CategoryThreads.Where(x => x.UserIdSub == userId).ToListAsync();
            return result;
        }

        public async Task<IList<CategoryThread>> GetGroupCategoryThreadByUserId(string IdSub)
        {
            var getGroupCategoryThreadByUserId = await _dbContext.CategoryThreads.Where(x => x.UserIdSub == IdSub)
                .Where(x => x.ThreadType == true).ToListAsync();

            return getGroupCategoryThreadByUserId;
        }


        public async Task<CategoryThread> AddCategoryThread(CategoryThread categoryThread)
        {
            DateTime date = DateTime.UtcNow.Date;

            //var user = new ThreadUser
            //{
            //    CategoryThreadId = categoryThread.Id,
            //    UserIdSub = categoryThread.UserIdSub,
            //};

            //_dbContext.ThreadUsers.Add(user);
            //await _dbContext.AddAsync(user);

            var template = new CategoryThread
            {

                Title = categoryThread.Title,
                Text = categoryThread.Text,
                CreatedDate = date,
                CategoryId = categoryThread.CategoryId,
                ThreadType = categoryThread.ThreadType,
                UserIdSub = categoryThread.UserIdSub,
            };

            await _dbContext.AddAsync(template);
            await _dbContext.SaveChangesAsync();

            return template;
        }

        public async Task<IList<CategoryThread>> GetCategoryThreadById(int Id)
        {
            //PUSH FOR BRANCH COMMENT DO NOT MIND THIS
            var types = await _dbContext.CategoryThreads.Where(x => x.Id == Id).ToListAsync();
            return types;
        }

        public async Task<CategoryThread> DeleteCategoryThread(int id)
        {
            var deleteCategoryThread = await _dbContext.CategoryThreads.SingleAsync(x => x.Id == id);
            _dbContext.CategoryThreads.Remove(deleteCategoryThread);
            await _dbContext.SaveChangesAsync();
            return deleteCategoryThread;
        }

        public async Task<CategoryThread> EditCategoryThreadText(int id, string text)
        {
            var editCategoryThread = await _dbContext.CategoryThreads.SingleAsync(x => x.Id == id);
            editCategoryThread.Text = text;
            await _dbContext.SaveChangesAsync();

            //Option to only return Id and Text, not the complete object
            //var template = new CategoryThread
            //{
            //    Id = editCategoryThread.Id,
            //    Text = editCategoryThread.Text,
            //};
            //return template;

            return editCategoryThread;
        }
    }
}
