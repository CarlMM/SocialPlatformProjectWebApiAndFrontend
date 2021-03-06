using SocialPlatformProjectWebApi.Repository;
using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace SocialPlatformProjectWebApi.Services
{
    public class CategoryThreadService : ICategoryThreadService
    {
        private readonly ICategoryThreadRepository _categorythreadRepository;

        public CategoryThreadService(ICategoryThreadRepository categorythreadRepository)
        {
            _categorythreadRepository = categorythreadRepository;

        }
        public IList<CategoryThread> GetCategoryThreads()
        {
            var template = _categorythreadRepository.GetCategoryThreads();
            return template;
        }

        public async Task<IList<CategoryThread>> GetCategoryThreadsAndThreadUsersByUserId(string userIdSub)
        {
            var template = await _categorythreadRepository.GetCategoryThreadsAndThreadUsersByUserId(userIdSub);
            return template;
        }

        public async Task<IList<CategoryThread>> GetCategoryThreadByCategoryId(int categoryId)
        {
            var template = await _categorythreadRepository.GetCategoryThreadByCategoryId(categoryId);
            return template;
        }

        public async Task<IList<CategoryThreadVM>> GetCategoryThreadByThreadType(bool threadType)
        {
            var types = await _categorythreadRepository.GetCategoryThreadByThreadType(threadType);

            //var resultWithUsernames = types.SelectMany(x => x.ThreadUsers).Select(y => y.UserIdSubNavigation).Select(x => x.Username).ToList();
            return types;
        }

        public async Task<IList<CategoryThread>> GetCategoryThreadByUserId(string userId)
        {
            var types = await _categorythreadRepository.GetCategoryThreadByUserId(userId);
            return types;
        }

        public async Task<IList<CategoryThread>> GetGroupCategoryThreadByUserId(string IdSub)
        {
            var getGroupCategoryThreadByUserId = await _categorythreadRepository.GetGroupCategoryThreadByUserId(IdSub);
            return getGroupCategoryThreadByUserId;
        }

        public async Task<IList<CategoryThread>> GetCategoryThreadById(int Id)
        {
            var types = await _categorythreadRepository.GetCategoryThreadById(Id);
            return types;

        }

        public async Task<bool> AddCategoryThread(CategoryThread categoryThread)
        {
            DateTime date = DateTime.UtcNow.Date;
            var newTemplate = new CategoryThread
            {
                Title = categoryThread.Title,
                Text = categoryThread.Text,
                CreatedDate = date,
                CategoryId = categoryThread.CategoryId,
                ThreadType = categoryThread.ThreadType,
                UserIdSub = categoryThread.UserIdSub,
                
            };

            return await _categorythreadRepository.AddCategoryThread(newTemplate);
        }

        public async Task<bool> DeleteCategoryThread(int id)
        {
            var result = await _categorythreadRepository.DeleteCategoryThread(id);
            return result;
        }

        public async Task<CategoryThread> EditCategoryThreadText(int id, string text)
        {
            var template = await _categorythreadRepository.EditCategoryThreadText(id, text);
            return template;
        }    
    }
}
