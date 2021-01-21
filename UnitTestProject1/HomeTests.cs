using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class HomeTests
    {
        HomeController controller;

        [TestInitialize]
        public void Setup()
        {
            controller = new HomeController();
        }

        [TestCleanup]
        public void CleanUp()
        {
            controller.Dispose();
            controller = null;
        }

        [TestMethod]
        public void TestIndexGet()
        {
            var result = controller.Index();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow(1)]
        public void TestAboutWithDifferentInputs(int? id)
        {
            var result = controller.About(id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }

        [TestMethod]
        public void TestAboutWithNullId()
        {
            int? id = null;
            var result = controller.About(id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void TestAboutWithIdAndGetName()
        {
            var result = controller.About(1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(JsonResult));

            var data = ((JsonResult)result).Data;

            Assert.IsInstanceOfType(data, typeof(ModelA));

            var name = ((ModelA) data).Name;
            Assert.AreEqual("TestName", name);
        }
    }
}
