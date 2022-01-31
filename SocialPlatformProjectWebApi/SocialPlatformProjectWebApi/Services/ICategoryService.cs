using SocialPlatformProjectWebApi.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocialPlatformProjectWebApi.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories();

    }
}