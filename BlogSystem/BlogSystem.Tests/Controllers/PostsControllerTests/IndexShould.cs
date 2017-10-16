using BlogSystem.Data.Model;
using BlogSystem.Services;
using BlogSystem.Web.Controllers;
using BlogSystem.Web.Infrastructure.Factories;
using BlogSystem.Web.Models.Posts;
using Moq;
using NUnit.Framework;
using Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace BlogSystem.Tests.Controllers.PostsControllerTests
{
    [TestFixture]
    public class IndexShould
    {
        [Test]
        public void CallPostsServiceGetAll()
        {
            // Arrange
            var id = Guid.NewGuid();

            var user = new User();
            var category = new Category();
            var post = new Post()
            {
                Id = id,
                Author = user,
                Category = category
            };

            var model = new PostsCollectionViewModel();

            List<Post> list = new List<Post>()
            {
                post
            };

            var mockedPostsService = new Mock<IPostsService>();
            mockedPostsService.Setup(m => m.GetAll()).Returns(list.AsQueryable());
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostsCollectionViewModel()).Returns(model);
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new PostsController(mockedPostsService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);

            controller.Index();

            mockedPostsService.Verify(s => s.GetAll(), Times.Once);
        }

        [Test]
        public void CallViewModelFactory()
        {
            // Arrange
            var id = Guid.NewGuid();

            var user = new User();
            var category = new Category();
            var post = new Post()
            {
                Id = id,
                Author = user,
                Category = category
            };

            var model = new PostsCollectionViewModel();

            List<Post> list = new List<Post>()
            {
                post
            };

            var mockedPostsService = new Mock<IPostsService>();
            mockedPostsService.Setup(m => m.GetAll()).Returns(list.AsQueryable());
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostsCollectionViewModel()).Returns(model);
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new PostsController(mockedPostsService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);

            controller.Index();

            mockedViewModelFactory.Verify(s => s.CreatePostsCollectionViewModel(), Times.Once);
        }

        [Test]
        public void ReturnCorrectView()
        {
            // Arrange
            var id = Guid.NewGuid();

            var user = new User();
            var category = new Category();
            var post = new Post()
            {
                Id = id,
                Author = user,
                Category = category
            };

            var model = new PostsCollectionViewModel();

            List<Post> list = new List<Post>()
            {
                post
            };

            var mockedPostsService = new Mock<IPostsService>();
            mockedPostsService.Setup(m => m.GetAll()).Returns(list.AsQueryable());
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostsCollectionViewModel()).Returns(model);
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new PostsController(mockedPostsService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);

            controller
                .WithCallTo(c => c.Index())
                .ShouldRenderDefaultView();
        }
    }
}
