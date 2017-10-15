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

namespace BlogSystem.Tests.Controllers.AdminControllerTests
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
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new AdminController(null, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenCategoryServiceIsNull()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new AdminController(mockedPostsService.Object ,null, mockedViewModelFactory.Object, mockedGuidProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenViewModelFactoryIsNull()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new AdminController(mockedPostsService.Object, mockedCategoryService.Object, null, mockedGuidProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenGuidProviderIsNull()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, null));
        }

        [Test]
        public void NotThrowException_WhenDependenciesAreValid()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            Assert.DoesNotThrow(() => new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDependanciesAreProvided()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);

            Assert.NotNull(controller);
        }

    }
}
