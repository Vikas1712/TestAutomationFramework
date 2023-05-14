using OpenQA.Selenium;
using SeleniumCSharp.Base;
using SeleniumCSharp.Extensions;

namespace SeleniumCSharp.Pages.AutomationPractice
{
    public class CartPage : BasePage
    {
        private IWebElement TxtProductAddedSuccessfully => DriverContext.Driver.FindElement(By.CssSelector("div[class='layer_cart_product col-xs-12 col-md-6'] h2"));
        private IWebElement BtnProceedToCheckout => DriverContext.Driver.FindElement(By.CssSelector("a[title='Proceed to checkout'] span"));
        private IWebElement TxtShoppingHeader => DriverContext.Driver.FindElement(By.CssSelector("#summary_products_quantity"));
        private IWebElement BtnRemoveCartDelete => DriverContext.Driver.FindElement(By.CssSelector("td[class='cart_delete text-center'] div"));
        private IWebElement TxtCartIsEmpty => DriverContext.Driver.FindElement(By.CssSelector(".alert.alert-warning"));
        private IWebElement BtnSummaryProceedToCheckout => DriverContext.Driver.FindElement(By.CssSelector("a[class='button btn btn-default standard-checkout button-medium'] span"));
        private IWebElement BtnAddressProceedToCheckout => DriverContext.Driver.FindElement(By.CssSelector("button[name = 'processAddress'] span"));

        public void SelectProceedToCheckout() => BtnProceedToCheckout.ClickElement();

        public void SelectSummaryProceedToCheckout() => BtnSummaryProceedToCheckout.ClickElement();

        public ShipppingPage SelectAddressProceedToCheckout()
        {
            BtnAddressProceedToCheckout.ClickElement();
            return GetInstance<ShipppingPage>();
        }

        public void ViewCartDetail() => TxtProductAddedSuccessfully.AssertElementPresent();

        public void VerifyCardAddedSuccessfully() => TxtShoppingHeader.AssertElementPresent();

        public void RemoveProductFromCart() => BtnRemoveCartDelete.ClickElement();

        public void VerifyCardIsEmpty() => TxtCartIsEmpty.AssertElementPresent();
    }
}