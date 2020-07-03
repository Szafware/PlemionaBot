using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.BuildingSteps
{
    public class IsErrorMessagePresentStep : StandardStepBase, IStep
    {
        public IsErrorMessagePresentStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object parameter)
        {
            bool isErrorMessagePresent = _webDriverBaseMethodsService.ExistsBy(By.ClassName("error_box"));

            return isErrorMessagePresent;
        }
    }
}