using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using BlogSystem.Web.Infrastructure;
using BlogSystem.Web.Infrastructure.Attributes;
using BlogSystem.Web.Infrastructure.Factories;
using BlogSystem.Web.Models.Categories;
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
        private readonly ICategoryService categoryService;
        private readonly IViewModelFactory viewModelFactory;

        public AdminController(IPostsService postsService, ICategoryService categoryService, IViewModelFactory viewModelFactory)
        {
            this.postsService = postsService;
            this.categoryService = categoryService;
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

        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                this.categoryService.Create(category.Name);

                return this.RedirectToAction("Index", "Posts", new { area = "" });
            }
            else
            {
                return this.RedirectToAction("Index");
            }
        }


    }
}
