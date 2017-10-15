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
    public class EditPostShould
    {
        [Test]
        public void CallPostsServiceUpdate()
        {
            // Arrange
            var post = new PostViewModel();

            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.EditPost(post);

            mockedPostsService.Verify(s => s.Update(post.Id, post.Title, post.Content, post.Image), Times.Once);
        }

        [Test]
        public void RedirectToPosts()
        {
            // Arrange
            var post = new PostViewModel();
            var id = "id";

            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.EditPost(post);

            controller
                .WithCallTo(c => c.EditPost(post))
                .ShouldRedirectTo<PostsController>(c => c.Details(id));
        }
    }
}
