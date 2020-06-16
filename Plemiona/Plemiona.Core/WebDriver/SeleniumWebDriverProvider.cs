using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Plemiona.Core.WebDriver
{
    public class SeleniumWebDriverProvider : IWebDriverProvider
    {
        private RemoteWebDriver _remoteWebDriver;

        public RemoteWebDriver CreateWebDriver()
        {
            if (_remoteWebDriver != null)
            {
                return _remoteWebDriver;
            }

            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            _remoteWebDriver = new ChromeDriver(chromeDriverService);

            return _remoteWebDriver;
        }
    }
}