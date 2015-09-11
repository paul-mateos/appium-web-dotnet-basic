using System;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using System.Linq;
using NFluent;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;

namespace Tests
{
    [TestFixture(Platform.Android)]
    public class BrowsingTest
    {
        private DriverManager _driverManager;
        private Platform _platform;

        public BrowsingTest(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEach()
        {
            _driverManager = new DriverManager(_platform);
            _driverManager.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(15));
        }

        [Test]
        public void BrowseForItem()
        {
            var driver = _driverManager.Driver;
            const string searchTerm = "apple keyboard";
            const string expected = "Apple Keyboard";

            var homePage = new HomePage(driver).Load();
            homePage.SearchFor(searchTerm);

            var resultsPage = new ResultsPage(driver).Await(searchTerm);
            var resultTitles = resultsPage.ResultTitles();

            Check.That(resultTitles.Any(e => e.Contains(expected))).IsEqualTo(true);
        }

//        [Test]
//        public void BrowseForItem()
//        {
//            var driver = _driverManager.Driver;
//            const string expected = "Apple Keyboard with Numeric Keypad";
//
//            var homePage = new HomePage(driver).Load();
//            homePage.SearchFor("apple keyboard");
//
//            var sumbitSearch = driver.FindElementByClassName("nav-search-submit");
//            sumbitSearch.Click();
//
//            Wait.Until(() => driver.Title.Equals("Amazon.co.uk: apple keyboard"));
//
//            var resultList = driver.FindElementsById("resultItems");
//            var result = resultList.Select(s => s.FindElementByTagName("strong")).Select(e => e.Text);
//
//            Check.That(result.Any(e => e.Equals(expected))).IsEqualTo(true);
//        }


        [TearDown]
        public void AfterEachTest()
        {
            _driverManager.CloseConnectionToDriver();
        }
    }
}

