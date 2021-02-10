using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UnitTestProject1.Fakes;
using UnitTestProject1.Utils;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace UnitTestProject1
{
    public class HomeTests
    {
        HomeController controller;
        HttpContextBase httpContext;

        [TestInitialize]
        public void Setup()
        {
            controller = new HomeController(new FakeMyDataLayer());
            httpContext = new HttpContextMock();

            // For mocking the session state
            controller.ControllerContext = new ControllerContext(httpContext, new RouteData(), controller);
        }

        [TestCleanup]
        public void CleanUp()
        {
            controller.Dispose();
            controller = null;
        }


        [TestClass]
        public class Index : HomeTests
        {
            [TestMethod]
            public void ReturnViewResult()
            {
                var result = controller.Index();

                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }

            [TestMethod]
            [DataRow(null)]
            [DataRow(1)]
            public void ReturnActionResult_WithVariousIds(int? id)
            {
                var result = controller.About(id);

                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(ActionResult));
            }
        }

        [TestClass]
        public class About : HomeTests
        {
            [TestMethod]
            public void ReturnsViewResult_WithNullId()
            {
                int? id = null;
                var result = controller.About(id);

                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }

            [TestMethod]
            public void ReturnNameInJsonResult_WithValidId()
            {
                var result = controller.About(1);

                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(JsonResult));

                var data = ((JsonResult)result).Data;

                Assert.IsInstanceOfType(data, typeof(ModelA));

                var name = ((ModelA)data).Name;
                Assert.AreEqual("TestName", name);
            }
        }

        [TestClass]
        public class Contact : HomeTests
        {
            [TestMethod]
            public void SetsCorrectSessionValue()
            {
                var result = controller.Contact();

                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(ActionResult));

                var userName = httpContext.Session["userName"];
                Assert.AreEqual("MyUserName", userName);
            }
        }

        [TestClass]
        public class GetListOfUsers : HomeTests
        {
            [TestMethod]
            public void ReturnsEmptyList_WithNullId()
            {
                var list = controller.GetListOfUsers(null);

                Assert.IsNotNull(list);
                Assert.AreEqual(0, list.Count);
            }

            [TestMethod]
            [DataRow(1)]
            [DataRow(3)]
            [DataRow(5)]
            public void ReturnsPopulatedList_WithAnyId(int id)
            {
                var list = controller.GetListOfUsers(id);

                Assert.IsNotNull(list);
                Assert.IsTrue(list.Count > 0);
            }

            [TestMethod]
            public void ReturnsSmallerPopulatedList_WithSpecificId()
            {
                var list = controller.GetListOfUsers(3);

                Assert.IsNotNull(list);
                Assert.AreEqual(3, list.Count);
            }
        }

        [TestClass]
        public class GetListAsync : HomeTests
        {
            [TestMethod]
            public void ReturnsAsyncList()
            {
                var taskResult = controller.GetListAsync();

                Assert.IsNotNull(taskResult);

                var result = taskResult.GetAwaiter().GetResult();

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Count > 0);
            }
        }

        [TestClass]
        public class GetListFromLayer : HomeTests
        {
            [TestMethod]
            public void ReturnsView_WithListModel()
            {
                var result = (ViewResult)controller.GetListFromLayer();
                var model = (List<string>)result.Model;

                Assert.IsNotNull(model);
                Assert.AreEqual(3, model.Count);
                Assert.AreEqual("Fake 1", model[0]);
            }
        }

        [TestClass]
        public class GetSpecificItemFromLayer : HomeTests
        {
            [TestMethod]
            public void ReturnsSpecificItemView()
            {
                var result = (ViewResult)controller.GetSpecificItemFromLayer(1);
                var model = (string)result.Model;

                Assert.IsNotNull(model);
                Assert.AreEqual("FakeItem1", model[0]);
            }
        }

    }
}
