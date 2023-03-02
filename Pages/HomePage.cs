using HybridFwk_POM_TradingView.util;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace HybridFwk_POM_TradingView.Pages
{
    public class HomePage
        {
        private readonly IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        By AcceptCookiesButton = By.XPath("//*[text()='Accept all']");

        By Asiatab = By.XPath("//*[text()='Asia']");
        By Searchbtn = By.XPath("//span[text()='Search']");
        By Searchfield = By.Name("query");

        public void AcceptCookies()
        {
            //Thread.Sleep(100);
            WaitForElement.WaitForElementToBeVisible(driver,AcceptCookiesButton);
            driver.FindElement(AcceptCookiesButton).Click();
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public void NavigatetoRegionratestab()
        {
            driver.FindElement(Asiatab).Click();
        }

        public void InputSearch(string searchtext)
        {
            WaitForElement.WaitForElementToBeClickable(driver, Searchbtn);
            IWebElement searchelement = driver.FindElement(Searchbtn);
            Actions actions = new Actions(driver);
            actions.SendKeys(Keys.PageDown).Build().Perform();
            actions.MoveToElement(searchelement).Click().Build().Perform();
            Thread.Sleep(500);
            searchelement.Click();
            WaitForElement.WaitForElementToBeVisible(driver, Searchfield);
            driver.FindElement(Searchfield).Click();
            driver.FindElement(Searchfield).SendKeys(searchtext);

            // Wait for the search results to appear
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(100);
            //Thread.Sleep(500);
            // Fetch the search result list
            IList<IWebElement> searchResult = driver.FindElements(By.XPath("//*[@class='description-DPHbT8fH']")); 
            
            for(int i =0;i< searchResult.Count-1;i++)
            {
                String searchstrigresult = searchResult[i].Text;
                if (searchstrigresult.Contains("GBPJPY")) { 
                    // Hover over the search result item
                    IWebElement elem = searchResult[i];
                    actions.MoveToElement(elem).Perform();
                   // Click on "See Overview"
                    IWebElement seeOverviewButton = elem.FindElement(By.XPath("//*[text()='See overview']"));
                    seeOverviewButton.Click();
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}

