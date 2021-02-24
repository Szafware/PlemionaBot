using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.WebDriverProvider;
using Plemiona.Core.Steps.Steps.Base;

namespace Plemiona.Core.Steps.Steps.Definitions.OutsideGameplay
{
    public class LoadPlemionaWebsiteStep : ComplexStepBase
    {
        public LoadPlemionaWebsiteStep(
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

        public override object Execute(object plemionaUrl)
        {
            _remoteWebDriver = _webDriverProviderService.CreateWebDriver();
            _navigation = _remoteWebDriver.Navigate();

            _plemionaMetadataProviderService.Initialize();
            _webDriverBaseMethodsService.Initialize();

            string plemionaUrlString = plemionaUrl.ToString();

            _navigation.GoToUrl(plemionaUrlString);

            return null;
        }
    }
}