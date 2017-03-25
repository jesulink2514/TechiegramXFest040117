using System.Collections.Generic;
using System.Threading.Tasks;
using Techiegram.Models;

namespace Techiegram.Services
{
    public interface IFeedsService
    {
        Task<List<Post>> GetPostsForUserAsync(string userId,int page=1);
    }
}