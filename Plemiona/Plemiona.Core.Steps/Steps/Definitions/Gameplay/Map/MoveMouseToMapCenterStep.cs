using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.TroopSteps
{
    public class MoveMouseToMapCenterStep : StandardStepBase, IStep
    {
        public MoveMouseToMapCenterStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object parameter)
        {
            _botCheckDetectService.Validate(nameof(ClickKnightRevivalButtonStep));
            _stepDelayService.Delay();

            var mapElement = _webDriverBaseMethodsService.GetBy(By.Id("map_mover"));

            _webDriverBaseMethodsService.MoveMouseOver(mapElement);

            return null;
        }
    }
}