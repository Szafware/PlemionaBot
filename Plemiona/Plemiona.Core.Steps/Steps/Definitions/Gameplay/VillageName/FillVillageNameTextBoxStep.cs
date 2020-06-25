using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.VillageName
{
    public class FillVillageNameTextBoxStep : StandardStepBase, IStep
    {
        public FillVillageNameTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object villageName)
        {
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.FillBy(By.Name("name"), (string)villageName);

            return null;
        }
    }
}