using BlogSystem.Services;
using BlogSystem.Web.Infrastructure;
using BlogSystem.Web.Infrastructure.Attributes;
using BlogSystem.Web.Infrastructure.Factories;
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
        private readonly IViewModelFactory viewModelFactory;

        public AdminController(IPostsService postsService, IViewModelFactory viewModelFactory)
        {
            this.postsService = postsService;
            this.viewModelFactory = viewModelFactory;
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

            var viewModel = this.viewModelFactory.CreatePostsCollectionViewModel();

            viewModel.Posts = posts;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult DeletePost(Guid id)
        {
            this.postsService.DeletePost(id);
            return RedirectToAction("DeletePost");
        }

        [HttpGet]
        public ActionResult RestorePost()
        {
            var posts = this.postsService
                .GetDeleted()
                .MapTo<PostViewModel>()
                .ToList();

            var viewModel = this.viewModelFactory.CreatePostsCollectionViewModel();

            viewModel.Posts = posts;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult RestorePost(Guid id)
        {
            this.postsService.RestorePost(id);
            return RedirectToAction("RestorePost");
        }


    }
}
