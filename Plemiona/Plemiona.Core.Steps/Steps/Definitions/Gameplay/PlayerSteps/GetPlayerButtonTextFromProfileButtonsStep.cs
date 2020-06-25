using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.BuildingSteps
{
    public class GetPlayerButtonTextFromProfileButtonsStep : StandardStepBase, IStep
    {
        public GetPlayerButtonTextFromProfileButtonsStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object parameter)
        {
            string playerName = _webDriverBaseMethodsService.GetTextBy(By.XPath($"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=info_player']"));

            return playerName;
        }
    }
}