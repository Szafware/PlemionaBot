using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.DailyBonusSteps
{
    public class DidDailySignInGiftWindowPopUpStep : StandardStepBase, IStep
    {
        public DidDailySignInGiftWindowPopUpStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object parameter)
        {
            _stepDelayService.Delay();

            bool didDailySignInGiftWindowPopUp = _webDriverBaseMethodsService.ExistsBy(By.Id("popup_box_daily_bonus"));

            return didDailySignInGiftWindowPopUp;
        }
    }
}