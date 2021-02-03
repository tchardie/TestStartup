using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Controllers;
using Xunit;

namespace XunitTests
{
    public class MyStaticTests
    {
        MyStaticController controller;
        public MyStaticTests()
        {
            controller = new MyStaticController();
        }

        public class Index : MyStaticTests
        {
            [Fact]
            public void ReturnsListInViewResult()
            {
                var result = controller.Index();

                Assert.NotNull(result);
                Assert.IsType<ViewResult>(result);
            }
        }
    }
}
