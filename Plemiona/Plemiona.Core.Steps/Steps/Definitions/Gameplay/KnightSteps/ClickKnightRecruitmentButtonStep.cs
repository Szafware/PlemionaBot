using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.TroopSteps
{
    public class ClickKnightRecruitmentButtonStep : StandardStepBase, IStep
    {
        public ClickKnightRecruitmentButtonStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object parameter)
        {
            _botCheckDetectService.Validate(nameof(ClickKnightRecruitmentButtonStep));
            _stepDelayService.Delay();

            // btn_recruit w innym trybie
            _webDriverBaseMethodsService.ClickBy(By.ClassName("knight_recruit_launch"));

            return null;
        }
    }
}