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
    public class CreateShould
    {
        [Test]
        public void CallCategoryFactoryCreate()
        {
            // Arrange
            var category = "category";
            var mockedRepository = new Mock<IEfRepository<Category>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();

            var categoryService = new CategoryService(mockedRepository.Object, mockedContext.Object, mockedCategoryFactory.Object, mockedGuidProvider.Object);

            //Act
            categoryService.Create(category);

            //Assert
            mockedCategoryFactory.Verify(r => r.CreateCategory(category), Times.Once);
        }

        [Test]
        public void CallCategoryRepoAdd()
        {
            // Arrange
            var categoryName = "category";
            var category = new Category
            {
                Name = categoryName
            };
            var mockedRepository = new Mock<IEfRepository<Category>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();
            mockedCategoryFactory.Setup(f => f.CreateCategory(categoryName)).Returns(category);

            var categoryService = new CategoryService(mockedRepository.Object, mockedContext.Object, mockedCategoryFactory.Object, mockedGuidProvider.Object);

            //Act
            categoryService.Create(categoryName);

            //Assert
            mockedRepository.Verify(r => r.Add(category), Times.Once);
        }

        [Test]
        public void CallContextSaveChanges()
        {
            // Arrange
            var categoryName = "category";
            var category = new Category
            {
                Name = categoryName
            };
            var mockedRepository = new Mock<IEfRepository<Category>>();
            var mockedContext = new Mock<ISaveContext>();
            var mockedGuidProvider = new Mock<IGuidProvider>();
            var mockedCategoryFactory = new Mock<ICategoryFactory>();
            mockedCategoryFactory.Setup(f => f.CreateCategory(categoryName)).Returns(category);

            var categoryService = new CategoryService(mockedRepository.Object, mockedContext.Object, mockedCategoryFactory.Object, mockedGuidProvider.Object);

            //Act
            categoryService.Create(categoryName);

            //Assert
            mockedContext.Verify(r => r.SaveChanges(), Times.Once);
        }

    }
}
