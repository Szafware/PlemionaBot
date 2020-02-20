using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace PleAutomiX.Bots.WebDriver
{
    public class SeleniumWebDriverProvider : IWebDriverProvider
    {
        public RemoteWebDriver CreateWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            var chromeDriver = new ChromeDriver(chromeDriverService);

            return chromeDriver;
        }
    }
}