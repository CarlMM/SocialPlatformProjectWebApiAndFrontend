using SocialPlatformProjectWebApi.Repository;
using SocialPlatformProjectWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IList<Models.Thread> GetThreads()
        {
            var template = _threadRepository.GetThreads();
            return template;
        }

        public async Task<IList<Models.Thread>> GetThreadByCategoryId(int categoryId)
        {
            var template = await _threadRepository.GetThreadByCategoryId(categoryId);
            return template;
        }
    }
}
