using System.Collections.Generic;
using OpenQA.Selenium;
using SeleniumCSharp.Base;
using SeleniumCSharp.Config;
using SeleniumCSharp.Extensions;

namespace SeleniumCSharp.Pages.Trello;

public class CardPage: BasePage
{
    private By HeaderTitleCardDisplay => By.ClassName("HKTtBLwDyErB_o");
    private By TitleToDoCard => By.CssSelector("textarea[aria-label='To Do']");
    private By TitleDoingCard => By.CssSelector("textarea[aria-label='Doing']");
    private By TitleDone => By.CssSelector("textarea[aria-label='Done']");
    private By TextAreaTitleCard => By.CssSelector("(textarea[placeholder='Enter a title for this card…']");
    private By BtnAddCard => By.CssSelector("input[value='Add card']");
    private By TextAreaListCard => By.CssSelector("input[placeholder='Enter list title…']");
    private By BtnAddList => By.CssSelector("input[value='Add list']");
    private By CardTitleToDo => By.XPath("//div[@class='list js-list-content']/div");

    private By ActionMenuActiveBoard = By.CssSelector("a[title='TestingDemo (currently active)']");
    private By ActionMenuToDoCard => By.CssSelector("(//a[@aria-label='List actions'])[1]");

    private By BtnArchive => By.CssSelector("js-close-list");
    public bool ConfirmToDoCardPresent()
    {
        return DriverContext.Driver.FindElement(HeaderTitleCardDisplay,Settings.DefaultWait).IsDisplayed();
    }

    public bool ConfirmCardThereOnTheBoard()
    {
        if (DriverContext.Driver.IsNotDisplayed(ActionMenuToDoCard))
        {
            ToDoCardCreate("CreateCardIsMissing");
        }
        return DriverContext.Driver.FindElement(ActionMenuToDoCard).IsDisplayed();
    }

    public void DeleteCard()
    {
        DriverContext.Driver.FindElement(ActionMenuToDoCard).Click();
        DriverContext.Driver.IsDisplayed(BtnArchive);
        DriverContext.Driver.FindElement(BtnArchive).Click();

    }

    public void DeleteActiveBoard()
    {
        DriverContext.Driver.IsDisplayed(ActionMenuActiveBoard);
        DriverContext.Driver.FindElement(ActionMenuActiveBoard).Click();
    }
    private void ToDoCardCreate(string title)
    {
        if (DriverContext.Driver.IsDisplayed(TitleToDoCard))
        {
            EnterCardTitle(title);
        }
        else
        {
            EnterCardList(title);
        }
    }
    
    private void ToDoingCreate(string title)
    {
        if (DriverContext.Driver.IsDisplayed(TitleDoingCard))
        {
            EnterCardTitle(title);
        }
        else
        {
            EnterCardList(title);
        }
    }
    
    private void ToDoneCreate(string title)
    {
        if (DriverContext.Driver.IsDisplayed(TitleDone))
        {
            EnterCardTitle(title);
        }
        else
        {
            EnterCardList(title);
        }
    }
    private void EnterCardList(string title)
    {
        //DriverContext.Driver.IsDisplayed(TextAreaListCard);
        DriverContext.Driver.FindElement(TextAreaListCard, Settings.DefaultWait).SendKeys(title);
        DriverContext.Driver.FindElement(BtnAddList,Settings.DefaultWait).Click();
    }

    private void EnterCardTitle(string title)
    {
        //DriverContext.Driver.IsDisplayed(TextAreaTitleCard);
        DriverContext.Driver.FindElement(TextAreaTitleCard, Settings.DefaultWait).SendKeys(title);
        DriverContext.Driver.FindElement(BtnAddCard,Settings.DefaultWait).Click();
    }
    public void AddToDoCard(string title)
    {
        ToDoCardCreate(title);
    }
    
    public void AddDoingCard(string title)
    {
        ToDoCardCreate(title);
        ToDoingCreate(title);
    }

    public void AddDoneCard(string title)
    {
        ToDoCardCreate(title);
        ToDoingCreate(title);
        ToDoneCreate(title);
    }
    public IReadOnlyCollection<IWebElement> ValidateToDoCardCount()
    { 
        return DriverContext.Driver.FindElements(CardTitleToDo,Settings.DefaultWait);
    }
}