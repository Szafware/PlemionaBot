using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.WebDriverProvider;
using Plemiona.Core.Steps.Steps.Base;
using SeleniumExtras.WaitHelpers;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps
{
    public class IsChatOpenedStep : ComplexStepBase
    {
        public IsChatOpenedStep(
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
            base.Execute(GetType().Name);

            try
            {
                var webDriverWait = new WebDriverWait(_remoteWebDriver, _timeoutForChceckingElementsExistence);
                var element = webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("chat-button-minimize")));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}