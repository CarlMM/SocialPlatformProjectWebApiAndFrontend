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

        public async Task<User> AddUser(string Id_sub, string userName, string email)
        {
            var user = new User
            {
                IdSub = Id_sub,
                Username = userName,
                Email = email,
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
