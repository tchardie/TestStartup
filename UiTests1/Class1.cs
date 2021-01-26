using OpenQA.Selenium;
using System.Threading;
using Xunit;

namespace UiTests1
{
    /**
     * Builds new context for every test. See FixtureDemo for reusing the same context
     **/
    public class Class1 : BaseUiTest
    {
        public Class1() : base()
        {
            //var driverService = FirefoxDriverService.CreateDefaultService(@"C:\Tools\geckodriver", "geckodriver.exe");
            //_driver = new FirefoxDriver(driverService);
        }

        [Fact]
        public void Test1()
        {
            Driver.Url = "https://google.com";

            Driver.FindElement(By.Name("q")).SendKeys("microsoft");

            Thread.Sleep(500);

            Driver.FindElement(By.Name("btnK")).Click();

            Thread.Sleep(2000);
        }

        [Fact]
        public void Test2()
        {
            Driver.Url = "https://google.com";

            Driver.FindElement(By.Name("q")).SendKeys("microsoft");

            Thread.Sleep(500);

            Driver.FindElement(By.Name("btnK")).Click();

            Thread.Sleep(2000);
        }
    }
}
