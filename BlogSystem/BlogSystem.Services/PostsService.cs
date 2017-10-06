using BlogSystem.Data.Model;
using BlogSystem.Data.Repositories;
using System.Linq;

namespace BlogSystem.Services
{
    public class PostsService : IPostsService
    {
        private readonly IEfRepository<Post> postsRepo;

        public PostsService(IEfRepository<Post> postsRepo)
        {
            this.postsRepo = postsRepo;
        }
        public IQueryable<Post> GetAll()
        {
            return this.postsRepo.All;
        }
    }
}
