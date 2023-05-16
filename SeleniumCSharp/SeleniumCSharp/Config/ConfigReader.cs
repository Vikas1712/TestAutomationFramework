/*
ConfigReader file read the custom XML file
We are using System.XML namespace and will be using
XPathItem and XPathDocument classes to perform operations.
*/

using System.Xml.XPath;
using SeleniumCSharp.Base;

namespace SeleniumCSharp.Config;

public static class ConfigReader
{
    public static void SetFrameworkSettings()
    {
        XPathItem? trelloURL = null;
        XPathItem? username = null, password = null, browser = null, defaultWait = null;

        var strFilename = Environment.CurrentDirectory + "/Config/GlobalConfig.xml";
        FileStream stream = new(strFilename, FileMode.Open);
        XPathDocument document = new(stream);
        var navigator = document.CreateNavigator();

        //Get XML Details and pass it in XPathItem type variables
        if (navigator != null)
        {
            trelloURL = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/TrelloURL");
            username = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/Username");
            password = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/Password");
            browser = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/Browser");
            defaultWait = navigator.SelectSingleNode("SeleniumCSharpFramework/RunSettings/DefaultWait");
        }

        //Set XML Details in the property to be used accross framework
        if (trelloURL != null) Settings.TrelloURL = trelloURL.Value;
        if (username != null) Settings.UserName = username.Value;
        if (password != null) Settings.Password = password.Value;
        if (browser != null)
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), browser.Value);
        if (defaultWait != null) Settings.DefaultWait = int.Parse(defaultWait.Value);
    }
}