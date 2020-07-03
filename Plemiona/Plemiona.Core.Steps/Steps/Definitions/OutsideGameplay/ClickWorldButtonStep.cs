using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.WebDriverProvider;
using SeleniumExtras.WaitHelpers;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.OutsideGameplay
{
    public class ClickWorldButtonStep : ComplexStepBase, IStep
    {
        public ClickWorldButtonStep(
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

        public object Execute(object worldNumber)
        {
            _botCheckDetectService.Validate(nameof(ClickWorldButtonStep));
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.ClickByAndCondition(ExpectedConditions.ElementExists(By.XPath($"//span[contains(text(),'{worldNumber}')]")), _timeoutForExpectedElements);

            var plemionaMetadata = _plemionaMetadataProviderService.Create();

            _plemionaMetadata = plemionaMetadata;

            return null;
        }
    }
}