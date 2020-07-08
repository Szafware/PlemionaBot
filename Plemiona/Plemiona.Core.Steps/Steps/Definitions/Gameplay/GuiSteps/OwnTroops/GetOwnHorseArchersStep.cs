using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetOwnHorseArchersStep : StandardStepBase
    {
        public GetOwnHorseArchersStep(
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
                string horseArchersCountText = _webDriverBaseMethodsService.GetTextBy(By.XPath("//strong[@data-count='marcher']"));

                int horseArchersCount = Convert.ToInt32(horseArchersCountText);

                return horseArchersCount;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}