using SocialPlatformProjectWebApi.Models;
using SocialPlatformProjectWebApi.Repository;
using System.Collections.Generic;


namespace SocialPlatformProjectWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            var template = _userRepository.GetUsers();
            return template;
        }

        //public ThreadUserService(IEnumerable<IThreadUserRepository> threadUserRepository)
        //{
        //    this.threadUserRepository = (IThreadUserRepository)threadUserRepository;
        //}
    }
    

}


