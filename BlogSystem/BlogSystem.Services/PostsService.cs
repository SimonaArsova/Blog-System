using BlogSystem.Data.Model;
using BlogSystem.Data.Repositories;
using BlogSystem.Data.SaveContext;
using System.Linq;

namespace BlogSystem.Services
{
    public class PostsService : IPostsService
    {
        private readonly IEfRepository<Post> postsRepo;
        private readonly ISaveContext context;

        public PostsService(IEfRepository<Post> postsRepo, ISaveContext context)
        {
            this.postsRepo = postsRepo;
            this.context = context;
        }
        public IQueryable<Post> GetAll()
        {
            return this.postsRepo.All;
        }
    }
}
