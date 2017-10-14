using BlogSystem.Data.Contracts;
using BlogSystem.Data.Model;
using BlogSystem.Factories;
using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using Moq;
using NUnit.Framework;
using Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Services.PostsServiceTests
{
    [TestFixture]
    public class RestorePostShould
    {
        [Test]
        public void CallRepositoryDeleted()
        {
            Guid id = Guid.NewGuid();
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

            service.RestorePost(id);

            mockedRepository.Verify(r => r.Deleted, Times.Once);
        }

        [Test]
        public void CallRepositoryRestore()
        {
            var id = Guid.NewGuid();
            var user = new Mock<User>();
            var post = new Post
            {
                Id = id,
                Author = user.Object
            };
            var posts = new List<Post> { post }.AsQueryable();

            var mockedRepository = new Mock<IEfRepository<Post>>();
            mockedRepository.Setup(r => r.Deleted).Returns(posts);

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

            service.RestorePost(id);

            mockedRepository.Verify(r => r.Restore(post), Times.Once);
        }

        [Test]
        public void CallContextSaveChanges()
        {
            var id = Guid.NewGuid();
            var user = new Mock<User>();
            var post = new Post
            {
                Id = id,
                Author = user.Object
            };
            var posts = new List<Post> { post }.AsQueryable();

            var mockedRepository = new Mock<IEfRepository<Post>>();
            mockedRepository.Setup(r => r.Deleted).Returns(posts);

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

            service.RestorePost(id);

            mockedContext.Verify(r => r.SaveChanges(), Times.Once);
        }
    }
}
