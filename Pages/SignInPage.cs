using OpenQA.Selenium;

namespace HybridFwk_POM_TradingView.Pages
{
    class SignInPage
    {
        private readonly IWebDriver driver;

        public SignInPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement EmailBtn => driver.FindElement(By.XPath("//span[contains(@class,'show-email')]"));
        private IWebElement usernameInput => driver.FindElement(By.Name("username"));
        private IWebElement passwordInput => driver.FindElement(By.Name("password"));
        private IWebElement loginButton => driver.FindElement(By.XPath("//*[@type='submit']"));

        public HomePage SignIn()
        {
            EmailBtn.Click();
            usernameInput.SendKeys("chandrakalamg");
            passwordInput.SendKeys("test123");
            loginButton.Click();
            return new HomePage(driver);
        }
    }
}
