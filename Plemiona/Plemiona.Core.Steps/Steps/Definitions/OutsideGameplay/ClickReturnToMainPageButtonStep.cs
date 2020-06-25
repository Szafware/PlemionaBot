using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;

namespace Plemiona.Core.Steps.Steps.Definitions.OutsideGameplay
{
    public class ClickReturnToMainPageButtonStep : StandardStepBase, IStep
    {
        public ClickReturnToMainPageButtonStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object parameter)
        {
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.ClickBy(By.XPath("//div[@class='button small']"));

            return null;
        }
    }
}