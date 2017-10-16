﻿using BlogSystem.Data.Model;
using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using BlogSystem.Web.Areas.Admin.Controllers;
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

namespace BlogSystem.Tests.Controllers.AdminControllerTests
{
    [TestFixture]
    public class EditPostShould
    {
        [Test]
        public void CallPostsServiceUpdate()
        {
            // Arrange
            var post = new PostViewModel();

            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.EditPost(post);

            mockedPostsService.Verify(s => s.Update(post.Id, post.Title, post.Content, post.Image), Times.Once);
        }

        [Test]
        public void RedirectToPosts()
        {
            // Arrange
            var post = new PostViewModel();
            var id = "id";

            var mockedPostsService = new Mock<IPostsService>();
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.EditPost(post);

            controller
                .WithCallTo(c => c.EditPost(post))
                .ShouldRedirectTo<PostsController>(c => c.Details(id));
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

            var model = new PostViewModel();

            List<Post> list = new List<Post>()
            {
                post
            };

            // Arrange
            var mockedGuidProvider = new Mock<IGuidProvider>();
            mockedGuidProvider.Setup(m => m.CreateGuidFromString("id")).Returns(id);
            var mockedPostsService = new Mock<IPostsService>();
            mockedPostsService.Setup(m => m.GetAll()).Returns(list.AsQueryable());
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostViewModel()).Returns(model);
           
            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.EditPost("id");

            mockedPostsService.Verify(s => s.GetAll(), Times.Once);
        }

        [Test]
        public void CallGuidProvider()
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

            var model = new PostViewModel();

            List<Post> list = new List<Post>()
            {
                post
            };

            // Arrange
            var mockedGuidProvider = new Mock<IGuidProvider>();
            mockedGuidProvider.Setup(m => m.CreateGuidFromString("id")).Returns(id);
            var mockedPostsService = new Mock<IPostsService>();
            mockedPostsService.Setup(m => m.GetAll()).Returns(list.AsQueryable());
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostViewModel()).Returns(model);

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.EditPost("id");

            mockedGuidProvider.Verify(s => s.CreateGuidFromString("id"), Times.Once);
        }

        [Test]
        public void CallViewModelFactory()
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

            var model = new PostViewModel();

            List<Post> list = new List<Post>()
            {
                post
            };

            // Arrange
            var mockedGuidProvider = new Mock<IGuidProvider>();
            mockedGuidProvider.Setup(m => m.CreateGuidFromString("id")).Returns(id);
            var mockedPostsService = new Mock<IPostsService>();
            mockedPostsService.Setup(m => m.GetAll()).Returns(list.AsQueryable());
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostViewModel(post.Id, post.Title,post.Category.Name,  post.Content, post.Image, post.Author.Email, (DateTime)post.CreatedOn)).Returns(model);

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);
            controller.EditPost("id");

            mockedViewModelFactory.Verify(s => s.CreatePostViewModel(post.Id, post.Title, post.Category.Name, post.Content, post.Image, post.Author.Email, (DateTime)post.CreatedOn), Times.Once);
        }

        [Test]
        public void RenderCorrectView()
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

            var model = new PostViewModel();

            List<Post> list = new List<Post>()
            {
                post
            };

            // Arrange
            var mockedGuidProvider = new Mock<IGuidProvider>();
            mockedGuidProvider.Setup(m => m.CreateGuidFromString("id")).Returns(id);
            var mockedPostsService = new Mock<IPostsService>();
            mockedPostsService.Setup(m => m.GetAll()).Returns(list.AsQueryable());
            var mockedCategoryService = new Mock<ICategoryService>();
            var mockedViewModelFactory = new Mock<IViewModelFactory>();
            mockedViewModelFactory.Setup(m => m.CreatePostViewModel(post.Id, post.Title, post.Category.Name, post.Content, post.Image, post.Author.Email, (DateTime)post.CreatedOn)).Returns(model);

            // Act, Assert
            var controller = new AdminController(mockedPostsService.Object, mockedCategoryService.Object, mockedViewModelFactory.Object, mockedGuidProvider.Object);

            controller
                .WithCallTo(c => c.EditPost("id"))
                .ShouldRenderDefaultView();
        }
    }
}
