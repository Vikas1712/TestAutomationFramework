using SeleniumCSharp.Base;
using SeleniumCSharp.Pages;
using SeleniumCSharp.Pages.AutomationPractice;
using TechTalk.SpecFlow;

namespace SeleniumCSharp.Steps
{
    [Binding]
    public class CartSteps : BasePage
    {
        [Given(@"Register User is on the product page")]
        public void GivenRegisterUserIsOnTheProductPage()
        {
            CurrentPage = GetInstance<HomePage>();
            CurrentPage.As<HomePage>().OpenAutomationPracticeSite();
            CurrentPage = CurrentPage.As<HomePage>().ClickSignIn();
            CurrentPage.As<LoginPage>().RegisterUserNameAndPassword();
            CurrentPage = CurrentPage.As<LoginPage>().ClickSubmitLogin();
        }

        [When(@"User adds a product to the cart")]
        public void WhenUserAddsAProductToTheCart()
        {
            CurrentPage.As<ProductPage>().SelectProductCategory();
            CurrentPage.As<ProductPage>().SelectProduct();
            CurrentPage.As<ProductPage>().ViewProductDetail();
            CurrentPage = CurrentPage.As<ProductPage>().ClickAddToCart();
        }

        [Then(@"The cart should be updated")]
        public void ThenTheCartShouldBeUpdated()
        {
            CurrentPage.As<CartPage>().ViewCartDetail();
            CurrentPage.As<CartPage>().SelectProceedToCheckout();
            CurrentPage.As<CartPage>().VerifyCardAddedSuccessfully();
        }

        [Given(@"User have added few products in the cart")]
        public void GivenUserHaveAddedFewProductsInTheCart()
        {
            CurrentPage = GetInstance<HomePage>();
            CurrentPage = CurrentPage.As<HomePage>().OpenAutomationPracticeSite();
            CurrentPage.As<ProductPage>().SelectProductCategory();
            CurrentPage.As<ProductPage>().SelectProduct();
            CurrentPage = CurrentPage.As<ProductPage>().ClickAddToCart();
            CurrentPage.As<CartPage>().SelectProceedToCheckout();
        }

        [When(@"User removes a product from the cart")]
        public void WhenUserRemovesAProductFromTheCart() => CurrentPage.As<CartPage>().RemoveProductFromCart();

        [Then(@"The cart should be empty")]
        public void ThenTheCartShouldBeEmpty() => CurrentPage.As<CartPage>().VerifyCardIsEmpty();
    }
}