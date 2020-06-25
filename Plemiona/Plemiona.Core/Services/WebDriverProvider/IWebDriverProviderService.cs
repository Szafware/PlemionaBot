using OpenQA.Selenium.Remote;

namespace Plemiona.Core.Services.WebDriverProvider
{
    public interface IWebDriverProviderService
    {
        RemoteWebDriver CreateWebDriver();
    }
}