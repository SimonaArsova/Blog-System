using BlogSystem.Data.Model;
using BlogSystem.Services;
using BlogSystem.Services.Contracts;
using BlogSystem.Web.Areas.User.Controllers;
using BlogSystem.Web.Models.Posts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Controllers.UserControllerTests
{
    [TestFixture]
    public class AddPostShould
    {
        //[Test]
        //public void CallPostsServiceCreate()
        //{
        //    // Arrange
        //    var post = new CreatePostViewModel();
        //    var user = new User();

        //    var mockedPostsService = new Mock<IPostsService>();
        //    var mockedCategoryService = new Mock<ICategoryService>();

        //    // Act, Assert
        //    var controller = new UserController(mockedPostsService.Object, mockedCategoryService.Object);
        //    controller.AddPost(post);

        //    mockedPostsService.Verify(s => s.Create(post.Title, "categoryId", post.Content, post.Image, "userId"), Times.Once);
        //}
    }
}
