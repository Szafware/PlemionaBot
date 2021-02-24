using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.WebDriverProvider;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Base
{
    public abstract class ComplexStepBase : StandardStepBase
    {
        protected readonly IWebDriverProviderService _webDriverProviderService;
        protected readonly IPlemionaMetadataProviderService _plemionaMetadataProviderService;

        protected static RemoteWebDriver _remoteWebDriver;
        protected static INavigation _navigation;

        public ComplexStepBase(
            IWebDriverProviderService webDriverProviderService,
            IPlemionaMetadataProviderService plemionaMetadataProviderService,
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
            _webDriverProviderService = webDriverProviderService;
            _plemionaMetadataProviderService = plemionaMetadataProviderService;
        }
    }
}