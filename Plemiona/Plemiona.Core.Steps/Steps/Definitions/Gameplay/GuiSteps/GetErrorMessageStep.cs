using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.BuildingSteps
{
    public class GetErrorMessageStep : StandardStepBase, IStep
    {
        public GetErrorMessageStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object parameter)
        {
            var errorMessageElement = _webDriverBaseMethodsService.GetBy(By.XPath("//div[@class='error_box']/div"));

            string errorMessage = errorMessageElement.Text;

            return errorMessage;
        }
    }
}