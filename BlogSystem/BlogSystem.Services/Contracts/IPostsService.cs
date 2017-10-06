using BlogSystem.Data.Model;
using System.Linq;

namespace BlogSystem.Services
{
    public interface IPostsService
    {
        IQueryable<Post> GetAll();
    }
}