using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using BlogSystem.Web.Areas.User.Controllers;
using BlogSystem.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using System;

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
            var mockedViewModelFactory = new Mock<IViewModelFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UserController(null, mockedCategoryService.Object, mockedViewModelFactory.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCategoryServiceIsNull()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();


            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UserController(mockedPostsService.Object, null, mockedViewModelFactory.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenViewModelFactoryIsNull()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();


            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UserController(mockedPostsService.Object, mockedCategoryService.Object, null));
        }

        [Test]
        public void NotThrowException_WhenDependenciesAreValid()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();


            // Act, Assert
            Assert.DoesNotThrow(() => new UserController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDependanciesAreProvided()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();


            // Act, Assert
            var controller = new UserController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object);

            Assert.NotNull(controller);
        }
    }
}
