using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using SeleniumExtras.WaitHelpers;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.TroopSteps
{
    public class FillKnightNameTextBoxStep : StandardStepBase, IStep
    {
        public FillKnightNameTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object knightName)
        {
            _botCheckDetectService.Validate(nameof(FillKnightNameTextBoxStep));
            _stepDelayService.Delay();

            var elementIndicator = ExpectedConditions.ElementExists(By.Id("knight_recruit_name"));

            _webDriverBaseMethodsService.ClearByAndCondition(elementIndicator, _timeoutForExpectedElements);

            _webDriverBaseMethodsService.FillByAndCondition(elementIndicator, _timeoutForExpectedElements, knightName.ToString());

            return null;
        }
    }
}