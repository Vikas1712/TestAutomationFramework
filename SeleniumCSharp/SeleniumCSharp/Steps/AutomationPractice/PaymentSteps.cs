using SeleniumCSharp.Base;
using SeleniumCSharp.Pages;
using SeleniumCSharp.Pages.AutomationPractice;
using TechTalk.SpecFlow;

namespace SeleniumCSharp.Steps
{
    [Binding]
    public class PaymentSteps : BasePage
    {
        [Given(@"User have products added to the cart")]
        public void GivenUserHaveProductsAddedToTheCart()
        {
            CurrentPage = GetInstance<HomePage>();
            CurrentPage.As<HomePage>().OpenAutomationPracticeSite();
            CurrentPage = CurrentPage.As<HomePage>().ClickSignIn();
            CurrentPage.As<LoginPage>().RegisterUserNameAndPassword();
            CurrentPage = CurrentPage.As<LoginPage>().ClickSubmitLogin();
            CurrentPage.As<ProductPage>().SelectProductCategory();
            CurrentPage.As<ProductPage>().SelectProduct();
            CurrentPage = CurrentPage.As<ProductPage>().ClickAddToCart();
            CurrentPage.As<CartPage>().SelectProceedToCheckout();
            CurrentPage.As<CartPage>().SelectSummaryProceedToCheckout();
            CurrentPage = CurrentPage.As<CartPage>().SelectAddressProceedToCheckout();
            CurrentPage.As<ShipppingPage>().AgreeTermsAndContions();
            CurrentPage = CurrentPage.As<ShipppingPage>().SelectProceedToCheckout();
        }

        [When(@"User makes the payment after filling all details")]
        public void WhenUserMakesThePaymentAfterFillingAllDetails()
        {
            CurrentPage.As<PaymentPage>().MakePaymentbyCheck();
            CurrentPage.As<PaymentPage>().SelectIConfirmMyOrder();
        }

        [Then(@"Confirmation is displayed to the user")]
        public void ThenConfirmationIsDisplayedToTheUser() => CurrentPage.As<PaymentPage>().VerifyOrderPlaceSuccessfully();
    }
}