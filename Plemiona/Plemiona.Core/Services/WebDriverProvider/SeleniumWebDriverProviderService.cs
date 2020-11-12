using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Opera;
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

            _remoteWebDriver = CreateChromeWebDriver();

            return _remoteWebDriver;
        }

        private RemoteWebDriver CreateChromeWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            bool hideCommandPromptWindow = !_plemionaSettings.ShowConsole;

            chromeDriverService.HideCommandPromptWindow = hideCommandPromptWindow;

            var chromeDriver = new ChromeDriver(chromeDriverService);

            return chromeDriver;
        }
        
        private RemoteWebDriver CreateOperaWebDriver()
        {
            var operaDriverService = OperaDriverService.CreateDefaultService();

            bool hideCommandPromptWindow = !_plemionaSettings.ShowConsole;

            operaDriverService.HideCommandPromptWindow = hideCommandPromptWindow;

            var operaDriver = new OperaDriver(operaDriverService, new OperaOptions());

            return operaDriver;
        }
    }
}