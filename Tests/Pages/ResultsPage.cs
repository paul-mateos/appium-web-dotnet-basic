using System;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System.Linq;

namespace Tests
{
    public class ResultsPage
    {
        private AppiumDriver<AppiumWebElement> _driver;

        private const string PageTitle = "Amazon.co.uk: ";

        [FindsBy(How=How.Id, Using="resultItems")]
        private IList<IWebElement> _resultsElements;

        public ResultsPage(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ResultsPage Await(string searchText)
        {
            Wait.Until(() => _driver.Title.Equals(PageTitle + searchText));
            return this;
        }

        public IEnumerable<string> ResultTitles()
        {
            var elements = _resultsElements.Select(s => s.FindElement(By.TagName("strong")));
            return elements.Select(e => e.Text);
        }
    }
}

