using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.DailyBonusSteps
{
    public class IsDailySignInGiftWindowPresentStep : StandardStepBase
    {
        public IsDailySignInGiftWindowPresentStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public override object Execute(object parameter)
        {
            bool didDailySignInGiftWindowPopUp = _webDriverBaseMethodsService.ExistsBy(By.Id("popup_box_daily_bonus"));

            return didDailySignInGiftWindowPopUp;
        }
    }
}