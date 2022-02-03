using Microsoft.AspNetCore.Mvc;
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
   
        public async Task<IList<Reply>> GetReply(int userId)
        {
            var reply = await _dbContext.Replies.Where(x => x.Id == userId).ToListAsync();
            return reply;
        }

        public async Task<Reply> AddReply(Reply reply)
        {
            DateTime date = DateTime.Now;

            //var incomingObject = reply;
            //_dbContext.Replies.AddAsync(incomingObject);
            //_dbContext.SaveChangesAsync();


            var template = new Reply
            {
                Text = reply.Text,
                CreatedDate = date,
                CategoryThreadId = reply.CategoryThreadId,
                UserIdSub = reply.UserIdSub,
            };

            await _dbContext.AddAsync(template);
            await _dbContext.SaveChangesAsync();

            return template;
        }
    }
}
