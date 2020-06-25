using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;
using SeleniumExtras.WaitHelpers;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps
{
    public class CanSkipKnightRecruitmentStep : StandardStepBase, IStep
    {
        public CanSkipKnightRecruitmentStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object parameter)
        {
            bool canSkipKnightRecruitment = _webDriverBaseMethodsService.ExistsByAndCondition(ExpectedConditions.ElementExists(By.ClassName("knight_recruit_rush")), _timeoutForChceckingElementsExistence);

            return canSkipKnightRecruitment;
        }
    }
}