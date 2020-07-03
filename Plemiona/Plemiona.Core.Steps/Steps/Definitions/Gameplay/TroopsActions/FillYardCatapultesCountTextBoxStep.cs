using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.VillageName
{
    public class FillYardCatapultesCountTextBoxStep : StandardStepBase, IStep
    {
        public FillYardCatapultesCountTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object count)
        {
            _botCheckDetectService.Validate(nameof(FillYardCatapultesCountTextBoxStep));
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.FillBy(By.Id("unit_input_catapult"), count.ToString());

            return null;
        }
    }
}