using AutoMapper;
using BlogSystem.Data.Model;
using BlogSystem.Services;
using BlogSystem.Web.Infrastructure;
using BlogSystem.Web.Infrastructure.Factories;
using BlogSystem.Web.Models.Posts;
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


        public PostsController(IPostsService postsService, IViewModelFactory viewModelFactory)
        {
            this.postsService = postsService;
            this.viewModelFactory = viewModelFactory;
        }

        // GET: Posts
        public ActionResult Index()
        {
            var posts = this.postsService
                .GetAll()
                .MapTo<PostViewModel>()
                .ToList();

            var viewModel = this.viewModelFactory.CreatePostsCollectionViewModel();

            viewModel.Posts = posts;
            
            return View(viewModel);
        }

        // GET: Posts/Details/5
        public ActionResult Details(string id)
        {
            var post = this.postsService
                .GetAll()
                .MapTo<PostViewModel>()
                .FirstOrDefault(p => p.Id == new Guid(id));

            return View(post);
        }

    }
}
