using BlogSystem.Web.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace BlogSystem.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    class IndexShould
    {
        [Test]
        public void ReturnCorrectView()
        {
            var controller = new HomeController();

            controller
               .WithCallTo(c => c.Index())
               .ShouldRenderDefaultView();
        }
    }
}
