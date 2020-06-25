using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;

namespace Plemiona.Core.Steps.Steps.Definitions.OutsideGameplay
{
    public class FillPasswordTextBoxStep : StandardStepBase, IStep
    {
        public FillPasswordTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object password)
        {
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.FillBy(By.Id("password"), (string)password);

            return null;
        }
    }
}