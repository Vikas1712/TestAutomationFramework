using OpenQA.Selenium;
using SeleniumCSharp.Base;
using SeleniumCSharp.Extensions;

namespace SeleniumCSharp.Pages.AutomationPractice
{
    public class PaymentPage : BasePage
    {
        private IWebElement BtnPayBycheck => DriverContext.Driver.FindElement(By.CssSelector("a[title='Pay by check.']"));
        private IWebElement BtnIConfirmMyOrder => DriverContext.Driver.FindElement(By.CssSelector("button[class='button btn btn-default button-medium'] span"));
        private IWebElement AlertOrderConfirmation => DriverContext.Driver.FindElement(By.CssSelector(".alert.alert-success"));

        public void MakePaymentbyCheck() => BtnPayBycheck.ClickElement();

        public void SelectIConfirmMyOrder() => BtnIConfirmMyOrder.ClickElement();

        public void VerifyOrderPlaceSuccessfully() => AlertOrderConfirmation.AssertElementPresent();
    }
}