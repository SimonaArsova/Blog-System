using BlogSystem.Data.Model;
using System;
using System.Linq;

namespace BlogSystem.Services
{
    public interface IPostsService
    {
        IQueryable<Post> GetAll();

        void DeletePost(Guid id);
    }
}