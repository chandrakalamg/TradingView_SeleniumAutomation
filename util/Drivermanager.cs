using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace HybridFwk_POM_TradingView.util
{
    public class Drivermanager
    {
        public static IWebDriver CreateWebDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
           // ChromeOptions options = new ChromeOptions();
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(240);
            return driver;
        }
    }
}
