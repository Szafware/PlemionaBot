using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.OutsideGameplay
{
    public class FillPasswordTextBoxStep : StandardStepBase, IStep
    {
        public FillPasswordTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object password)
        {
            _botCheckDetectService.Validate(nameof(FillPasswordTextBoxStep));
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.FillBy(By.Id("password"), (string)password);

            return null;
        }
    }
}