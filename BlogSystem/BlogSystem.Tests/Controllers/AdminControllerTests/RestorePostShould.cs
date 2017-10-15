using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using BlogSystem.Web.Areas.Admin.Controllers;
using BlogSystem.Web.Infrastructure.Factories;
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
    public class RestorePostShould
    {
        [Test]
        public void CallPostsServiceRestorePost()
        {
            // Arrange
            var id = Guid.NewGuid();
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.RestorePost(id);

            mockedPostsService.Verify(s => s.RestorePost(id), Times.Once);
        }

        [Test]
        public void RedirectToCorrectPage()
        {
            // Arrange
            var id = Guid.NewGuid();
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.RestorePost(id);

            controller
                .WithCallTo(c => c.RestorePost(id))
                .ShouldRedirectTo(c => c.RestorePost());
        }
    }
}
