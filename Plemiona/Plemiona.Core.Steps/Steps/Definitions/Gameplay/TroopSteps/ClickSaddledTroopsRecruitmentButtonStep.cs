using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.TroopSteps
{
    public class ClickSaddledTroopsRecruitmentButtonStep : StandardStepBase, IStep
    {
        public ClickSaddledTroopsRecruitmentButtonStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object parameter)
        {
            _botCheckDetectService.Validate(nameof(ClickSaddledTroopsRecruitmentButtonStep));
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.ClickBy(By.ClassName("btn-recruit"));

            return null;
        }
    }
}