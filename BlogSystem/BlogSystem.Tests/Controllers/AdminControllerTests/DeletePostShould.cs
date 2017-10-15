using AutoMapper;
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
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
           
        }
    }
}
