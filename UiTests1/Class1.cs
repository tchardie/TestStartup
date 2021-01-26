using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UiTests1
{
    /**
     * Builds new context for every test. See FixtureDemo for reusing the same context
     **/
    public class Class1 : IDisposable
    {
        private readonly IWebDriver _driver;
        public Class1()
        {
            var driverService = FirefoxDriverService.CreateDefaultService(@"C:\Tools\geckodriver", "geckodriver.exe");

            _driver = new FirefoxDriver(driverService);
        }

        public void Dispose()
        {
            _driver.Close();
        }

        [Fact]
        public void Test1()
        {
            _driver.Url = "https://google.com";
        }
    }
}
