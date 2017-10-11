using BlogSystem.Data.Model;
using BlogSystem.Data.Repositories;
using BlogSystem.Data.SaveContext;
using BlogSystem.Services.Contracts;
using System;
using System.Linq;

namespace BlogSystem.Services
{
    public class PostsService : IPostsService
    {
        private readonly IEfRepository<Post> postsRepo;
        private readonly ISaveContext context;
        private readonly IUserService userService;

        public PostsService(IEfRepository<Post> postsRepo, ISaveContext context, IUserService userService)
        {
            this.postsRepo = postsRepo;
            this.context = context;
            this.userService = userService;
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

        public void Create(string title, string content, string userId)
        {
            Guid id = Guid.NewGuid();
            User user = this.userService.GetById(userId);
            DateTime createdOn = DateTime.Now;

            Post post = new Post(title, content, user);
            this.postsRepo.Add(post);
            context.SaveChanges();
        }

    }
}
