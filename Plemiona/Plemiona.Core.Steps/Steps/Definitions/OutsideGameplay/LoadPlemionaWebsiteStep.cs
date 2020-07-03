using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.WebDriverProvider;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.OutsideGameplay
{
    public class LoadPlemionaWebsiteStep : ComplexStepBase, IStep
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

        public object Execute(object parameter)
        {
            _remoteWebDriver = _webDriverProviderService.CreateWebDriver();
            _navigation = _remoteWebDriver.Navigate();

            _plemionaMetadataProviderService.Initialize();
            _webDriverBaseMethodsService.Initialize();

            _navigation.GoToUrl(_plemionaUrl);

            return null;
        }
    }
}