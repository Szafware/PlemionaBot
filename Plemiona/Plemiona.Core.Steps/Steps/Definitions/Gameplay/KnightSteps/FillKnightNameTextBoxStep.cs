using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;
using SeleniumExtras.WaitHelpers;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.TroopSteps
{
    public class FillKnightNameTextBoxStep : StandardStepBase, IStep
    {
        public FillKnightNameTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object knightName)
        {
            _stepDelayService.Delay();

            var elementIndicator = ExpectedConditions.ElementExists(By.Id("knight_recruit_name"));

            _webDriverBaseMethodsService.ClearByAndCondition(elementIndicator, _timeoutForExpectedElements);

            _webDriverBaseMethodsService.FillByAndCondition(elementIndicator, _timeoutForExpectedElements, knightName.ToString());

            return null;
        }
    }
}