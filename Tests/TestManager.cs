using System;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;

namespace Tests
{
    public class TestManager
    {
        private Platform _platform;
        private DriverManager _driverManager;

        public TestManager(Platform platform)
        {
            _platform = platform;
        }

        public Platform CurrentPlatform
        {
            get { return _platform; }
        }

        public void SetupAndStartDriver()
        {
            _driverManager = new DriverManager(_platform);
        }
    }
}

