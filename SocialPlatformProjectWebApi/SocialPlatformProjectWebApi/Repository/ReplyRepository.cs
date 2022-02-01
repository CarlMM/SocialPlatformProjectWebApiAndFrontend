﻿using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
//using hej = Models.Thread;

namespace SocialPlatformProjectWebApi.Repository
{
    public class ReplyRepository : IReplyRepository/*, IRepository<Reply>*/
    {
        private readonly socialplatformContext _dbContext;

        public ReplyRepository()
        {
            _dbContext = new socialplatformContext();
        }

        //public Task<IEnumerable<Reply>> GetAll()
        //{
        //    var result = await _dbContext.Replies.ToListAsync();
        //    return result;
        //}

        public async Task<IEnumerable<Reply>> GetReplies()
        {
            var result = await _dbContext.Replies.ToListAsync();
            return result;           
        }

      
        public async Task<Reply> GetReply(int id)
        {
            var reply = await _dbContext.Replies.FirstOrDefaultAsync(x => x.Id == id);
            return reply;
        }      
    }
}
