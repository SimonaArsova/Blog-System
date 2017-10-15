using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using BlogSystem.Web.Areas.Admin.Controllers;
using BlogSystem.Web.Controllers;
using BlogSystem.Web.Infrastructure.Factories;
using BlogSystem.Web.Models.Categories;
using BlogSystem.Web.Models.Posts;
using Moq;
using NUnit.Framework;
using Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace BlogSystem.Tests.Controllers.AdminControllerTests
{
    [TestFixture]
    public class AddCategory
    {
        [Test]
        public void CallPostsServiceCreate()
        {
            // Arrange
            var category = new CategoryViewModel();

            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.AddCategory(category);

            mockedCategoryService.Verify(s => s.Create(category.Name), Times.Once);
        }

        [Test]
        public void RedirectToPosts()
        {
            // Arrange
            var category = new CategoryViewModel();

            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.AddCategory(category);

            controller
                .WithCallTo(c => c.AddCategory(category))
                .ShouldRedirectTo<PostsController>(c => c.Index());
        }
    }
}
