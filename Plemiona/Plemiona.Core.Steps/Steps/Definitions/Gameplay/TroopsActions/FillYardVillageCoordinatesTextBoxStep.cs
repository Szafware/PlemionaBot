using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using System.Drawing;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.VillageName
{
    public class FillYardVillageCoordinatesTextBoxStep : StandardStepBase, IStep
    {
        public FillYardVillageCoordinatesTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object coordinates)
        {
            _botCheckDetectService.Validate(nameof(FillYardSwordmenCountTextBoxStep));
            _stepDelayService.Delay();

            var villageCoordinates = (Point)coordinates;

            _webDriverBaseMethodsService.FillBy(By.ClassName("target-input-field"), $"{villageCoordinates.X}|{villageCoordinates.Y}");

            return null;
        }
    }
}