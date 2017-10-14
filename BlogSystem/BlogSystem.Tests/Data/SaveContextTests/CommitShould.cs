
using BlogSystem.Data;
using BlogSystem.Data.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Tests.Data.SaveContextTests
{
    [TestFixture]
    public class CommitShould
    {
        [Test]
        public void CallDbContextSaveChanges()
        {
            // Arrange
            var mockedDbContext = new Mock<DbContext>();

            var unitOfWork = new SaveContext(mockedDbContext.Object);

            // Act
            unitOfWork.SaveChanges();

            // Assert
            mockedDbContext.Verify(c => c.SaveChanges(), Times.Once);
        }
    }
}
