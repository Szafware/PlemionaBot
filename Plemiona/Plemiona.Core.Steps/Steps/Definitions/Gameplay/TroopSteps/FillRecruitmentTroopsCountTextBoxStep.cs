using OpenQA.Selenium;
using Plemiona.Core.Enums;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Models.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using System;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.TroopSteps
{
    public class FillRecruitmentTroopsCountTextBoxStep : StandardStepBase, IStep
    {
        public FillRecruitmentTroopsCountTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object troopRecruitmentObject)
        {
            _botCheckDetectService.Validate(nameof(FillRecruitmentTroopsCountTextBoxStep));
            _stepDelayService.Delay();

            var troopRecruitment = (TroopsRecruitment)troopRecruitmentObject;

            string recruitmentTroopsTextBoxId = null;

            switch (troopRecruitment.TroopTypes)
            {
                case TroopTypes.Spearman: recruitmentTroopsTextBoxId = "spear_0"; break;
                case TroopTypes.Swordman: recruitmentTroopsTextBoxId = "sword_0"; break;
                case TroopTypes.Axeman: recruitmentTroopsTextBoxId = "axe_0"; break;
                case TroopTypes.Bowman: recruitmentTroopsTextBoxId = "bow_0"; break;
                case TroopTypes.Scout: recruitmentTroopsTextBoxId = "spy_0"; break;
                case TroopTypes.LightCavalryman: recruitmentTroopsTextBoxId = "light_0"; break;
                case TroopTypes.HorseArcher: recruitmentTroopsTextBoxId = ""; break;
                case TroopTypes.HeavyCavalryman: recruitmentTroopsTextBoxId = ""; break;
                case TroopTypes.Ram: recruitmentTroopsTextBoxId = ""; break;
                case TroopTypes.Catapulte: recruitmentTroopsTextBoxId =""; break;
                case TroopTypes.Nobleman: recruitmentTroopsTextBoxId = ""; break;
                case TroopTypes.Knight: throw new Exception("Knight cannot be recruited.");
                case TroopTypes.Peasant: throw new Exception("Peasants cannot be recruited.");
                default: throw new NotImplementedException();
            }

            _webDriverBaseMethodsService.FillBy(By.Id(recruitmentTroopsTextBoxId), troopRecruitment.Count.ToString());

            return null;
        }
    }
}