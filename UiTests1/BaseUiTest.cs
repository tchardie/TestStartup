using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace UiTests1
{
    public abstract class BaseUiTest : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public BaseUiTest()
        {
            var driverService = FirefoxDriverService.CreateDefaultService(@"C:\Tools\geckodriver", "geckodriver.exe");

            Driver = new FirefoxDriver(driverService);

            // TODO Handle Login etc.
        }

        public void Dispose()
        {
            Driver.Close();
        }
    }
}
