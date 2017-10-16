using BlogSystem.Data.Model;
using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using BlogSystem.Web.Areas.Admin.Controllers;
using BlogSystem.Web.Infrastructure.Factories;
using BlogSystem.Web.Models.Posts;
using Moq;
using NUnit.Framework;
using Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.FluentMVCTesting;

namespace BlogSystem.Tests.Controllers.AdminControllerTests
{
    [TestFixture]
    public class DeletePostShould
    {
        [Test]
        public void CallPostsServiceDeletePost()
        {
            // Arrange
            var id = Guid.NewGuid();
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.DeletePost(id);

            mockedPostsService.Verify(s => s.DeletePost(id), Times.Once);
        }

        [Test]
        public void RedirectToCorrectPage()
        {
            // Arrange
            var id = Guid.NewGuid();
            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.DeletePost(id);

            controller
                .WithCallTo(c => c.DeletePost(id))
                .ShouldRedirectTo(c => c.DeletePost());
        }

        [Test]
        public void CallPostsServiceGetAll()
        {
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
            

            // Arrange
            var mockedPostsService = new Mock<IPostsService>();
            mockedPostsService.Setup(m => m.GetAll()).Returns(list.AsQueryable());
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostsCollectionViewModel()).Returns(model);
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.DeletePost();

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
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostsCollectionViewModel()).Returns(model);
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.DeletePost();

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
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostsCollectionViewModel()).Returns(model);
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);

            controller
                .WithCallTo(c => c.DeletePost())
                .ShouldRenderDefaultView();
        }
    }
}
