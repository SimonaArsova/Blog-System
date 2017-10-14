using NUnit.Framework;
using System;
using Moq;
using BlogSystem.Data;
using BlogSystem.Data.Contracts;

namespace BlogSystem.Tests.Data.SaveContextTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenDbContextIsNull()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => new SaveContext(null));
        }

        [Test]
        public void NotThrow_WhenDbContextIsProvided()
        {
            // Arrange
            var mockedDbContext = new Mock<IMsSqlDbContext>();

            // Act, Assert
            Assert.DoesNotThrow(() => new SaveContext(mockedDbContext.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDbContextIsProvided()
        {
            // Arrange
            var mockedDbContext = new Mock<IMsSqlDbContext>();

            // Act
            var unitOfWork = new SaveContext(mockedDbContext.Object);

            // Assert
            Assert.IsNotNull(unitOfWork);
        }
    }
}
