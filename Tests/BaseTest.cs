using HybridFwk_POM_TradingView.util;
using NUnit.Framework;
using OpenQA.Selenium;

namespace HybridFwk_POM_TradingView.Tests
{
        [TestFixture]
        public class BaseTest
        {
            protected IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            ExtentReport.StartReport();
        }

        [SetUp]
        public void SetUp()
        {
            //ExtentReport.StartReport();
            driver = Drivermanager.CreateWebDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.tradingview.com/markets/currencies/rates-all/#signin");
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
           // ExtentReport.StopReport();
        }

        [OneTimeTearDown]
        public void Stop()
        {
            ExtentReport.StopReport();
        }

    }
}

