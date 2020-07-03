using OpenQA.Selenium;
using Plemiona.Core.Exceptions;
using Plemiona.Core.Services.WebDriverBase;

namespace Plemiona.Core.Services.BotCheckDetect
{
    public class BotCheckDetectService : IBotCheckDetectService
    {
        private readonly IWebDriverBaseMethodsService _webDriverBaseMethodsService;

        public BotCheckDetectService(IWebDriverBaseMethodsService webDriverBaseMethodsService)
        {
            _webDriverBaseMethodsService = webDriverBaseMethodsService;
        }

        public void Validate(string stepName)
        {
            var isBotCheckPresent = _webDriverBaseMethodsService.ExistsBy(By.Id("bot_check"));

            if (isBotCheckPresent)
            {
                throw new BotCheckException(stepName);
            }
        }
    }
}