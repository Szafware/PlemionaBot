using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.WebDriverProvider;
using Plemiona.Core.Steps.Steps.Base;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.DailyBonusSteps
{
    public class ClickDailySignInGiftReceiveButtonStep : ComplexStepBase
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

        public override object Execute(object parameter)
        {
            var giftButtons = _remoteWebDriver.FindElementsByClassName("btn-default");

            foreach (var giftButton in giftButtons)
            {
                base.Execute(GetType().Name);

                giftButton.Click();
            }

            return null;
        }
    }
}