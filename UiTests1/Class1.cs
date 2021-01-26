using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UiTests1
{
    public class Class1
    {
        public Class1()
        {
            var driverService = FirefoxDriverService.CreateDefaultService(@"C:\Tools\geckodriver", "geckodriver.exe");

            using (var driver = new FirefoxDriver(driverService))
            {
                driver.Url = "https://www.google.com";

                Thread.Sleep(2000);

                driver.Close();
            }
        }

        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void Test2()
        {
            Assert.False(false);
        }
    }
}
