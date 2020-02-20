using OpenQA.Selenium.Remote;

namespace PleAutomiX.Bots.WebDriver
{
    public interface IWebDriverProvider
    {
        RemoteWebDriver CreateWebDriver();
    }
}