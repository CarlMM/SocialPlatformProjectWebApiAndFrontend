﻿using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Repository
{
    public interface IThreadRepository
    {
        IList<Models.Thread> GetThreads();
    }
}
