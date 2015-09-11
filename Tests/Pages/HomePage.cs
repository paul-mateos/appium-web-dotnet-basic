using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Appium;

namespace Tests
{
    public class HomePage
    {
        private AppiumDriver<AppiumWebElement> _driver;

        private const string PageTitle = "Amazon.co.uk";

        [FindsBy(How=How.Id, Using="nav-search-keywords")]
        private IWebElement _searchInputBox;

        [FindsBy(How=How.ClassName, Using="nav-search-submit")]
        private IWebElement _submitSearchButton;

        public HomePage(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public HomePage Load()
        {
            _driver.Navigate().GoToUrl("http://amazon.co.uk");
            WaitForPageLoad();
            return this;
        }

        private void WaitForPageLoad()
        {
            Wait.Until(() => _driver.Title.Equals(PageTitle));
        }

        public void SearchFor(string product)
        {
            _searchInputBox.SendKeys(product);
            _submitSearchButton.Click();
        }
    }
}

