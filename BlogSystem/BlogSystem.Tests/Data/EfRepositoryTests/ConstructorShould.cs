using BlogSystem.Data;
using BlogSystem.Data.Contracts;
using BlogSystem.Data.Model;
using Moq;
using NUnit.Framework;
using Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Data.EfRepositoryTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenContextIsNull()
        {
            // Arrange
            var mockedContext = new Mock<MsSqlDbContext>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new EfRepository<Post>(null, mockedDateTimeProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenProviderIsNull()
        {
            // Arrange
            var mockedContext = new Mock<MsSqlDbContext>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new EfRepository<Post>(mockedContext.Object, null));
        }

        [Test]
        public void NotThrowException_WhenDependenciesAreCorrect()
        {
            // Arrange
            var mockedContext = new Mock<MsSqlDbContext>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            // Act, Assert
            Assert.DoesNotThrow(() => new EfRepository<Post>(mockedContext.Object, mockedDateTimeProvider.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDependanciesAreProvided()
        {
            // Arrange
            var mockedContext = new Mock<MsSqlDbContext>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            // Act, Assert
            var repository = new EfRepository<Post>(mockedContext.Object, mockedDateTimeProvider.Object);

            Assert.NotNull(repository);
        }
    }
}
