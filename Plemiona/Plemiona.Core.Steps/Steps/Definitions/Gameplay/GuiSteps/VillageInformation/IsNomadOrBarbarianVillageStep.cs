using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class IsNomadOrBarbarianVillageStep : StandardStepBase, IStep
    {
        public IsNomadOrBarbarianVillageStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object parameter)
        {
            _botCheckDetectService.Validate(nameof(ClickVillageViewButtonStep));

            var villageInfoTableElement = _webDriverBaseMethodsService.GetBy(By.XPath("//*[@class='vis']/tbody"));

            var infoRows = villageInfoTableElement.FindElements(By.TagName("tr"));

            int barbarianVillageInfoRowCount = 5;

            bool isBarbarianVillageStep = infoRows.Count == barbarianVillageInfoRowCount;

            return isBarbarianVillageStep;
        }
    }
}