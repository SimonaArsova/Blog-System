using AutoMapper;
using BlogSystem.Data.Model;
using BlogSystem.Services;
using BlogSystem.Web.Infrastructure;
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

        public PostsController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        // GET: Posts
        public ActionResult Index()
        {
            var posts = this.postsService
                .GetAll()
                .MapTo<PostViewModel>()
                .ToList();

            var viewModel = new PostsCollectionViewModel()
            {
                Posts = posts
            };

            return View(viewModel);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
    }
}
