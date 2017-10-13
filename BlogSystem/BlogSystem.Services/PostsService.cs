using BlogSystem.Data.Model;
using BlogSystem.Data.Repositories;
using BlogSystem.Data.SaveContext;
using BlogSystem.Factories;
using BlogSystem.Services.Contracts;
using Providers.Contracts;
using System;
using System.Data.Entity;
using System.Linq;

namespace BlogSystem.Services
{
    public class PostsService : IPostsService
    {
        private readonly IEfRepository<Post> postsRepo;
        private readonly ISaveContext context;
        private readonly IUserService userService;
        private readonly ICategoryService categoryService;
        private readonly IPostFactory postFactory;
        private readonly IDateTimeProvider dateTimeProvider;
        private readonly IGuidProvider guidProvider;

        public PostsService
            (
            IEfRepository<Post> postsRepo, 
            IPostFactory postFactory, 
            ISaveContext context, 
            IUserService userService, 
            ICategoryService categoryService,
            IDateTimeProvider dateTimeProvider,
            IGuidProvider guidProvider
            )
        {
            this.postsRepo = postsRepo;
            this.postFactory = postFactory;
            this.context = context;
            this.userService = userService;
            this.categoryService = categoryService;
            this.dateTimeProvider = dateTimeProvider;
            this.guidProvider = guidProvider;
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
            var postToDelete = this.postsRepo.All
                .Include(x => x.Author)
                .Include(x => x.Category)
                .FirstOrDefault(post => post.Id == id);

            this.postsRepo.Delete(postToDelete);
            context.SaveChanges();
        }

        public void RestorePost(Guid id)
        {
            var postToRestore = this.postsRepo.Deleted
                .Include(x => x.Author)
                .Include(x => x.Category)
                .FirstOrDefault(post => post.Id == id);

            this.postsRepo.Restore(postToRestore);
            context.SaveChanges();
        }

        public void Create(string title, string categoryId, string content, string image, string userId)
        {
            Guid id = this.guidProvider.CreateGuid();
            User user = this.userService.GetById(userId);
            DateTime createdOn = this.dateTimeProvider.GetCurrentDate();
            Category category = this.categoryService.GetById(categoryId);
            
            Post post = this.postFactory.CreatePost(title, category, content, image, user);
            this.postsRepo.Add(post);
            context.SaveChanges();
        }

    }
}
