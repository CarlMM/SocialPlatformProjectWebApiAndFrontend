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

        public async Task<IList<Reply>> GetReplyByCategoryThreadId(int categoryThreadId)
        {
            var reply = await _dbContext.Replies.Where(x => x.CategoryThreadId == categoryThreadId).ToListAsync();
            return reply;
        }

        public async Task<bool> AddReply(Reply template)
        {
            await _dbContext.AddAsync(template);
            return (await _dbContext.SaveChangesAsync() > 0);
        }

        public async Task<bool> DeleteReply(int id)
        {
            var deleteReply = await _dbContext.Replies.SingleAsync(x => x.Id == id);

            if(deleteReply == null)
            {
                return false;
            }

            _dbContext.Replies.Remove(deleteReply);
            return (await _dbContext.SaveChangesAsync() > 0);
        }

        public async Task<Reply> EditReplyText(int id, string text)
        {
            var editReply = await _dbContext.Replies.SingleAsync(x => x.Id == id);
            editReply.Text = text;

            await _dbContext.SaveChangesAsync();

            return editReply;
        }
    }
}
