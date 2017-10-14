using BlogSystem.Data.Contracts;
using BlogSystem.Data.Model;
using BlogSystem.Services;
using Moq;
using NUnit.Framework;
using System;

namespace BlogSystem.Tests.Services.UserServiceTests
{
    [TestFixture]
    class ConsturctorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<User>>();
            var mockedContext = new Mock<ISaveContext>();
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(null, mockedContext.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenContextIsNull()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<User>>();
            var mockedContext = new Mock<ISaveContext>();
            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new UserService(mockedRepository.Object, null));
        }

        [Test]
        public void NotThrowException_WhenDependenciesAreCorrect()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<User>>();
            var mockedContext = new Mock<ISaveContext>();
            // Act, Assert
            Assert.DoesNotThrow(() => new UserService(mockedRepository.Object, mockedContext.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDependanciesAreProvided()
        {
            var mockedRepository = new Mock<IEfRepository<User>>();
            var mockedContext = new Mock<ISaveContext>();
            // Act, Assert
            var userService = new UserService(mockedRepository.Object, mockedContext.Object);

            Assert.IsNotNull(userService);
        }
    }
}
