using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.TroopSteps
{
    public class ClickKnightRecruitmentSkipButtonStep : StandardStepBase, IStep
    {
        public ClickKnightRecruitmentSkipButtonStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object parameter)
        {
            _botCheckDetectService.Validate(nameof(ClickKnightRecruitmentSkipButtonStep));
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.ClickBy(By.Id("knight_recruit_confirm"));

            return null;
        }
    }
}