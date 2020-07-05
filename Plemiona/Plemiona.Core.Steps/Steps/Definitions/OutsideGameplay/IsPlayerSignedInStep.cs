using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;

namespace Plemiona.Core.Steps.Steps.Definitions.OutsideGameplay
{
    public class IsPlayerSignedInStep : StandardStepBase
    {
        public IsPlayerSignedInStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public override object Execute(object parameter)
        {
            bool isPlayerSignedIn = _webDriverBaseMethodsService.ExistsBy(By.XPath("//*[@href='/page/logout']"));

            return isPlayerSignedIn;
        }
    }
}