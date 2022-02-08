using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface ICategoryThreadRepository
    {
        IList<CategoryThread> GetCategoryThreads();

        Task<IList<CategoryThread>> GetCategoryThreadByCategoryId(int categoryId);

        Task<IList<CategoryThread>> GetCategoryThreadByThreadType(bool threadType);

        Task<IList<CategoryThread>> GetCategoryThreadByUserId(string userId);

        Task<CategoryThread> AddCategoryThread(CategoryThread categoryThread);

        Task<IList<CategoryThread>> GetCategoryThreadById(int Id);

        Task<CategoryThread> DeleteCategoryThread(int id);

        Task<CategoryThread> EditCategoryThreadText(int id, string text);
        Task<IList<CategoryThread>> GetGroupCategoryThreadByUserId(int categoryThreadId, string IdSub);

    }
}
