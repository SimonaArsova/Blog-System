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
    public class UpdateShould
    {
        [Test]
        public void CallRepositoryAll()
        {
            var id = Guid.NewGuid();
            var user = new Mock<User>();
            var category = new Mock<Category>();
            var post = new Post
            {
                Id = id,
                Author = user.Object,
                Category = category.Object
            };

            var posts = new List<Post> { post }.AsQueryable();

            var mockedRepository = new Mock<IEfRepository<Post>>();
            mockedRepository.Setup(r => r.All).Returns(posts);
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

            service.Update(id, "title", "content", "image");

            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void CallRepositoryUpdate()
        {
            var id = Guid.NewGuid();
            var user = new Mock<User>();
            var category = new Mock<Category>();
            var post = new Post
            {
                Id = id,
                Author = user.Object,
                Category = category.Object
            };

            var posts = new List<Post> { post }.AsQueryable();

            var mockedRepository = new Mock<IEfRepository<Post>>();
            mockedRepository.Setup(r => r.All).Returns(posts);
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

            service.Update(id, "title", "content", "image");

            mockedRepository.Verify(r => r.Update(post), Times.Once);
        }

        [Test]
        public void CallContextSaveChanges()
        {
            var id = Guid.NewGuid();
            var user = new Mock<User>();
            var category = new Mock<Category>();
            var post = new Post
            {
                Id = id,
                Author = user.Object,
                Category = category.Object
            };

            var posts = new List<Post> { post }.AsQueryable();

            var mockedRepository = new Mock<IEfRepository<Post>>();
            mockedRepository.Setup(r => r.All).Returns(posts);
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

            service.Update(id, "title", "content", "image");

            mockedContext.Verify(r => r.SaveChanges(), Times.Once);
        }
    }
}
