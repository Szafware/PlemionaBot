using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System.Drawing;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.VillageName
{
    public class FillYardVillageCoordinatesTextBoxStep : StandardStepBase
    {
        public FillYardVillageCoordinatesTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public override object Execute(object coordinates)
        {
            base.Execute(GetType().Name);

            var villageCoordinates = (Point)coordinates;

            _webDriverBaseMethodsService.FillBy(By.ClassName("target-input-field"), $"{villageCoordinates.X}|{villageCoordinates.Y}");

            return null;
        }
    }
}