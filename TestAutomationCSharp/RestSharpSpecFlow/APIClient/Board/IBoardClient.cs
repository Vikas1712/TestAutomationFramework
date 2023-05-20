using RestSharp;

namespace RestSharpSpecFlow.APIClient.Board;

public interface IBoardClient
{
    Task GetTrelloBoard<T>(string apiKey, string apiToken) where T : class;

    Task<RestResponse> CreateBoard<T>(string apiKey, string apiToken, string boardName, bool defaultList) where T : class;

    Task<RestResponse> GetBoard<T>(string id, string apiKey, string apiToken) where T : class;

}