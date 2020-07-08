using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetOwnAxemenStep : StandardStepBase
    {
        public GetOwnAxemenStep(
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
                string axemenCountText = _webDriverBaseMethodsService.GetTextBy(By.XPath("//strong[@data-count='axe']"));

                int axemenCount = Convert.ToInt32(axemenCountText);

                return axemenCount;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}