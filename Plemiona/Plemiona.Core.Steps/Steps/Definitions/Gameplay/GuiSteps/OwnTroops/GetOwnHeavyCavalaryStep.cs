using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetOwnHeavyCavalaryStep : StandardStepBase
    {
        public GetOwnHeavyCavalaryStep(
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
                string heavyCavalaryCountText = _webDriverBaseMethodsService.GetTextBy(By.XPath("//strong[@data-count='heavy']"));

                int heavyCavalaryCount = Convert.ToInt32(heavyCavalaryCountText);

                return heavyCavalaryCount;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}