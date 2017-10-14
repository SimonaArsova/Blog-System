using BlogSystem.Data.Model;
using System;
using System.Linq;

namespace BlogSystem.Services
{
    public interface IPostsService
    {
        IQueryable<Post> GetAll();

        IQueryable<Post> GetDeleted();

        void DeletePost(Guid id);

        void RestorePost(Guid id);

        void Create(string title, string categoryId, string content, string image, string userId);

        void Update(Guid id, string title, string content, string image);
    }
}