using SocialPlatformProjectWebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public IList<Models.Thread> GetThreadByCategoryId(int categoryId)
        {
            var template = _threadRepository.GetThreadByCategoryId(categoryId);
            return template;
        }
    }
}
