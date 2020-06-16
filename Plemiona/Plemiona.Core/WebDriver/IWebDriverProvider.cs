using OpenQA.Selenium.Remote;

namespace Plemiona.Core.WebDriver
{
    public interface IWebDriverProvider
    {
        RemoteWebDriver CreateWebDriver();
    }
}