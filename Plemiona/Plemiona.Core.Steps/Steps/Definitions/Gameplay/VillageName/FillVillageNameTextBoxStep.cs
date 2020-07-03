using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.VillageName
{
    public class FillVillageNameTextBoxStep : StandardStepBase, IStep
    {
        public FillVillageNameTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object villageName)
        {
            _botCheckDetectService.Validate(nameof(FillVillageNameTextBoxStep));
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.FillBy(By.Name("name"), (string)villageName);

            return null;
        }
    }
}