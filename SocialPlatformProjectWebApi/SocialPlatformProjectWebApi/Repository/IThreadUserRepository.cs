﻿using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface IThreadUserRepository
    {
        IEnumerable<ThreadUser> GetThreadUsers();

        Task<bool> AddThreadUser(ThreadUser threadUser);

        Task<bool> DeleteThreadUser(int categoryThreadID, string userIdSub);

        Task<IList<ThreadUser>> GetThreadUsersByCategoryId(int categoryThreadId);
    }
}
