using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;

namespace Tests
{
    public class DriverManager
    {
        private static AppiumDriver<AppiumWebElement> _driver;

        private static Platform _platform;

        public DriverManager(Platform platform)
        {
            _platform = platform;
        }

        public AppiumDriver<AppiumWebElement> Driver
        {
            get { return _driver ?? Init(); }
            private set { _driver = value; }
        }

        private AppiumDriver<AppiumWebElement> Init()
        {
            if (_platform == Platform.Android)
            {
                DesiredCapabilities capabilities = new DesiredCapabilities();
                capabilities.SetCapability("appPackage", "com.android.browser");
                capabilities.SetCapability("deviceName", "Nexus 5 (Lollipop)");

                Driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            }
            else if (_platform == Platform.IOS)
            {
                throw new NotImplementedException("IOS driver not implemented");   
            }
            else
            {
                throw new InvalidOperationException("Platform not recognised");
            }

            return Driver;
        }

        public void CloseConnectionToDriver()
        {
            Driver.Quit();
            Driver = null;
        }
    }
}

