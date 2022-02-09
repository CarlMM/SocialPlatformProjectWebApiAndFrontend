using Microsoft.AspNetCore.Mvc;
using SocialPlatformProjectWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialPlatformProjectWebApi.Services;

namespace SocialPlatformProjectWebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly socialplatformContext _dbContext;

        public UserRepository()
        {
            _dbContext = new socialplatformContext();
        }

        public async Task<IList<User>> GetUsers()
        {
            var result = await _dbContext.Users.ToListAsync();
            return result;
        }

        public async Task<User> DeleteUserByIdSub(string idSub)
        {
            var userDelete = await _dbContext.Users.SingleAsync(x => x.IdSub == idSub);
            _dbContext.Users.Remove(userDelete);
            await _dbContext.SaveChangesAsync();
            return userDelete;
        }

        public async Task<bool> AddUser(User user)
        {
            var users = _dbContext.Users.Where(x => x.IdSub == user.IdSub);
            bool has = users.Any(x => x.IdSub == user.IdSub);

            //var ifUserExists = _dbContext.Users.FirstAsync(x => x.IdSub == Id_sub);

            if (!has){
                await _dbContext.Users.AddAsync(user);
                return (await _dbContext.SaveChangesAsync() > 0);
            }
            else
            {
                throw new Exception($"användaren {user.Username} | {user.IdSub} finns redan");
            }

        }
    }
}
