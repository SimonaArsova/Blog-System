using BlogSystem.Data.Model;
using BlogSystem.Data.Repositories;
using BlogSystem.Data.SaveContext;
using System;
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

        public IQueryable<Post> GetDeleted()
        {
            return this.postsRepo.Deleted;
        }

        public void DeletePost(Guid id)
        {
            var postToDelete = this.postsRepo.All.FirstOrDefault(post => post.Id == id);
            this.postsRepo.Delete(postToDelete);
            context.SaveChanges();
        }

        public void RestorePost(Guid id)
        {
            var postToRestore = this.postsRepo.Deleted.FirstOrDefault(post => post.Id == id);
            this.postsRepo.Restore(postToRestore);
            context.SaveChanges();
        }

    }
}
