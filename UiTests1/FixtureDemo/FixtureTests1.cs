using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UiTests1.FixtureDemo
{
    /**
     * Uses the same "context" to run the tests.
     * 
     * NOTE: Tests will not run in order if ran as a class
     **/
    public class FixtureTests1 : IClassFixture<BaseFixture>
    {
        private readonly BaseFixture _fixture;

        public FixtureTests1(BaseFixture fixture)
        {
            _fixture = fixture;
        }

        
        [Fact]
        public void Test1()
        {
            _fixture.Driver.Url = "https://www.google.com";

            Thread.Sleep(1000);

            Assert.True(true);
        }

        [Fact]
        public void Test2()
        {
            _fixture.Driver.Url = "https://www.cnn.com";

            Thread.Sleep(2000);

            Assert.False(false);
        }
    }
}
