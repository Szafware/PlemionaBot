using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetVillageNameStep : StandardStepBase
    {
        public GetVillageNameStep(
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

            var villageNameInfoRow = infoRows[0];

            string villageName = villageNameInfoRow.Text;

            return villageName;
        }
    }
}