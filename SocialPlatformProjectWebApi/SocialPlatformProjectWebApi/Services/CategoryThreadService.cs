using SocialPlatformProjectWebApi.Repository;
using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<IList<CategoryThread>> GetCategoryThreadByCategoryId(int categoryId)
        {
            var template = await _categorythreadRepository.GetCategoryThreadByCategoryId(categoryId);
            return template;
        }

        public async Task<IList<CategoryThread>> GetCategoryThreadByThreadType(bool threadType)
        {
            var types = await _categorythreadRepository.GetCategoryThreadByThreadType(threadType);
            return types;
        }

        public async Task<IList<CategoryThread>> GetCategoryThreadByUserId(string userId)
        {
            var types = await _categorythreadRepository.GetCategoryThreadByUserId(userId);
            return types;
        }

        public async Task<IList<CategoryThread>> GetCategoryThreadById(int Id)
        {
            var types = await _categorythreadRepository.GetCategoryThreadById(Id);
            return types;
        }
    }
}
