using BlogSystem.Data.Contracts;
using BlogSystem.Data.Model;
using BlogSystem.Factories;
using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using Providers.Contracts;
using System;

namespace BlogSystem.Tests.Services.PostsServiceTests
{
    [TestFixture]
    public class CreatePostShould
    {
        [Test]
        public void CallGuidProvider()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Post>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedPostFactory = new Mock<IPostFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            var service = new PostsService
            (
                mockedRepository.Object,
                mockedPostFactory.Object,
                mockedContext.Object,
                mockedUserService.Object,
                mockedCategoryService.Object,
                mockedDateTimeProvider.Object,
                mockedGuidProvider.Object
             );
            // Act
            service.Create("title", "categoryId", "content", "imageUrl", "userId");

            // Assert
            mockedGuidProvider.Verify(r => r.CreateGuid(), Times.Once);
        }

        [Test]
        public void CallDateTimeProvider()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Post>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedPostFactory = new Mock<IPostFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            var service = new PostsService
            (
                mockedRepository.Object,
                mockedPostFactory.Object,
                mockedContext.Object,
                mockedUserService.Object,
                mockedCategoryService.Object,
                mockedDateTimeProvider.Object,
                mockedGuidProvider.Object
             );
            // Act
            service.Create("title", "categoryId", "content", "imageUrl", "userId");

            // Assert
            mockedDateTimeProvider.Verify(r => r.GetCurrentDate(), Times.Once);
        }

        [Test]
        public void CallUserService()
        {
            var userId = "userId";
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Post>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedPostFactory = new Mock<IPostFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            var service = new PostsService
            (
                mockedRepository.Object,
                mockedPostFactory.Object,
                mockedContext.Object,
                mockedUserService.Object,
                mockedCategoryService.Object,
                mockedDateTimeProvider.Object,
                mockedGuidProvider.Object
             );
            // Act
            service.Create("title", "categoryId", "content", "imageUrl", userId);

            // Assert
            mockedUserService.Verify(r => r.GetById(userId), Times.Once);
        }

        [Test]
        public void CallCategoryService()
        {
            var categoryId = "categoryId";
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Post>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedPostFactory = new Mock<IPostFactory>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            var service = new PostsService
            (
                mockedRepository.Object,
                mockedPostFactory.Object,
                mockedContext.Object,
                mockedUserService.Object,
                mockedCategoryService.Object,
                mockedDateTimeProvider.Object,
                mockedGuidProvider.Object
             );
            // Act
            service.Create("title", categoryId, "content", "imageUrl", "userId");

            // Assert
            mockedCategoryService.Verify(r => r.GetById(categoryId), Times.Once);
        }

        [Test]
        public void CallPostFactory()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Post>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedPostFactory = new Mock<IPostFactory>();

            var dateTime = DateTime.UtcNow;
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            mockedDateTimeProvider.Setup(p => p.GetCurrentDate()).Returns(dateTime);

            var guid = Guid.NewGuid();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            mockedGuidProvider.Setup(p => p.CreateGuid()).Returns(guid);

            var user = new Mock<User>();
            var mockedUserService = new Mock<IUserService>();
            mockedUserService.Setup(s => s.GetById("userId")).Returns(user.Object);

            var category = new Mock<Category>();
            var mockedCategoryService = new Mock<ICategoryService>();
            mockedCategoryService.Setup(s => s.GetById("categoryId")).Returns(category.Object);


            var service = new PostsService
            (
                mockedRepository.Object,
                mockedPostFactory.Object,
                mockedContext.Object,
                mockedUserService.Object,
                mockedCategoryService.Object,
                mockedDateTimeProvider.Object,
                mockedGuidProvider.Object
             );
            // Act
            service.Create("title", "categoryId", "content", "imageUrl", "userId");

            // Assert
            mockedPostFactory.Verify(r => r.CreatePost("title", category.Object, "content", "imageUrl", user.Object), Times.Once);
        }

        [Test]
        public void CallRepositoryAdd()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Post>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            var post = new Mock<Post>();
            var mockedPostFactory = new Mock<IPostFactory>();
            mockedPostFactory.Setup(f => f.CreatePost(It.IsAny<string>(), It.IsAny<Category>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<User>())).Returns(post.Object);

            var service = new PostsService
            (
                mockedRepository.Object,
                mockedPostFactory.Object,
                mockedContext.Object,
                mockedUserService.Object,
                mockedCategoryService.Object,
                mockedDateTimeProvider.Object,
                mockedGuidProvider.Object
             );
            // Act
            service.Create("title", "categoryId", "content", "imageUrl", "userId");

            // Assert
            mockedRepository.Verify(r => r.Add(post.Object), Times.Once);
        }

        [Test]
        public void CallContextSaveChanges()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Post>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedUserService = new Mock<IUserService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedPostFactory = new Mock<IPostFactory>();

            var service = new PostsService
            (
                mockedRepository.Object,
                mockedPostFactory.Object,
                mockedContext.Object,
                mockedUserService.Object,
                mockedCategoryService.Object,
                mockedDateTimeProvider.Object,
                mockedGuidProvider.Object
             );
            // Act
            service.Create("title", "categoryId", "content", "imageUrl", "userId");

            // Assert
            mockedContext.Verify(r => r.SaveChanges(), Times.Once);
        }
    }
}
