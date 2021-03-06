using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public interface ICategoryThreadService
    {
        IList<CategoryThread> GetCategoryThreads();

        Task<IList<CategoryThread>> GetCategoryThreadsAndThreadUsersByUserId(string userIdSub);

        Task<IList<CategoryThread>> GetCategoryThreadByCategoryId(int categoryId);

        Task<IList<CategoryThreadVM>> GetCategoryThreadByThreadType(bool threadType);

        Task<IList<CategoryThread>> GetGroupCategoryThreadByUserId(string userIdSub);

        Task<IList<CategoryThread>> GetCategoryThreadByUserId(string userId);

        Task<bool> AddCategoryThread(CategoryThread categoryThread);

        Task<IList<CategoryThread>> GetCategoryThreadById(int Id);

        Task<bool> DeleteCategoryThread(int id);

        Task<CategoryThread> EditCategoryThreadText(int id, string text);

    }
}
