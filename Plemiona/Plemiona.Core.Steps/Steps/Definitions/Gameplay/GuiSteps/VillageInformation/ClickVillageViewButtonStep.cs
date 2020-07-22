using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class ClickVillageViewButtonStep : StandardStepBase
    {
        public ClickVillageViewButtonStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public override object Execute(object parameter)
        {
            _botCheckDetectService.Validate(nameof(ClickVillageViewButtonStep));
            base.Execute(GetType().Name);

            _webDriverBaseMethodsService.ClickBy(By.XPath($"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=overview']"));

            return null;
        }
    }
}