using SeleniumCSharp.Base;

namespace SeleniumCSharp.Config;

public abstract class Settings
{
    public static string? TrelloURL { get; set; }
    public static BrowserType BrowserType { get; set; }
    public static string? UserName { get; set; }
    public static string? Password { get; set; }
    public static int DefaultWait { get; set; }
}