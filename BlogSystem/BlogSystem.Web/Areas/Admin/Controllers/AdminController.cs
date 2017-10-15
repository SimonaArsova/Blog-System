using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using BlogSystem.Web.Infrastructure;
using BlogSystem.Web.Infrastructure.Attributes;
using BlogSystem.Web.Infrastructure.Factories;
using BlogSystem.Web.Models.Categories;
using BlogSystem.Web.Models.Posts;
using Providers;
using Providers.Contracts;
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
        private readonly IGuidProvider guidProvider;

        public AdminController(IPostsService postsService, ICategoryService categoryService, IViewModelFactory viewModelFactory,IGuidProvider guidProvider)
        {
            if(postsService == null)
            {
                throw new ArgumentNullException(nameof(postsService));
            }
            if (categoryService == null)
            {
                throw new ArgumentNullException(nameof(categoryService));
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
            this.categoryService = categoryService;
            this.viewModelFactory = viewModelFactory;
            this.guidProvider = guidProvider;
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

        [HttpGet]
        public ActionResult UpdatePost()
        {
            var posts = this.postsService
                .GetAll()
                .MapTo<PostViewModel>()
                .ToList();

            var viewModel = this.viewModelFactory.CreatePostsCollectionViewModel();

            viewModel.Posts = posts;

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult EditPost(string id)
        {
            var guid = this.guidProvider.CreateGuidFromString(id);
            var post = this.postsService
                .GetAll()
                .MapTo<PostViewModel>()
                .FirstOrDefault(p => p.Id == guid);

            return View(post);
        }

        [HttpPost]
        public ActionResult EditPost(PostViewModel model)
        {
            if (ModelState.IsValid)
            {
                this.postsService.Update(model.Id, model.Title, model.Content, model.Image);
                return this.RedirectToAction("Details", "Posts",  new { id = model.Id, area = ""});
            }
            else
            {
                return this.RedirectToAction("Update", new { id = model.Id });
            }
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
