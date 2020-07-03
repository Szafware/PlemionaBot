using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.OutsideGameplay
{
    public class FillUsernameTextBoxStep : StandardStepBase, IStep
    {
        public FillUsernameTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object username)
        {
            _botCheckDetectService.Validate(nameof(FillUsernameTextBoxStep));
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.FillBy(By.Id("user"), (string)username);

            return null;
        }
    }
}