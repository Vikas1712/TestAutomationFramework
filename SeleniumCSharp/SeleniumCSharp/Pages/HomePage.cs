using System;
using System.Threading;
using OpenQA.Selenium;
using SeleniumCSharp.Base;
using SeleniumCSharp.Config;
using SeleniumCSharp.Extensions;
using SeleniumCSharp.Pages.AutomationPractice;

namespace SeleniumCSharp.Pages
{
    public class HomePage : BasePage
    {
        private IWebElement LinkSignIn => DriverContext.Driver.FindElement(By.CssSelector("a[title='Log in to your customer account']"));
        private By LinkLogin => By.CssSelector("a[data-uuid='MJFtCCgVhXrVl7v9HA7EH_login']");
        private By BtnAcceptCookies => By.XPath("//button[normalize-space()='Accept Cookies']");
        public LoginPage ClickSignIn()
        {
            DriverContext.Driver.WaitForPageToLoaded();
            Thread.Sleep(5000);
            LinkSignIn.ClickElement();
            return GetInstance<LoginPage>();
        }

        public ProductPage OpenAutomationPracticeSite()
        {
            DriverContext.Driver.Navigate().GoToUrl(Settings.PracticeAutomationURL);
            DriverContext.Driver.Manage().Window.Maximize();
            return GetInstance<ProductPage>();
        }
        
        public LoginPage OpenTrelloSite()
        {
            DriverContext.Driver.Navigate().GoToUrl(Settings.TrelloURL);
            DriverContext.Driver.Manage().Window.Maximize();
            AcceptCookiesIfPresent();
            DriverContext.Driver.FindElement(LinkLogin,Settings.DefaultWait).Click();
            return GetInstance<LoginPage>();
        }

        private void AcceptCookiesIfPresent()
        {
            if (DriverContext.Driver.IsDisplayed(BtnAcceptCookies))
            {
                Console.WriteLine("Click on Accept Cookies");
                DriverContext.Driver.FindElement(BtnAcceptCookies).Click();
            }
        }
    }
}