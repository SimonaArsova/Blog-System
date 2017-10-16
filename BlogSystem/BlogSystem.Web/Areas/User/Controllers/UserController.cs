using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using BlogSystem.Web.Infrastructure;
using BlogSystem.Web.Infrastructure.Factories;
using BlogSystem.Web.Models.Categories;
using BlogSystem.Web.Models.Posts;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BlogSystem.Web.Areas.User.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IPostsService postsService;
        private readonly ICategoryService categoryService;
        private readonly IViewModelFactory viewModelFactory;

        public UserController(IPostsService postsService, ICategoryService categoryService, IViewModelFactory viewModelFactory)
        {
            if (postsService == null)
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

            this.postsService = postsService;
            this.categoryService = categoryService;
            this.viewModelFactory = viewModelFactory;
        }

        // GET: User/User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddPost()
        {
            var categories = this.categoryService
             .GetAll()
             //.MapTo<CategoryViewModel>()
             .ToList();

            var viewCategories = categories.Select(x => this.viewModelFactory.CreateCategoryViewModel(x.Id, x.Name)).ToList();

            SelectList list = new SelectList(viewCategories, "Id", "Name");

            var viewModel = new CreatePostViewModel()
            {
                Categories = list
            };
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddPost(CreatePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = User.Identity.GetUserId();
                this.postsService.Create(model.Title, model.Category, model.Content, model.Image, userId);

                return this.RedirectToAction("Index", "Posts", new { area = ""});
            }
            else
            {
                return this.RedirectToAction("AddPost");
            }
        }
    }
}