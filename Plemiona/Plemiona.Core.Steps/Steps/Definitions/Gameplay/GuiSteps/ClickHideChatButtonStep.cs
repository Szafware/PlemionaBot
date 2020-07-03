using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps
{
    public class ClickHideChatButtonStep : StandardStepBase, IStep
    {
        public ClickHideChatButtonStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object parameter)
        {
            _botCheckDetectService.Validate(nameof(ClickHideChatButtonStep));
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.ClickBy(By.ClassName("chat-button-minimize"));

            return null;
        }
    }
}