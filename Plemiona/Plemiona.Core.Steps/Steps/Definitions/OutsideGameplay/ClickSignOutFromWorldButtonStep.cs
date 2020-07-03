using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.OutsideGameplay
{
    public class ClickSignOutFromWorldButtonStep : StandardStepBase, IStep
    {
        public ClickSignOutFromWorldButtonStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object parameter)
        {
            _botCheckDetectService.Validate(nameof(ClickSignOutFromWorldButtonStep));
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.ClickBy(By.XPath($"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=&action=logout&h={_plemionaMetadata.CsrfToken}']"));

            return null;
        }
    }
}