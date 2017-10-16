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
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace BlogSystem.Tests.Controllers.AdminControllerTests
{
    [TestFixture]
    public class UpdatePostShould
    {
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
            controller.UpdatePost();

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
            controller.UpdatePost();

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
                .WithCallTo(c => c.UpdatePost())
                .ShouldRenderDefaultView();
        }

    }
}
