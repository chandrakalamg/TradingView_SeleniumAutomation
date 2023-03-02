using AventStack.ExtentReports;
using HybridFwk_POM_TradingView.Pages;
using HybridFwk_POM_TradingView.util;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace HybridFwk_POM_TradingView.Tests
{
    class HomePageTests : BaseTest
    {

        [Test, Order(1)]
        public void SignIntoTradingView()
        {
            ExtentReport.CreateTest($"TestName : SignIn to TradingView");
            var signinpage = new SignInPage(driver);
            HomePage homePage = signinpage.SignIn();
           
            String homePageTitle = homePage.GetPageTitle();
            Assert.AreEqual("Forex Rates — All Currency Pairs — TradingView", homePageTitle);
            Console.WriteLine(homePageTitle);
            homePage.AcceptCookies();
            ExtentReport.LogTestStep(Status.Pass, $"Signin Succesfull and page title is  " + homePageTitle + " Passed successfully");
        }

        [Test, Order(2)]
        public void SwitchRegionTab()
        {
            ExtentReport.CreateTest($"TestName : Switch to Region Tab");
            try
            {
            var signinpage = new SignInPage(driver);
            HomePage homePage = signinpage.SignIn();
            homePage.AcceptCookies();
            homePage.NavigatetoRegionratestab();          
            String regionPageTitle = homePage.GetPageTitle();
            Assert.AreEqual("Asian Currencies — Rates and Performance — TradingView", regionPageTitle);
            ExtentReport.LogTestStep(Status.Pass, $"RegionTab is selcted and title is " + regionPageTitle);
            }
            catch (AssertionException ex)
            {
                ExtentReport.LogTestStep(Status.Fail, ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                ExtentReport.LogTestStep(Status.Error, ex.Message);
                throw;
            }
        }
    }
}

