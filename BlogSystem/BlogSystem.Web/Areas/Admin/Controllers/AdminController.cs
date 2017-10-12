using BlogSystem.Services;
using BlogSystem.Web.Infrastructure;
using BlogSystem.Web.Infrastructure.Attributes;
using BlogSystem.Web.Models.Posts;
using System;
using System.Linq;
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

        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult DeletePost()
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

        [HttpGet]
        public ActionResult RestorePost()
        {
            var posts = this.postsService
                .GetDeleted()
                .MapTo<PostViewModel>()
                .ToList();

            var viewModel = new PostsCollectionViewModel()
            {
                Posts = posts
            };

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Restore(Guid id)
        {
            this.postsService.RestorePost(id);
            return RedirectToAction("Index");
        }


    }
}
