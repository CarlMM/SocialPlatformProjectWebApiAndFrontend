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

        public async Task<IList<ThreadUser>> GetThreadUsersByCategoryThreadId(string userId)
        {
            var template = await _threadUserRepository.GetThreadUsersByCategoryThreadId(userId);
            return template;
        }

        public async Task<bool> AddThreadUser(int categoryThreadId, string userIdSub)
        {
            var threadUser = new ThreadUser
            {
                CategoryThreadId = categoryThreadId,
                UserIdSub = userIdSub
            };

            return await _threadUserRepository.AddThreadUser(threadUser);
        }

        public async Task<bool> DeleteThreadUser(int categoryThreadID, string userIdSub)
        {
            var result = await _threadUserRepository.DeleteThreadUser(categoryThreadID, userIdSub);
            return result;
        }
    }
}
