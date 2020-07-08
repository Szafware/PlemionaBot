using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetOwnRamsStep : StandardStepBase
    {
        public GetOwnRamsStep(
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
                string ramsText = _webDriverBaseMethodsService.GetTextBy(By.XPath("//strong[@data-count='ram']"));

                int ramsCount = Convert.ToInt32(ramsText);

                return ramsCount;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}