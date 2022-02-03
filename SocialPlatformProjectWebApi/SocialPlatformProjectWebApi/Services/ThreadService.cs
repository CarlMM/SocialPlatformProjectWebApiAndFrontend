using SocialPlatformProjectWebApi.Repository;
using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public class ThreadService : IThreadService
    {
        private readonly IThreadRepository _threadRepository;

        public ThreadService(IThreadRepository threadRepository)
        {
            _threadRepository = threadRepository;

        }
        public IList<Thread> GetThreads()
        {
            var template = _threadRepository.GetThreads();
            return template;
        }

        public async Task<IList<Thread>> GetThreadByCategoryId(int categoryId)
        {
            var template = await _threadRepository.GetThreadByCategoryId(categoryId);
            return template;
        }

        public async Task<IList<Thread>> GetThreadByThreadType(bool threadType)
        {
            var types = await _threadRepository.GetThreadByThreadType(threadType);
            return types;
        }

        public async Task<IList<Models.Thread>> GetThreadByUserId(string userId)
        {
            var types = await _threadRepository.GetThreadByUserId(userId);
            return types;
        }
    }
}
