using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Controllers;
using Xunit;

namespace XunitTests
{
    public class HomeTests
    {
        HomeController controller;
        public HomeTests()
        {
            controller = new HomeController();

            var httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(x => x.Session["userName"]).Returns("MyUserName");

            controller.ControllerContext = new ControllerContext(httpContextMock.Object, new RouteData(), controller);
        }

        public class Index : HomeTests
        {
            [Fact]
            public void ReturnViewResult()
            {
                var result = controller.Index();

                Assert.NotNull(result);
                Assert.IsType<ViewResult>(result);
            }

            [Theory]
            [InlineData(null)]
            [InlineData(1)]
            public void ReturnActionResult_WithVariousIds(int? id)
            {
                var result = controller.About(id);

                Assert.NotNull(result);
                Assert.IsType<ViewResult>(result);
            }
        }

        public class Contact : HomeTests
        {
            [Fact]
            public void SetsCorrectSessionValue()
            {
                var result = controller.Contact();

                Assert.NotNull(result);
                Assert.IsType<ViewResult>(result);
            }
        }
    }
}
