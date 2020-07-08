using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetOwnSwordmenStep : StandardStepBase
    {
        public GetOwnSwordmenStep(
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
                string swordmenText = _webDriverBaseMethodsService.GetTextBy(By.XPath("//strong[@data-count='sword']"));

                int swordmenCount = Convert.ToInt32(swordmenText);

                return swordmenCount;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}