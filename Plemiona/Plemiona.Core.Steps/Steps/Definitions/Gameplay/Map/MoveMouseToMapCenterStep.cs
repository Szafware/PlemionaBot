using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.TroopSteps
{
    public class MoveMouseToMapCenterStep : StandardStepBase
    {
        public MoveMouseToMapCenterStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public override object Execute(object parameter)
        {
            base.Execute(GetType().Name);

            var mapElement = _webDriverBaseMethodsService.GetBy(By.Id("map_mover"));

            _webDriverBaseMethodsService.MoveMouseOver(mapElement);

            return null;
        }
    }
}