using System.Net;
using NUnit.Framework;
using RestSharp;
using RestSharpSpecFlow.APIClient.Board;
using RestSharpSpecFlow.Model;
using RestSharpSpecFlow.Utilities;

namespace RestSharpSpecFlow.Steps;

[Binding]
public class BoardStepDefinition
{
    private readonly IBoardClient boardClient;
    private RestResponse? response;
    private readonly ScenarioContext _scenarioContext;
    public BoardStepDefinition(ScenarioContext scenarioContext)
    {
        this._scenarioContext = scenarioContext;
        boardClient = new BoardClient("https://api.trello.com");
    }

    [Given(@"I have a valid Trello API key and token")]
    public void GivenIHaveAValidTrelloApiKeyAndToken()
    {
        // Initialize the REST client and set the Trello API base URL
        //client = new BoardClient("https://api.trello.com");
    }

    [When(@"I send a POST request to the ""(.*)"" endpoint with the following data:")]
    public async Task WhenISendApostRequestToTheEndpointWithTheFollowingData(string endpoint, Table table)
    {
        var apiKey = table.Rows[0]["Value"];
        var apiToken = table.Rows[1]["Value"];
        var boardName = table.Rows[2]["Value"];
        bool defaultLists = bool.Parse(table.Rows[3]["Value"]);
        response = await boardClient.CreateBoard<Board>(apiKey, apiToken, boardName, defaultLists);
    }

    [Then(@"the response status code should be (.*)")]
    public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
    {
        // Assert that the actual status code matches the expected status code
        Assert.AreEqual(expectedStatusCode, ((int)response?.StatusCode)!);
    }

    [Then(@"the response should contain the created board's ID")]
    public void ThenTheResponseShouldContainTheCreatedBoardsId()
    {
        if (response?.StatusCode == HttpStatusCode.OK)
        {
            var content = HandleContent.GetContent<Board>(response);
            _scenarioContext.Set( content?.id,"BoardId");
            Assert.IsFalse(string.IsNullOrEmpty(content?.id));
        }
        else
        {
            Console.WriteLine("Data"+response?.Content);
            Assert.IsFalse(string.IsNullOrEmpty(response?.Content?.Contains("invalid token").ToString()));
        }
    }
}