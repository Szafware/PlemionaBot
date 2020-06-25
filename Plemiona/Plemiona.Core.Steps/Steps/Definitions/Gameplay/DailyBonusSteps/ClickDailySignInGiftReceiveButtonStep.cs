using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;
using Plemiona.Core.Services.WebDriverProvider;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.DailyBonusSteps
{
    public class ClickDailySignInGiftReceiveButtonStep : ComplexStepBase, IStep
    {
        public ClickDailySignInGiftReceiveButtonStep(
            IWebDriverProviderService webDriverProviderService,
            IPlemionaMetadataProviderService plemionaMetadataProviderService,
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService
            ) : base(webDriverProviderService, plemionaMetadataProviderService, webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object parameter)
        {
            var giftButtons = _remoteWebDriver.FindElementsByClassName("btn-default");

            foreach (var giftButton in giftButtons)
            {
                _stepDelayService.Delay();

                giftButton.Click();
            }

            return null;
        }
    }
}