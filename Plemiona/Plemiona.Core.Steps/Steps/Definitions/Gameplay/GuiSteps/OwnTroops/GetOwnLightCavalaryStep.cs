using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetOwnLightCavalaryStep : StandardStepBase
    {
        public GetOwnLightCavalaryStep(
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
                string lightCavalaryCountText = _webDriverBaseMethodsService.GetTextBy(By.XPath("//strong[@data-count='light']"));

                int lightCavalaryCount = Convert.ToInt32(lightCavalaryCountText);

                return lightCavalaryCount;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}