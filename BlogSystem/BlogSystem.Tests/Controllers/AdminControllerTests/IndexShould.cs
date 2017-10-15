using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using BlogSystem.Web.Areas.Admin.Controllers;
using BlogSystem.Web.Areas.User.Controllers;
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
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void ReturnCorrectView()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);

            controller
               .WithCallTo(c => c.Index())
               .ShouldRenderDefaultView();
        }
    }
}
