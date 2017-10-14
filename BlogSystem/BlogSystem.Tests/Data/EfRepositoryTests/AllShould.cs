using BlogSystem.Data;
using BlogSystem.Data.Model;
using Moq;
using NUnit.Framework;
using Providers.Contracts;

namespace BlogSystem.Tests.Data.EfRepositoryTests
{
    [TestFixture]
    public class AllShould
    {
        [Test]
        public void CallContextSet()
        {
            // Arrange
            var mockedContext = new Mock<MsSqlDbContext>();
            var mockedDateTimeProvider = new Mock<IDateTimeProvider>();

            // Act, Assert
            var repository = new EfRepository<Post>(mockedContext.Object, mockedDateTimeProvider.Object);

            mockedContext.Verify(db => db.Set<Post>(), Times.Once);
        }
    }
}
