using NUnit.Framework;
using SeleniumCSharp.Base;
using SeleniumCSharp.Pages.Trello;
using TechTalk.SpecFlow;

namespace SeleniumCSharp.Steps.Trello;

[Binding]
public class CardSteps:BasePage
{
    [Given(@"Register User is on the Card page")]
    public void GivenRegisterUserIsOnTheCardPage()
    {
        CurrentPage = GetInstance<BoardPage>();
        CurrentPage.As<BoardPage>().ConfirmBoardPageIsDisplayed();
        CurrentPage.As<BoardPage>().CreateNewBoard("TestingDemo");
        CurrentPage = CurrentPage.As<BoardPage>().ClickCreateBoardSumbit();
        Assert.True(CurrentPage.As<CardPage>().ConfirmToDoCardPresent(),"User is on Card Page");
    }

    [Then(@"That new to do card is added successfully on the board")]
    public void ThenThatNewToDoCardIsAddedSuccessfullyOnTheBoard()
    {
        Assert.GreaterOrEqual(CurrentPage.As<CardPage>().ValidateToDoCardCount().Count,1,"Expected at least 1 matching cards");
    }

    [When(@"User create a new card with title ""(.*)"" in ToDo Lane")]
    public void WhenUserCreateANewCardWithTitleInToDoLane(string title)
    {
        CurrentPage.As<CardPage>().AddToDoCard(title);
    }

    [When(@"User create a new card with title ""(.*)"" in Doing Lane")]
    public void WhenUserCreateANewCardWithTitleInDoingLane(string title)
    {
        CurrentPage.As<CardPage>().AddDoingCard(title);    
    }

    [When(@"User create a new card with title ""(.*)"" in Done Lane")]
    public void WhenUserCreateANewCardWithTitleInDoneLane(string title)
    {
        CurrentPage.As<CardPage>().AddDoneCard(title);    
    }

    [Given(@"User can view the Card on the board")]
    public void GivenUserCanViewTheCardOnTheBoard()
    {
        CurrentPage = GetInstance<BoardPage>();
    }
    
    [When(@"User deletes all the cards")]
    public void WhenUserDeletesAllTheCards()
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"That cards are no longer visible on board")]
    public void ThenThatCardsAreNoLongerVisibleOnBoard()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"User delete the active board too")]
    public void WhenUserDeleteTheActiveBoardToo()
    {
        ScenarioContext.StepIsPending();
    }
}