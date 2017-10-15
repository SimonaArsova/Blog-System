using AutoMapper;
using BlogSystem.Data.Model;
using BlogSystem.Services;
using BlogSystem.Web.Infrastructure;
using BlogSystem.Web.Infrastructure.Factories;
using BlogSystem.Web.Models.Posts;
using Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostsService postsService;
        private readonly IViewModelFactory viewModelFactory;
        private readonly IGuidProvider guidProvider;

        public PostsController(IPostsService postsService, IViewModelFactory viewModelFactory, IGuidProvider guidProvider)
        {
            if (postsService == null)
            {
                throw new ArgumentNullException(nameof(postsService));
            }
            if (viewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(viewModelFactory));
            }
            if (guidProvider == null)
            {
                throw new ArgumentNullException(nameof(guidProvider));
            }
            this.postsService = postsService;
            this.viewModelFactory = viewModelFactory;
            this.guidProvider = guidProvider;
        }

        // GET: Posts
        public ActionResult Index()
        {
            var posts = this.postsService
                .GetAll()
                //.Select(x => this.viewModelFactory.CreatePostViewModel(x.Id, x.Title, x.Category.Name, x.Content, x.Image, x.Author.Email, (DateTime)x.CreatedOn))
                //.MapTo<PostViewModel>()
                .ToList();

            var viewPosts = posts.Select(x => this.viewModelFactory.CreatePostViewModel(x.Id, x.Title, x.Category.Name, x.Content, x.Image, x.Author.Email, (DateTime)x.CreatedOn)).ToList();

            var viewModel = this.viewModelFactory.CreatePostsCollectionViewModel();

            viewModel.Posts = viewPosts;
            
            return View(viewModel);
        }

        // GET: Posts/Details/5
        public ActionResult Details(string id)
        {
            var guid = this.guidProvider.CreateGuidFromString(id);
            var post = this.postsService
                .GetAll()
                //.Select(x => this.viewModelFactory.CreatePostViewModel(x.Id, x.Title, x.Category.Name, x.Content, x.Image, x.Author.Email, (DateTime)x.CreatedOn))
                //.MapTo<PostViewModel>()
                .FirstOrDefault(p => p.Id == guid);

            var viewPost = this.viewModelFactory.CreatePostViewModel(post.Id, post.Title, post.Category.Name, post.Content, post.Image, post.Author.Email, (DateTime)post.CreatedOn);

            return View(viewPost);
        }

    }
}
