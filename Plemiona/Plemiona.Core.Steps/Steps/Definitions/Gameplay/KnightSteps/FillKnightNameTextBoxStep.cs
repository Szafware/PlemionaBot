using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using SeleniumExtras.WaitHelpers;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.TroopSteps
{
    public class FillKnightNameTextBoxStep : StandardStepBase
    {
        public FillKnightNameTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public override object Execute(object knightName)
        {
            base.Execute(GetType().Name);

            var elementIndicator = ExpectedConditions.ElementExists(By.Id("knight_recruit_name"));

            _webDriverBaseMethodsService.ClearByAndCondition(elementIndicator, _timeoutForExpectedElements);

            _webDriverBaseMethodsService.FillByAndCondition(elementIndicator, _timeoutForExpectedElements, knightName.ToString());

            return null;
        }
    }
}