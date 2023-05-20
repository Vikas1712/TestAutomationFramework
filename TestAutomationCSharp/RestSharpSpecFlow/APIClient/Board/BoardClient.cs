using HttpTracer;
using HttpTracer.Logger;
using RestSharp;

namespace RestSharpSpecFlow.APIClient.Board;

public class BoardClient : IBoardClient
{
    private readonly RestClient _client;

    public BoardClient(string baseUrl)
    {
        var restClientOptions = new RestClientOptions(baseUrl)
        {
            ConfigureMessageHandler = handler => new HttpTracerHandler(handler, new ConsoleLogger(), HttpMessageParts.All)
        };
        _client = new RestClient(restClientOptions);
    }

    public async Task GetTrelloBoard<T>(string apiKey, string apiToken) where T : class
    {
        throw new NotImplementedException();
    }

    public async Task<RestResponse> CreateBoard<T>(string apiKey, string apiToken, string boardName, bool defaultList) where T : class
    {
        var request = new RestRequest(EndPoints.CREATEBOARD, Method.Post);
        request.AddQueryParameter("name", boardName);
        request.AddQueryParameter("key", apiKey);
        request.AddQueryParameter("token", apiToken);
        request.AddParameter("defaultLists", "true");
        return await _client.ExecuteAsync<Model.Board>(request);
    }

    public async Task<RestResponse> GetBoard<T>(string id, string apiKey, string apiToken) where T : class
    {
        throw new NotImplementedException();
    }
}