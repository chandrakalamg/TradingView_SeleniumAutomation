using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace HybridFwk_POM_TradingView.util
{
    public class WaitForElement 
    {
            
        public static void WaitForElementToBeVisible(IWebDriver driver,By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(50));
            
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IWebElement WaitForElementToBeClickable(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static bool WaitForElementToBePresent(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            try
            {
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

