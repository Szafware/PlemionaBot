using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.DailyBonusSteps
{
    public class IsDailySignInGiftWindowPresentStep : StandardStepBase, IStep
    {
        public IsDailySignInGiftWindowPresentStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object parameter)
        {
            _botCheckDetectService.Validate(nameof(IsDailySignInGiftWindowPresentStep));
            _stepDelayService.Delay();

            bool didDailySignInGiftWindowPopUp = _webDriverBaseMethodsService.ExistsBy(By.Id("popup_box_daily_bonus"));

            return didDailySignInGiftWindowPopUp;
        }
    }
}