using Plemiona.Core.Enums;
using Plemiona.Core.Interfaces.Features;
using Plemiona.Core.Models;
using Plemiona.Core.Models.Steps;
using Plemiona.Core.Services.FeatureLogging;
using Plemiona.Core.Steps.Services.StepProvider;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Plemiona.Core.Features
{
    public class PlemionaDefaultFeatures : IPlemionaFeatures
    {
        private readonly IStepProviderService _stepProviderService;
        private readonly IFeatureLoggingService _featureLoggingService;

        public PlemionaDefaultFeatures(
            IStepProviderService stepProviderService,
            IFeatureLoggingService featureLoggingService
            )
        {
            _stepProviderService = stepProviderService;
            _featureLoggingService = featureLoggingService;
        }

        public void SignIn(string username, string password, int worldNumber)
        {
            try
            {
                _stepProviderService.GetStep("LoadPlemionaWebsite").Execute();
                if ((bool)_stepProviderService.GetStep("IsPlayerSignedIn").Execute())
                    _stepProviderService.GetStep("ClickSignOutFromAccountButton").Execute();
                _stepProviderService.GetStep("FillUsernameTextBox").Execute("Dziaczakra");
                _stepProviderService.GetStep("FillPasswordTextBox").Execute(password);
                _stepProviderService.GetStep("ClickSignInButton").Execute();
                _stepProviderService.GetStep("ClickWorldButton").Execute(worldNumber);
                if ((bool)_stepProviderService.GetStep("DidDailySignInGiftWindowPopUp").Execute())
                    _stepProviderService.GetStep("ClickDailySignInGiftReceiveButton").Execute();
                _stepProviderService.GetStep("ClickHideChatButton").Execute();
            }
            catch (Exception e)
            {
                _featureLoggingService.LogException(e);
                throw;
            }
        }

        // TODO: Implement
        public void SwitchToVillage(string villageName)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void RecruitTroops(Troops troops)
        {
            try
            {
                if (troops.AreUnsaddledTroopsPresent)
                {
                    _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Barracks);
                    _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Spearman, troops.Spearmen));
                    _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Swordman, troops.Swordmen));
                    _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Axeman, troops.Axemen));
                    _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Bowman, troops.Bowmen));
                    _stepProviderService.GetStep("ClickUnsaddledTroopsRecruitmentButton").Execute();
                }

                if (troops.AreSaddledTroopsPresent)
                {
                    _stepProviderService.GetStep("ClickVillageViewButton").Execute();
                    _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Stable);
                    _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Scout, troops.Scouts));
                    _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.LightCavalryman, troops.LightCavalary));
                    _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.HorseArcher, troops.HorseArchers));
                    _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.HeavyCavalryman, troops.HeavyCavalary));
                    _stepProviderService.GetStep("ClickSaddledTroopsRecruitmentButton").Execute();
                }

                if (troops.AreWarMachinesTroopsPresent)
                {
                    _stepProviderService.GetStep("ClickVillageViewButton").Execute();
                    _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Workshop);
                    _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Ram, troops.Rams));
                    _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Catapulte, troops.Catapultes));
                    _stepProviderService.GetStep("ClickWarMachinesRecruitmentButton").Execute();
                }

                if (troops.Noblemen > 0)
                {
                    _stepProviderService.GetStep("ClickVillageViewButton").Execute();
                    _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Palace);
                    _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Nobleman, troops.Noblemen));
                    _stepProviderService.GetStep("ClickNoblemenRecruitmentButton").Execute();
                }

                _stepProviderService.GetStep("ClickVillageViewButton").Execute();
            }
            catch (Exception e)
            {
                _featureLoggingService.LogException(e);
                throw;
            }
        }

        public void RecruitKnight(string knightName)
        {
            try
            {
                _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Statue);
                _stepProviderService.GetStep("ClickKnightRecruitmentButton").Execute();
                _stepProviderService.GetStep("ClearKnightNameTextBox").Execute();
                _stepProviderService.GetStep("FillKnightNameTextBox").Execute(knightName);
                _stepProviderService.GetStep("ClickKnightRecruitmentConfirmationButton").Execute();
                if ((bool)_stepProviderService.GetStep("CanSkipKnightRecruitment").Execute())
                    _stepProviderService.GetStep("ClickKnightRecruitmentSkipButton").Execute();
                _stepProviderService.GetStep("ClickVillageViewButton").Execute();
            }
            catch (Exception e)
            {
                _featureLoggingService.LogException(e);
                throw;
            }
        }

        public void ReviveKnight()
        {
            try
            {
                _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Statue);
                _stepProviderService.GetStep("ClickKnightRevivalButton").Execute();
                _stepProviderService.GetStep("ClickKnightRevivalConfirmationButton").Execute();
                _stepProviderService.GetStep("ClickVillageViewButton").Execute();
            }
            catch (Exception e)
            {
                _featureLoggingService.LogException(e);
                throw;
            }
        }

        public void SendTroops(Troops troops, int coordinateX, int coordinateY, TroopsIntentions troopsIntentions)
        {
            try
            {
                _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Yard);

                _stepProviderService.GetStep("FillYardSpearmenCountTextBox").Execute(troops.Spearmen);
                _stepProviderService.GetStep("FillYardSwordmenCountTextBox").Execute(troops.Swordmen);
                _stepProviderService.GetStep("FillYardAxemenCountTextBox").Execute(troops.Axemen);
                _stepProviderService.GetStep("FillYardBowmenCountTextBox").Execute(troops.Bowmen);

                _stepProviderService.GetStep("FillYardScoutCountTextBox").Execute(troops.Scouts);
                _stepProviderService.GetStep("FillYardLightCavalaryCountTextBox").Execute(troops.LightCavalary);
                _stepProviderService.GetStep("FillYardHorseArchersCountTextBox").Execute(troops.HorseArchers);
                _stepProviderService.GetStep("FillYardHeavyCavalaryCountTextBox").Execute(troops.HeavyCavalary);

                _stepProviderService.GetStep("FillYardRamsCountTextBox").Execute(troops.Rams);
                _stepProviderService.GetStep("FillYardCatapultesCountTextBox").Execute(troops.Catapultes);

                _stepProviderService.GetStep("FillYardKnightsCountTextBox").Execute(troops.Knights);
                _stepProviderService.GetStep("FillYardNobelmenCountTextBox").Execute(troops.Noblemen);

                _stepProviderService.GetStep("FillYardVillageCoordinatesTextBox").Execute(new Point(coordinateX, coordinateY));

                if (troopsIntentions == TroopsIntentions.Attack)
                    _stepProviderService.GetStep("ClickSendAttackButton").Execute();
                else
                    _stepProviderService.GetStep("ClickSendHelpButton").Execute();

                _stepProviderService.GetStep("ClickSendTroopsConfirmationButton").Execute();

                _stepProviderService.GetStep("ClickVillageViewButton").Execute();
            }
            catch (Exception e)
            {
                _featureLoggingService.LogException(e);
                throw;
            }
        }

        public Resources GetResources()
        {
            try
            {
                var resources = new Resources
                {
                    Wood = (int)_stepProviderService.GetStep("GetWood").Execute(),
                    Clay = (int)_stepProviderService.GetStep("GetClay").Execute(),
                    Iron = (int)_stepProviderService.GetStep("GetIron").Execute(),
                };

                return resources;
            }
            catch (Exception e)
            {
                _featureLoggingService.LogException(e);
                throw;
            }
        }

        public Buildings GetBuildings()
        {
            try
            {
                _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Townhall);

                var buildings = new Buildings
                {
                    Townhall = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Townhall),
                    Barracks = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Barracks),
                    Stable = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Stable),
                    Workshop = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Workshop),
                    Palace = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Palace),
                    Forge = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Forge),
                    Yard = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Yard),
                    Statue = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Statue),
                    Market = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Market),
                    Sawmill = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Sawmill),
                    Brickyard = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Brickyard),
                    Ironworks = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Ironworks),
                    Farm = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Farm),
                    Storage = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Storage),
                    Clipboard = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Clipboard),
                    Wall = (int)_stepProviderService.GetStep("GetBuildingLevel").Execute(BuildingTypes.Wall)
                };

                _stepProviderService.GetStep("ClickVillageViewButton").Execute();

                return buildings;
            }
            catch (Exception e)
            {
                _featureLoggingService.LogException(e);
                throw;
            }
        }

        public void ChangeVillageName(string villageName)
        {
            try
            {
                _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Townhall);
                _stepProviderService.GetStep("ClearVillageNameTextBox").Execute();
                _stepProviderService.GetStep("FillVillageNameTextBox").Execute(villageName);
                _stepProviderService.GetStep("ClickVillageNameChangeButton").Execute();
                _stepProviderService.GetStep("ClickVillageViewButton").Execute();
            }
            catch (Exception e)
            {
                _featureLoggingService.LogException(e);
                throw;
            }
        }

        // TODO: Implementation
        public IEnumerable<Village> GetNerbaryVillages(int radiusFields)
        {
            try
            {
                _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Yard);

                throw new NotImplementedException();

                return new List<Village>();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void AddBuildingToQueue(BuildingTypes building)
        {
            try
            {
                _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Townhall);
                _stepProviderService.GetStep("ClickAddBuildingToBuildQueueButton").Execute(building);
                _stepProviderService.GetStep("ClickVillageViewButton").Execute();
            }
            catch (Exception e)
            {
                _featureLoggingService.LogException(e);
                throw;
            }
        }

        // TODO: Implementation
        public Player GetSelfInformation()
        {
            try
            {
                var player = new Player();
                _stepProviderService.GetStep("ClickPlayerInformationButtonStep").Execute();
                string playerName = (string)_stepProviderService.GetStep("GetPlayerButtonTextFromProfileButtons").Execute();
                var villageRows = _stepProviderService.GetStep("GetVillageRows").Execute();

                throw new NotImplementedException();

                return player;
            }
            catch (Exception e)
            {
                _featureLoggingService.LogException(e);
                throw;
            }
        }

        public void SignOut()
        {
            try
            {
                _stepProviderService.GetStep("ClickSignOutFromWorldButton").Execute();
                _stepProviderService.GetStep("ClickReturnToMainPageButton").Execute();
                _stepProviderService.GetStep("ClickSignOutFromAccountButton").Execute();
            }
            catch (Exception e)
            {
                _featureLoggingService.LogException(e);
                throw;
            }
        }
    }
}