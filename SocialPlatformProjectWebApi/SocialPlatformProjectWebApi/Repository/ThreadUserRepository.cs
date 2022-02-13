using Microsoft.EntityFrameworkCore;
using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;




namespace SocialPlatformProjectWebApi.Repository
{
    public class ThreadUserRepository : IThreadUserRepository
    {
        private readonly socialplatformContext _dbContext;

        public ThreadUserRepository()
        {
            _dbContext = new socialplatformContext();
        }

        public IEnumerable<ThreadUser> GetThreadUsers()
        {
            var result = _dbContext.ThreadUsers;
            return result;
        }

        public async Task<IList<ThreadUser>> GetThreadUsersByPostId(int categoryThreadId)
        {

            var result = await _dbContext.ThreadUsers.Where(x => x.CategoryThreadId == categoryThreadId).Include(y => y.UserIdSubNavigation).ToListAsync();

            List<ThreadUser> TUList = new();

            foreach (var item in result)
            {
                ThreadUser tU = new();
                tU.UserIdSubNavigation = new User();

                tU.CategoryThreadId = item.CategoryThreadId;
                tU.UserIdSub = item.UserIdSub;
                tU.UserIdSubNavigation.Username = item.UserIdSubNavigation.Username;

                TUList.Add(tU);
            }
            return TUList;
        }

        public async Task<IList<ThreadUser>> GetThreadUsersByCategoryThreadId(string userID)
        {
            var result = await _dbContext.ThreadUsers.Where(x => x.UserIdSub == userID).ToListAsync();            
            return result;
        }

        public async Task<bool> AddThreadUser(ThreadUser newThreadUser, string threadUserSubId)
        {
            var result = await _dbContext.ThreadUsers.Where(x => x.UserIdSub == threadUserSubId && x.CategoryThreadId == newThreadUser.CategoryThreadId).ToListAsync();

            for (int i = 0; i < result.Count; ++i)
            {
                if(result[i].UserIdSub == threadUserSubId)
                {
                    if(result[i].IsAdmin == true)
                    {
                        result = await _dbContext.ThreadUsers.Where(x => x.UserIdSub == newThreadUser.UserIdSub).ToListAsync();
                        var newCategoryThreadId = newThreadUser.CategoryThreadId;

                        for (int y = 0; y < result.Count; y++)
                        {
                            if (result[y].CategoryThreadId == newCategoryThreadId)
                                return false;
                        }
                        await _dbContext.ThreadUsers.AddAsync(newThreadUser);
                    }
                }
            }
            return (await _dbContext.SaveChangesAsync() > 0);
            //if (threadUser.IsAdmin == false  ) { return false; }
        }

        public async Task<bool> DeleteThreadUser(string userIdSubOfRequestingUser, int currentCategoryThreadId, string threadUserToBeRemoved)
        {
            var threadUsers = await _dbContext.ThreadUsers.Where(x => x.UserIdSub == userIdSubOfRequestingUser && x.CategoryThreadId == currentCategoryThreadId).ToListAsync();
            
            for (int i = 0; i < threadUsers.Count; ++i)
            {
                if(threadUsers[i].IsAdmin != true)
                {
                    return false;
                }                
            }

            var deleteThreadUser = await _dbContext.ThreadUsers.Where(x => x.UserIdSub == threadUserToBeRemoved && x.CategoryThreadId == currentCategoryThreadId).ToListAsync();

            if(deleteThreadUser == null)
            {
                return false;
            }

            for (int i = deleteThreadUser.Count - 1; i >= 0; i--)
            {
                _dbContext.ThreadUsers.Remove(deleteThreadUser[i]);
            }
            return (await _dbContext.SaveChangesAsync() > 0);                 
        }
    }
}
