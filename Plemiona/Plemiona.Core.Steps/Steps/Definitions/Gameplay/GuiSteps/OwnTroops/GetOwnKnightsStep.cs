using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetOwnKnightsStep : StandardStepBase
    {
        public GetOwnKnightsStep(
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
                string knightsCountText = _webDriverBaseMethodsService.GetTextBy(By.XPath("//strong[@data-count='knight']"));

                int knightsCount = Convert.ToInt32(knightsCountText);

                return knightsCount;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}