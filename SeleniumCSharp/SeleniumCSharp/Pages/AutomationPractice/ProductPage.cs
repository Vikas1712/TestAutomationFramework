using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumCSharp.Base;
using SeleniumCSharp.Extensions;

namespace SeleniumCSharp.Pages.AutomationPractice
{
    public class ProductPage : BasePage
    {
        private IWebElement DropDownWomenProductCategory => DriverContext.Driver.FindElement(By.CssSelector("a[title='Women']"));
        private IWebElement LinkTShirts => DriverContext.Driver.FindElement(By.CssSelector("li[class='sfHover'] a[title='T-shirts']"));

        private IWebElement ImgProductIcon => DriverContext.Driver.FindElement(By.CssSelector("img[title='Faded Short Sleeve T-shirts']"));

        private IWebElement QuickView => DriverContext.Driver.FindElement(By.CssSelector("a[class='quick-view'] span"));

        private IWebElement TxtProductDescription => DriverContext.Driver.FindElement(By.Id("short_description_block"));
        private IWebElement BtnAddToCart => DriverContext.Driver.FindElement(By.Id("add_to_cart"));

        private IWebElement CheckBoxSizeCategory => DriverContext.Driver.FindElement(By.CssSelector("ul[id='ul_layered_id_attribute_group_1'] li:nth-child(2)"));

        public void SelectProductCategory()
        {
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(DropDownWomenProductCategory).Perform();
            actions.MoveToElement(LinkTShirts).Click().Perform();
        }

        public void SelectProduct()
        {
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(ImgProductIcon).Perform();
            actions.MoveToElement(QuickView).Click().Perform();
        }

        public void ViewProductDetail()
        {
            DriverContext.Driver.SwitchToIFrame();
            BtnAddToCart.AssertElementPresent();
            TxtProductDescription.AssertElementPresent();
            DriverContext.Driver.SwitchTo().DefaultContent();
        }

        public int CountNumberOfProducts() => DriverContext.Driver.FindElements(By.ClassName("product-image-container")).Count();

        public void SetFilterBasedOnCategory()
        {
            CheckBoxSizeCategory.ClickElement();
            Thread.Sleep(5000);
        }

        public CartPage ClickAddToCart()
        {
            DriverContext.Driver.SwitchToIFrame();
            BtnAddToCart.ClickElement();
            DriverContext.Driver.SwitchTo().DefaultContent();
            return GetInstance<CartPage>();
        }
    }
}