using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.BuildingSteps
{
    public class GetPlayerNameStep : StandardStepBase, IStep
    {
        public GetPlayerNameStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object parameter)
        {
            string playerName = _plemionaMetadata.PlayerName;

            return playerName;
        }
    }
}