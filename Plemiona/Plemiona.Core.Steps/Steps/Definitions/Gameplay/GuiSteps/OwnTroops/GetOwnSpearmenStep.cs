using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetOwnSpearmenStep : StandardStepBase
    {
        public GetOwnSpearmenStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public override object Execute(object parameter)
        {
            try
            {
                string spearmenCountText = _webDriverBaseMethodsService.GetTextBy(By.XPath("//strong[@data-count='spear']"));

                int spearmenCount = Convert.ToInt32(spearmenCountText);

                return spearmenCount;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}