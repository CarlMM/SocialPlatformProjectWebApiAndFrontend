using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public interface ICategoryThreadService
    {
        IList<CategoryThread> GetCategoryThreads();

        Task<IList<CategoryThread>> GetCategoryThreadByCategoryId(int categoryId);

        Task<IList<CategoryThread>> GetCategoryThreadByThreadType(bool threadType);

        Task<IList<CategoryThread>> GetCategoryThreadByUserId(string userId);

        Task<IList<CategoryThread>> GetCategoryThreadById(int Id);
    }
}
