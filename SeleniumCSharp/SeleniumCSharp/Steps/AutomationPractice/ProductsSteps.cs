using NUnit.Framework;
using SeleniumCSharp.Base;
using SeleniumCSharp.Pages;
using SeleniumCSharp.Pages.AutomationPractice;
using TechTalk.SpecFlow;

namespace SeleniumCSharp.Steps
{
    [Binding]
    public class ProductsSteps : BasePage
    {
        private int _beforeCount;
        private int _afterCount;

        [Given(@"User is on automation practice site")]
        public void GivenUserIsOnAutomationPracticeSite()
        {
            CurrentPage = GetInstance<HomePage>();
            CurrentPage = CurrentPage.As<HomePage>().OpenAutomationPracticeSite();
        }

        [Given(@"User have selected a category on the website")]
        public void GivenUserHaveSelectedACategoryOnTheWebsite()
        {
            CurrentPage = GetInstance<HomePage>();
            CurrentPage = CurrentPage.As<HomePage>().OpenAutomationPracticeSite();
            CurrentPage.As<ProductPage>().SelectProductCategory();
        }

        [When(@"User selects a product from the list")]
        public void WhenUserSelectsAProductFromTheList()
        {
            CurrentPage.As<ProductPage>().SelectProductCategory();
            CurrentPage.As<ProductPage>().SelectProduct();
        }

        [When(@"User applys filter to the products")]
        public void WhenUserApplysFilterToTheProducts()
        {
            _beforeCount = CurrentPage.As<ProductPage>().CountNumberOfProducts();
            CurrentPage.As<ProductPage>().SetFilterBasedOnCategory();
            _afterCount = CurrentPage.As<ProductPage>().CountNumberOfProducts();
        }

        [Then(@"All the details related to products are visible")]
        public void ThenAllTheDetailsRelatedToProductsAreVisible() => CurrentPage.As<ProductPage>().ViewProductDetail();

        [Then(@"The page is updated with correct products")]
        public void ThenThePageIsUpdatedWithCorrectProducts() => Assert.AreEqual(_beforeCount, _afterCount);
    }
}