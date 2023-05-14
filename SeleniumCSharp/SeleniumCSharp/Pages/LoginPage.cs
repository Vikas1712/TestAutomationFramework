using OpenQA.Selenium;
using SeleniumCSharp.Base;
using SeleniumCSharp.Config;
using SeleniumCSharp.Extensions;
using SeleniumCSharp.Pages.AutomationPractice;
using SeleniumCSharp.Pages.Trello;

namespace SeleniumCSharp.Pages
{
    public class LoginPage : BasePage
    {
        private IWebElement TxtEmailAddress => DriverContext.Driver.FindElement(By.CssSelector("#email"));
        private IWebElement TxtPassword => DriverContext.Driver.FindElement(By.CssSelector("#passwd"));
        private IWebElement BtnSubmitLogin => DriverContext.Driver.FindElement(By.CssSelector("#SubmitLogin"));

        private By HeaderTextLoginToTrello => By.XPath("//h1[contains(text(),'Log in to Trello')]");
        private By HeaderTextLoginToContinue => By.XPath("//div[@data-testid='header-suffix']");
        private By InputEmailAddress => By.CssSelector("input#user");
        private By BtnContinue => By.CssSelector("input#login");
        private By InputPassword => By.CssSelector("input#password");
        private By BtnLogin => By.CssSelector("button#login-submit");
        public ProductPage ClickSubmitLogin()
        {
            DriverContext.Driver.WaitForPageToLoaded();
            BtnSubmitLogin.ClickElement();
            return GetInstance<ProductPage>();
        }

        public void RegisterUserNameAndPassword()
        {
            TxtEmailAddress.SendKeys(Settings.UserName);
            TxtPassword.SendKeys(Settings.Password);
        }
        
        public bool LogInPageIsDisplayed()
        {
            return DriverContext.Driver.IsDisplayed(HeaderTextLoginToTrello);
        }

        public bool AtlassianPageIsDisplayed()
        {
            return DriverContext.Driver.IsDisplayed(HeaderTextLoginToContinue);
        }
        public void EnterEmail(string email)
        {
            DriverContext.Driver.FindElement(InputEmailAddress,Settings.DefaultWait).SendKeys(email);
        }
        public void ClickContinueButton()
        {
            DriverContext.Driver.FindElement(BtnContinue).Click();
        }
        public void EnterPassword(string password)
        {
            DriverContext.Driver.FindElement(InputPassword,Settings.DefaultWait).SendKeys(password);
        }
        
        public BoardPage ClickLogInButton()
        {
            if (DriverContext.Driver.IsDisplayed(BtnLogin))
            {
                DriverContext.Driver.FindElement(BtnLogin).Click();
            }
            return GetInstance<BoardPage>();
        }
    }
}