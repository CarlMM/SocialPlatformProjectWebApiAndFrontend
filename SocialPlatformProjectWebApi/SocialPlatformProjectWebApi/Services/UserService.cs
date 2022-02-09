using SocialPlatformProjectWebApi.Models;
using SocialPlatformProjectWebApi.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IList<User>> GetUsers()
        {
            var template = await _userRepository.GetUsers();
            return template;
        }

        public async Task<User> DeleteUser(string idSub)
        {
            var template = await _userRepository.DeleteUserByIdSub(idSub);
            return template;
        }

        public async Task<bool> AddUser(string Id_sub, string userName, string email)
        {
            var newUser = new User
            {
                IdSub = Id_sub,
                Username = userName,
                Email = email,
            };

            return await _userRepository.AddUser(newUser);
        }
    }
}


