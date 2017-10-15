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

namespace BlogSystem.Tests.Controllers.UserControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenPostsServiceIsNull()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UserController(null, mockedCategoryService.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCategoryServiceIsNull()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UserController(mockedPostsService.Object, null));
        }

        [Test]
        public void NotThrowException_WhenDependenciesAreValid()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();

            // Act, Assert
            Assert.DoesNotThrow(() => new UserController(mockedPostsService.Object, mockedCategoryService.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDependanciesAreProvided()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();

            // Act, Assert
            var controller = new UserController(mockedPostsService.Object, mockedCategoryService.Object);

            Assert.NotNull(controller);
        }
    }
}
