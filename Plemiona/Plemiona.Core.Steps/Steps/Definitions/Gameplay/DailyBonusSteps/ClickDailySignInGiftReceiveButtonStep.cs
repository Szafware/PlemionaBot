using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.WebDriverProvider;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.DailyBonusSteps
{
    public class ClickDailySignInGiftReceiveButtonStep : ComplexStepBase, IStep
    {
        public ClickDailySignInGiftReceiveButtonStep(
            IWebDriverProviderService webDriverProviderService,
            IPlemionaMetadataProviderService plemionaMetadataProviderService,
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService
            ) : base(
                webDriverProviderService,
                plemionaMetadataProviderService,
                webDriverBaseMethodsService,
                stepDelayService,
                botCheckDetectService)
        {
        }

        public object Execute(object parameter)
        {
            var giftButtons = _remoteWebDriver.FindElementsByClassName("btn-default");

            foreach (var giftButton in giftButtons)
            {
                _botCheckDetectService.Validate(nameof(ClickDailySignInGiftReceiveButtonStep));
                _stepDelayService.Delay();

                giftButton.Click();
            }

            return null;
        }
    }
}