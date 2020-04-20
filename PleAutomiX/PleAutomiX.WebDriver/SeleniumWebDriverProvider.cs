using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;

namespace PleAutomiX.Bots.WebDriver
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

            var operaDriverService = OperaDriverService.CreateDefaultService();

            _remoteWebDriver = new OperaDriver(operaDriverService, new OperaOptions());

            return _remoteWebDriver;
        }
    }
}