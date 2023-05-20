using Newtonsoft.Json;
using RestSharp;

namespace RestSharpSpecFlow.Utilities;

public static class HandleContent
{
    public static T? GetContent<T>(RestResponse response)
    {
        var content = response.Content;
        return JsonConvert.DeserializeObject<T>(content);
    }

    public static string SerializeJsonString(dynamic content)
    {
        return JsonConvert.SerializeObject(content, Formatting.Indented);
    }

    public static T? ParseJson<T>(string file)
    {
        return JsonConvert.DeserializeObject<T>(File.ReadAllText(file));
    }

    public static string GetFilePath(string fileName)
    {
        string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
        return string.Format(path + "TestData\\{0}", fileName);
    }
}