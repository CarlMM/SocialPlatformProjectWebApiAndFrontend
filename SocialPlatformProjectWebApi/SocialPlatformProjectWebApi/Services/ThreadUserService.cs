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

        public async Task<ThreadUser> AddThreadUser(int threadId, string userId)
        {
            var template = await _threadUserRepository.AddThreadUser(threadId, userId);
            return template;
        }
    }
}
