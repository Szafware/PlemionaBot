using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;
using System.Drawing;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.VillageName
{
    public class FillYardVillageCoordinatesTextBoxStep : StandardStepBase, IStep
    {
        public FillYardVillageCoordinatesTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object coordinates)
        {
            _stepDelayService.Delay();

            var villageCoordinates = (Point)coordinates;

            _webDriverBaseMethodsService.FillBy(By.ClassName("target-input-field"), $"{villageCoordinates.X}|{villageCoordinates.Y}");

            return null;
        }
    }
}