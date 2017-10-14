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
    public class GetAllShould
    {
        [Test]
        public void CallRepositoryGetAll()
        {
            // Arrange
            var mockedRepository = new Mock<IEfRepository<Category>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();

            var categoryService = new CategoryService(mockedRepository.Object, mockedContext.Object, mockedCategoryFactory.Object, mockedGuidProvider.Object);

            //Act
            categoryService.GetAll();

            //Assert
            mockedRepository.Verify(r => r.All, Times.Once);
        }

        [Test]
        public void ReturnCorrectData()
        {
            // Arrange
            var categories = new List<Category> { new Category() }
                .AsQueryable();

            var mockedRepository = new Mock<IEfRepository<Category>>();
            mockedRepository.Setup(r => r.All).Returns(categories);
            var mockedContext = new Mock<ISaveContext>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();

            var categoryService = new CategoryService(mockedRepository.Object, mockedContext.Object, mockedCategoryFactory.Object, mockedGuidProvider.Object);

            //Act
            var result = categoryService.GetAll();

            //Assert
            Assert.AreEqual(categories, result);
        }
    }
}