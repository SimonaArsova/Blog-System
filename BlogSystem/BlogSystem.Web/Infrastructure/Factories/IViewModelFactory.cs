using BlogSystem.Web.Models.Categories;
using BlogSystem.Web.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSystem.Web.Infrastructure.Factories
{
    public interface IViewModelFactory
    {
        CategoryViewModel CreateCategoryViewModel();
        CategoriesCollectionViewModel CreateCategoriesCollectionViewModel();
        CreatePostViewModel CreateCreatePostViewModel();
        CreatePostViewModel CreateCreatePostViewModel(Guid id, string title, string category, string content, string image);
        PostViewModel CreatePostViewModel();
        PostViewModel CreatePostViewModel(Guid id, string title, string category, string content, string image, string authorEmail, DateTime postedOn);
        PostsCollectionViewModel CreatePostsCollectionViewModel();
    }
}