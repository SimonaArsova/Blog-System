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
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace BlogSystem.Tests.Controllers.PostsControllerTests
{
    [TestFixture]
    public class DetailsShould
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

            var model = new PostViewModel();

            List<Post> list = new List<Post>()
            {
                post
            };

            var mockedGuidProvider = new Mock<IGuidProvider>();
            mockedGuidProvider.Setup(m => m.CreateGuidFromString("id")).Returns(id);
            var mockedPostsService = new Mock<IPostsService>();
            mockedPostsService.Setup(m => m.GetAll()).Returns(list.AsQueryable());
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostViewModel()).Returns(model);

            // Act, Assert
            var controller = new PostsController(mockedPostsService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);

            controller.Details("id");

            mockedPostsService.Verify(s => s.GetAll(), Times.Once);
        }

        [Test]
        public void CallPostsGuidProvider()
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

            var model = new PostViewModel();

            List<Post> list = new List<Post>()
            {
                post
            };

            var mockedGuidProvider = new Mock<IGuidProvider>();
            mockedGuidProvider.Setup(m => m.CreateGuidFromString("id")).Returns(id);
            var mockedPostsService = new Mock<IPostsService>();
            mockedPostsService.Setup(m => m.GetAll()).Returns(list.AsQueryable());
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostViewModel()).Returns(model);

            // Act, Assert
            var controller = new PostsController(mockedPostsService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);

            controller.Details("id");

            mockedGuidProvider.Verify(s => s.CreateGuidFromString("id"), Times.Once);
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

            var model = new PostViewModel();

            List<Post> list = new List<Post>()
            {
                post
            };

            var mockedGuidProvider = new Mock<IGuidProvider>();
            mockedGuidProvider.Setup(m => m.CreateGuidFromString("id")).Returns(id);
            var mockedPostsService = new Mock<IPostsService>();
            mockedPostsService.Setup(m => m.GetAll()).Returns(list.AsQueryable());
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostViewModel(post.Id, post.Title, post.Category.Name, post.Content, post.Image, post.Author.Email, (DateTime)post.CreatedOn)).Returns(model);

            // Act, Assert
            var controller = new PostsController(mockedPostsService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);

            controller.Details("id");

            mockedViewModelFactory.Verify(s => s.CreatePostViewModel(post.Id, post.Title, post.Category.Name, post.Content, post.Image, post.Author.Email, (DateTime)post.CreatedOn), Times.Once);
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

            var model = new PostViewModel();

            List<Post> list = new List<Post>()
            {
                post
            };

            var mockedGuidProvider = new Mock<IGuidProvider>();
            mockedGuidProvider.Setup(m => m.CreateGuidFromString("id")).Returns(id);
            var mockedPostsService = new Mock<IPostsService>();
            mockedPostsService.Setup(m => m.GetAll()).Returns(list.AsQueryable());
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostViewModel(post.Id, post.Title, post.Category.Name, post.Content, post.Image, post.Author.Email, (DateTime)post.CreatedOn)).Returns(model);

            // Act, Assert
            var controller = new PostsController(mockedPostsService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);

            controller
                .WithCallTo(c => c.Details("id"))
                .ShouldRenderDefaultView();
        }
    }
}
