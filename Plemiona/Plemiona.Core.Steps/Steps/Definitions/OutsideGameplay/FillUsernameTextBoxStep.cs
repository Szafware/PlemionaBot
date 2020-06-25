using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;

namespace Plemiona.Core.Steps.Steps.Definitions.OutsideGameplay
{
    public class FillUsernameTextBoxStep : StandardStepBase, IStep
    {
        public FillUsernameTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }
        
        public object Execute(object username)
        {
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.FillBy(By.Id("user"), (string)username);

            return null;
        }
    }
}