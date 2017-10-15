using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using BlogSystem.Web.Areas.User.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace BlogSystem.Tests.Controllers.UserControllerTests
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

            // Act, Assert
            var controller = new UserController(mockedPostsService.Object, mockedCategoryService.Object);

            controller
               .WithCallTo(c => c.Index())
               .ShouldRenderDefaultView();
        }
    }
}
