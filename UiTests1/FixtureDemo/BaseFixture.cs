﻿using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace UiTests1.FixtureDemo
{
    public class BaseFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }
        public BaseFixture()
        {
            var driverService = FirefoxDriverService.CreateDefaultService(@"C:\Tools\geckodriver", "geckodriver.exe");

            Driver = new FirefoxDriver(driverService);
        }

        public void Dispose()
        {
            Driver.Close();
            Driver.Dispose();
        }
    }
}
