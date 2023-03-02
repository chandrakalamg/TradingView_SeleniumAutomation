using AventStack.ExtentReports;
using HybridFwk_POM_TradingView.Pages;
using HybridFwk_POM_TradingView.util;
using NUnit.Framework;
using System;

namespace HybridFwk_POM_TradingView.Tests
{
    public class SearchTest : BaseTest
    {

        [Test]
        public void SearchText()
        {

             String searchtext = "FX:GBP";
             ExtentReport.CreateTest($"TestName : Search_{searchtext}");
             try
             {
                HomePage homePage = new HomePage(driver);
                SignInPage signinpage = new SignInPage(driver);
                signinpage.SignIn();
               
                homePage.InputSearch(searchtext);
                String currencyRatePageTitle = homePage.GetPageTitle();
                Assert.AreEqual("GBP JPY Chart – Pound to Yen Rate — TradingView", currencyRatePageTitle);
                ExtentReport.LogTestStep(Status.Pass, currencyRatePageTitle + "page is displayed");
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

