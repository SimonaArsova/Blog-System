using BlogSystem.Services;
using BlogSystem.Web.Infrastructure;
using BlogSystem.Web.Infrastructure.Attributes;
using BlogSystem.Web.Models.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.Web.Areas.Admin.Controllers
{
    [AuthorizeAdmin]
    public class AdminController : Controller
    {
        private readonly IPostsService postsService;

        public AdminController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        // GET: Admin/Admin
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

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            this.postsService.DeletePost(id);
            return RedirectToAction("Index");
        }
    }
}
