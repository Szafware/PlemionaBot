using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Plemiona.Core.Configuration;

namespace Plemiona.Core.WebDriver
{
    public class SeleniumWebDriverProvider : IWebDriverProvider
    {
        private readonly PlemionaSettings _plemionaSettings;
        private RemoteWebDriver _remoteWebDriver;

        public SeleniumWebDriverProvider(PlemionaSettings plemionaSettings)
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