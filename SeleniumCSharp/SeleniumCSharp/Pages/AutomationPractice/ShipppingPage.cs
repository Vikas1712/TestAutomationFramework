using OpenQA.Selenium;
using SeleniumCSharp.Base;
using SeleniumCSharp.Extensions;

namespace SeleniumCSharp.Pages.AutomationPractice
{
    public class ShipppingPage : BasePage
    {
        private IWebElement CheckBoxTermsAndConition => DriverContext.Driver.FindElement(By.CssSelector("#cgv"));

        private IWebElement BtnShippingProceedToCheckout => DriverContext.Driver.FindElement(By.CssSelector("button[name = 'processCarrier'] span"));

        public void AgreeTermsAndContions() => CheckBoxTermsAndConition.Click();

        public PaymentPage SelectProceedToCheckout()
        {
            BtnShippingProceedToCheckout.ClickElement();
            return GetInstance<PaymentPage>();
        }
    }
}