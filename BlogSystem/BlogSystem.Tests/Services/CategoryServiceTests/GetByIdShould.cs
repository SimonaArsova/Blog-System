using BlogSystem.Data.Contracts;
using BlogSystem.Data.Model;
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
    public class GetByIdShould
    {
        [Test]
        public void ReturnCorrectData()
        {
            // Arrange
            var mockedCategory = new Mock<Category>();
            var mockedRepository = new Mock<IEfRepository<Category>>();
            mockedRepository.Setup(r => r.GetById(It.IsAny<object>())).Returns(mockedCategory.Object);

            var mockedContext = new Mock<ISaveContext>();
            var mockedGuidProvider = new Mock<IGuidProvider>();

            var categoryService = new CategoryService(mockedRepository.Object, mockedContext.Object, mockedGuidProvider.Object);
            
            // Act
            var result = categoryService.GetById("categoryId");

            // Assert
            Assert.AreSame(mockedCategory.Object, result);
        }
    }
}
