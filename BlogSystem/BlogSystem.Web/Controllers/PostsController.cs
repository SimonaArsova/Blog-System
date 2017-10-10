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

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Posts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
    }
}
