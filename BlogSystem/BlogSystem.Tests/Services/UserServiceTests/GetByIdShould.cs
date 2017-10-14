using BlogSystem.Data.Contracts;
using BlogSystem.Data.Model;
using BlogSystem.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Services.UserServiceTests
{
    [TestFixture]
    public class GetByIdShould
    {
        [Test]
        public void CallRepositoryGetById()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<User>>();
            var mockedContext = new Mock<ISaveContext>();

            var service = new UserService(mockedRepository.Object, mockedContext.Object);

            // Act
            service.GetById("userId");

            // Assert
            mockedRepository.Verify(r => r.GetById("userId"), Times.Once);
        }

        [Test]
        public void ReturnCorrectData()
        {
            // Arrange
            var mockedUser = new Mock<User>();
            var mockedRepository = new Mock<IEfRepository<User>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(mockedUser.Object);
            var mockedContext = new Mock<ISaveContext>();

            var service = new UserService(mockedRepository.Object, mockedContext.Object);

            // Act
            var result = service.GetById("userId");

            // Assert
            Assert.AreSame(mockedUser.Object, result);
        }
    }
}
