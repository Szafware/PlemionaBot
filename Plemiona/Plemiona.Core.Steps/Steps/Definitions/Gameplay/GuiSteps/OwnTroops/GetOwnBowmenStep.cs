using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetOwnBowmenStep : StandardStepBase
    {
        public GetOwnBowmenStep(
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
                string bowmenCountText = _webDriverBaseMethodsService.GetTextBy(By.XPath("//strong[@data-count='bow']"));

                int bowmenCount = Convert.ToInt32(bowmenCountText);

                return bowmenCount;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}