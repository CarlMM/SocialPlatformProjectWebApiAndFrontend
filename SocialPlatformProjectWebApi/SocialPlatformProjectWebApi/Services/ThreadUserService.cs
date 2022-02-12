using SocialPlatformProjectWebApi.Models;
using SocialPlatformProjectWebApi.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public class ThreadUserService : IThreadUserService
    {
        private readonly IThreadUserRepository _threadUserRepository;

        //public ThreadUserService(IEnumerable<IThreadUserRepository> threadUserRepository)
        //{
        //    this.threadUserRepository = (IThreadUserRepository)threadUserRepository;
        //}

        public ThreadUserService(IThreadUserRepository threadUserRepository)
        {
            _threadUserRepository = threadUserRepository;
        }

        public IEnumerable<ThreadUser> GetThreadUsers()
        {
            var template = _threadUserRepository.GetThreadUsers();
            return template;
        }

        public async Task<IList<ThreadUser>> GetThreadUsersByPostId(int categoryThreadId)
        {
            var template = await _threadUserRepository.GetThreadUsersByPostId(categoryThreadId);
            return template;
        }

        public async Task<IList<ThreadUser>> GetThreadUsersByCategoryThreadId(string userId)
        {
            var template = await _threadUserRepository.GetThreadUsersByCategoryThreadId(userId);
            return template;
        }

        public async Task<bool> AddThreadUser(int categoryThreadId, string userIdSub, string threadUserSubId)
        {
            var newThreadUser = new ThreadUser
            {
                CategoryThreadId = categoryThreadId,
                UserIdSub = userIdSub,
                IsAdmin = false,
            };

            return await _threadUserRepository.AddThreadUser(newThreadUser, threadUserSubId);
        }

        public async Task<bool> DeleteThreadUser(int categoryThreadID, string userIdSub, ThreadUser threadUser)
        {
            var result = await _threadUserRepository.DeleteThreadUser(categoryThreadID, userIdSub, threadUser);
            return result;
        }
    }
}
