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

        public IEnumerable<User> GetUsers()
        {
            var result = _dbContext.Users;
            return result;
        }

        public async Task<User> DeleteUserByIdSub(string idSub)
        {
            var userDelete = await _dbContext.Users.SingleAsync(x => x.IdSub == idSub);
            _dbContext.Users.Remove(userDelete);
            await _dbContext.SaveChangesAsync();
            return userDelete;
        }
    }
}
