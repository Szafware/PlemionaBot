using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Plemiona.Core.Configuration;

namespace Plemiona.Core.Services.WebDriverProvider
{
    public class SeleniumWebDriverProviderService : IWebDriverProviderService
    {
        private readonly PlemionaSettings _plemionaSettings;
        private RemoteWebDriver _remoteWebDriver;

        public SeleniumWebDriverProviderService(PlemionaSettings plemionaSettings)
        {
            _plemionaSettings = plemionaSettings;
        }

        public RemoteWebDriver CreateWebDriver()
        {
            if (_remoteWebDriver != null)
            {
                return _remoteWebDriver;
            }

            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            bool hideCommandPromptWindow = !_plemionaSettings.ShowConsole;

            chromeDriverService.HideCommandPromptWindow = hideCommandPromptWindow;

            _remoteWebDriver = new ChromeDriver(chromeDriverService);

            return _remoteWebDriver;
        }
    }
}