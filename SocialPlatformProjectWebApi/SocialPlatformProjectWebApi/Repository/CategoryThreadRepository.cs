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

        public async Task<IList<CategoryThread>> GetGroupCategoryThreadByUserId(string userIdSub)
        {

            var getGroupCategoryThreadByUserId = await _dbContext.CategoryThreads
                .Where(x => x.UserIdSub == userIdSub && x.ThreadType == true).ToListAsync();

            return getGroupCategoryThreadByUserId;
        }

        public async Task<IList<CategoryThread>> GetCategoryThreadByUserId(string userId)
        {
            var result = await _dbContext.CategoryThreads.Where(x => x.UserIdSub == userId).ToListAsync();
            return result;
        }

        public async Task<IList<CategoryThread>> GetCategoryThreadById(int Id)
        {
            //Comment for push branch do not mind
            var types = await _dbContext.CategoryThreads.Where(x => x.Id == Id).ToListAsync();
            return types;
        }

        public async Task<bool> AddCategoryThread(CategoryThread newTemplate)
        {       
            //Do we need to control that the user exists before the creating thread user
            await _dbContext.CategoryThreads.AddAsync(newTemplate);
            await _dbContext.SaveChangesAsync();

            var newThreadUser = new ThreadUser
            {
                CategoryThreadId = newTemplate.Id,
                UserIdSub = newTemplate.UserIdSub,
            };

            await _dbContext.ThreadUsers.AddAsync(newThreadUser);
            return (await _dbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> DeleteCategoryThread(int id)
        {
            var deleteCategoryThread = await _dbContext.CategoryThreads.SingleAsync(x => x.Id == id);

            if (deleteCategoryThread == null)
            {
                return false;
            }

            _dbContext.CategoryThreads.Remove(deleteCategoryThread);
            return (await _dbContext.SaveChangesAsync() > 0);

            //try
            //{
            //    var deleteCategoryThread = await _dbContext.CategoryThreads.SingleAsync(x => x.Id == id);
            //    _dbContext.CategoryThreads.Remove(deleteCategoryThread);
            //    await _dbContext.SaveChangesAsync();
            //    return true;         
            //}
            //catch
            //{
            //    throw new Exception("something went wrong in the repository");
            //}
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
