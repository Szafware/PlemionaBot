using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using SeleniumExtras.WaitHelpers;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps
{
    public class CanSkipKnightRecruitmentStep : StandardStepBase, IStep
    {
        public CanSkipKnightRecruitmentStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object parameter)
        {
            bool canSkipKnightRecruitment = _webDriverBaseMethodsService.ExistsByAndCondition(ExpectedConditions.ElementExists(By.ClassName("knight_recruit_rush")), _timeoutForChceckingElementsExistence);

            return canSkipKnightRecruitment;
        }
    }
}