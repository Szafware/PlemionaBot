using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;
using System.Linq;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetVillagePointsStep : StandardStepBase
    {
        public GetVillagePointsStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public override object Execute(object parameter)
        {
            var villageInfoTableElement = _webDriverBaseMethodsService.GetBy(By.XPath("//*[@class='vis']/tbody"));

            var infoRows = villageInfoTableElement.FindElements(By.TagName("tr"));

            var villagePointsInfoRow = infoRows[3];

            string villagePointsText = villagePointsInfoRow.Text;

            villagePointsText = string.Join(string.Empty, villagePointsText.Where(c => char.IsNumber(c)));

            int villagePoints = Convert.ToInt32(villagePointsText);

            return villagePoints;
        }
    }
}