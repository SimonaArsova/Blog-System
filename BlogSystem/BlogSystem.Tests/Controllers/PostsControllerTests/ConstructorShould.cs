using BlogSystem.Services;
using BlogSystem.Web.Controllers;
using BlogSystem.Web.Infrastructure.Factories;
using Moq;
using NUnit.Framework;
using Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Controllers.PostsControllerTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenPostsServiceIsNull()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new PostsController(null, mockedViewModelFactory.Object, mockedGuidProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenModelFactoryIsNull()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new PostsController(mockedPostsService.Object, null, mockedGuidProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenGuidProviderIsNull()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new PostsController(mockedPostsService.Object, mockedViewModelFactory.Object, null));
        }

        [Test]
        public void NotThrowException_WhenDependenciesAreValid()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            Assert.DoesNotThrow(() => new PostsController(mockedPostsService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDependanciesAreProvided()
        {
            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new PostsController(mockedPostsService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);

            Assert.NotNull(controller);
        }
    }
}
