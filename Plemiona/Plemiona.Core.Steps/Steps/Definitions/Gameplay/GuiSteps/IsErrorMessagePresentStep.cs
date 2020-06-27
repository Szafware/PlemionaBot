using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.BuildingSteps
{
    public class IsErrorMessagePresentStep : StandardStepBase, IStep
    {
        public IsErrorMessagePresentStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object parameter)
        {
            bool isErrorMessagePresent = _webDriverBaseMethodsService.ExistsBy(By.ClassName("error_box"));

            return isErrorMessagePresent;
        }
    }
}