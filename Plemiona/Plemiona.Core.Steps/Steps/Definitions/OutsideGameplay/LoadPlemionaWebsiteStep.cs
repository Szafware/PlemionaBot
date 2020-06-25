using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;
using Plemiona.Core.Services.WebDriverProvider;

namespace Plemiona.Core.Steps.Steps.Definitions.OutsideGameplay
{
    public class LoadPlemionaWebsiteStep : ComplexStepBase, IStep
    {
        public LoadPlemionaWebsiteStep(
            IWebDriverProviderService webDriverProviderService,
            IPlemionaMetadataProviderService plemionaMetadataProviderService,
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService
            ) : base(webDriverProviderService, plemionaMetadataProviderService, webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object parameter)
        {
            _stepDelayService.Delay();

            _remoteWebDriver = _webDriverProviderService.CreateWebDriver();
            _navigation = _remoteWebDriver.Navigate();

            _plemionaMetadataProviderService.Initialize();
            _webDriverBaseMethodsService.Initialize();

            _navigation.GoToUrl(_plemionaUrl);

            return null;
        }
    }
}