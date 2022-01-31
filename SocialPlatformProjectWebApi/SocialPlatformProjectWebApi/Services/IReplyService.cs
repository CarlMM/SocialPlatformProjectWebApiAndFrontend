﻿using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public interface IReplyService
    {
        Task<IEnumerable<Reply>> GetReplies();         
        IList<Models.Thread> GetThreads();
        Task<Reply> GetReply(int id);
    }
}