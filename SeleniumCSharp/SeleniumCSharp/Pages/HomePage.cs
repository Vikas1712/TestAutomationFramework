using OpenQA.Selenium;
using SeleniumCSharp.Base;
using SeleniumCSharp.Config;
using SeleniumCSharp.Extensions;

namespace SeleniumCSharp.Pages;

public class HomePage : BasePage
{
    private By LinkLogin => By.CssSelector("a[data-uuid='MJFtCCgVhXrVl7v9HA7EH_login']");
    private By BtnAcceptCookies => By.XPath("//button[normalize-space()='Accept Cookies']");

    public LoginPage OpenTrelloSite()
    {
        DriverContext.Driver.Navigate().GoToUrl(Settings.TrelloURL);
        DriverContext.Driver.Manage().Window.Maximize();
        AcceptCookiesIfPresent();
        DriverContext.Driver.FindElement(LinkLogin, Settings.DefaultWait).Click();
        Console.WriteLine("Click on Login Link");
        return GetInstance<LoginPage>();
    }

    private void AcceptCookiesIfPresent()
    {
        if (DriverContext.Driver.IsDisplayed(BtnAcceptCookies,Settings.DefaultWait))
        {
            Console.WriteLine("Click on Accept Cookies");
            DriverContext.Driver.FindElement(BtnAcceptCookies).Click();
        }
    }
}