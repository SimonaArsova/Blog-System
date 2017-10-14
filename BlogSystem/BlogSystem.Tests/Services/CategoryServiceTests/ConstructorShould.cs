using BlogSystem.Data.Contracts;
using BlogSystem.Data.Model;
using BlogSystem.Factories;
using BlogSystem.Services;
using Moq;
using NUnit.Framework;
using Providers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Services.CategoryServiceTests
{
    [TestFixture]
    public class ConstructorShould
    {
        [Test]
        public void ThrowArgumentNullException_WhenRepositoryIsNull()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Category>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var categoryFactory = new Mock<ICategoryFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new CategoryService(null, mockedContext.Object, categoryFactory.Object, mockedGuidProvider.Object ));
        }

        [Test]
        public void ThrowArgumentNullException_WhenContextIsNull()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Category>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var categoryFactory = new Mock<ICategoryFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new CategoryService(mockedRepository.Object, null, categoryFactory.Object, mockedGuidProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenFactoryIsNull()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Category>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var categoryFactory = new Mock<ICategoryFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new CategoryService(mockedRepository.Object, mockedContext.Object, null, mockedGuidProvider.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenGuidProviderIsNull()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Category>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var categoryFactory = new Mock<ICategoryFactory>();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => new CategoryService(mockedRepository.Object, mockedContext.Object, categoryFactory.Object, null));
        }


        [Test]
        public void NotThrowException_WhenDependenciesAreCorrect()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Category>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var categoryFactory = new Mock<ICategoryFactory>();

            // Act, Assert
            Assert.DoesNotThrow(() => new CategoryService(mockedRepository.Object, mockedContext.Object, categoryFactory.Object, mockedGuidProvider.Object));
        }

        [Test]
        public void InitializeProperly_WhenProperDependanciesAreProvided()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Category>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();

            // Act, Assert
            var categoryService = new CategoryService(mockedRepository.Object, mockedContext.Object, mockedCategoryFactory.Object ,mockedGuidProvider.Object);

            Assert.IsNotNull(categoryService);
        }
    }
}
