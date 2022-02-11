using SocialPlatformProjectWebApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface ICategoryThreadRepository
    {
        IList<CategoryThread> GetCategoryThreads();

        Task<IList<CategoryThread>> GetCategoryThreadsAndRepliesAndThreadUsers(int categoryThreadId);

        Task<IList<CategoryThread>> GetCategoryThreadByCategoryId(int categoryId);

        Task<IList<CategoryThread>> GetCategoryThreadByThreadType(bool threadType);

        Task<IList<CategoryThread>> GetGroupCategoryThreadByUserId(string userIdSub);

        Task<IList<CategoryThread>> GetCategoryThreadByUserId(string userId);

        Task<bool> AddCategoryThread(CategoryThread categoryThread);

        Task<IList<CategoryThread>> GetCategoryThreadById(int Id);

        Task<bool> DeleteCategoryThread(int id);

        Task<CategoryThread> EditCategoryThreadText(int id, string text);

    }
}
