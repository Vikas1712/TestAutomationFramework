using OpenQA.Selenium;
using SeleniumCSharp.Base;
using SeleniumCSharp.Config;
using SeleniumCSharp.Extensions;

namespace SeleniumCSharp.Pages.Trello;

public class BoardPage : BasePage
{
    private By btnCreate => By.ClassName("szBTSFrvPTLGHM");
    private By btnCreateBoard => By.CssSelector("button[data-testid='header-create-board-button']");
    private By inputBoardTitle => By.CssSelector("input[type='text']");
    private By btnCreateBoardSubmit => By.CssSelector("button[data-testid='create-board-submit-button']");

    public void ConfirmBoardPageIsDisplayed()
    {
        DriverContext.Driver.IsDisplayed(btnCreate);
    }

    public void CreateNewBoard(string title)
    {
        DriverContext.Driver.FindElement(btnCreate, Settings.DefaultWait).Click();
        DriverContext.Driver.FindElement(btnCreateBoard, Settings.DefaultWait).Click();
        DriverContext.Driver.FindElement(inputBoardTitle, Settings.DefaultWait).Clear();
        DriverContext.Driver.FindElement(inputBoardTitle, Settings.DefaultWait).SendKeys(title);
    }

    public CardPage ClickCreateBoardSumbit()
    {
        IWebElement element = DriverContext.Driver.FindElement(btnCreateBoardSubmit, Settings.DefaultWait);
        DriverContext.Driver.ClickElementWithJs(element);
        return GetInstance<CardPage>();
    }
}