using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.WebDriverBase;
using Plemiona.Core.Services.WebDriverProvider;

namespace Plemiona.Core.Steps.Steps.Base
{
    public abstract class ComplexStepBase : StandardStepBase
    {
        protected readonly IWebDriverProviderService _webDriverProviderService;
        protected readonly IPlemionaMetadataProviderService _plemionaMetadataProviderService;

        protected readonly string _plemionaUrl = "https://www.plemiona.pl/";

        protected static RemoteWebDriver _remoteWebDriver;
        protected static INavigation _navigation;

        public ComplexStepBase(
            IWebDriverProviderService webDriverProviderService,
            IPlemionaMetadataProviderService plemionaMetadataProviderService,
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
            _webDriverProviderService = webDriverProviderService;
            _plemionaMetadataProviderService = plemionaMetadataProviderService;
        }
    }
}