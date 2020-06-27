﻿using Plemiona.Core.Enums;
using Plemiona.Core.Exceptions;
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
                if ((bool)_stepProviderService.GetStep("IsDailySignInGiftWindowPresent").Execute())
                    _stepProviderService.GetStep("ClickDailySignInGiftReceiveButton").Execute();
                _stepProviderService.GetStep("ClickHideChatButton").Execute();
            }
            catch (Exception e)
            {
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
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
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
            }
        }

        public void RecruitTroops(Troops troops)
        {
            try
            {
                if (troops.AreUnsaddledTroopsPresent)
                {
                    _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Barracks);
                    if (troops.Spearmen > 0)
                        _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Spearman, troops.Spearmen));
                    if (troops.Swordmen > 0)
                        _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Swordman, troops.Swordmen));
                    if (troops.Axemen > 0)
                        _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Axeman, troops.Axemen));
                    if (troops.Bowmen > 0)
                        _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Bowman, troops.Bowmen));
                    _stepProviderService.GetStep("ClickUnsaddledTroopsRecruitmentButton").Execute();
                }

                if (troops.AreSaddledTroopsPresent)
                {
                    _stepProviderService.GetStep("ClickVillageViewButton").Execute();
                    _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Stable);
                    if (troops.Scouts > 0)
                        _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Scout, troops.Scouts));
                    if (troops.LightCavalary > 0)
                        _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.LightCavalryman, troops.LightCavalary));
                    if (troops.HorseArchers > 0)
                        _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.HorseArcher, troops.HorseArchers));
                    if (troops.HeavyCavalary > 0)
                        _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.HeavyCavalryman, troops.HeavyCavalary));
                    _stepProviderService.GetStep("ClickSaddledTroopsRecruitmentButton").Execute();
                }

                if (troops.AreWarMachinesTroopsPresent)
                {
                    _stepProviderService.GetStep("ClickVillageViewButton").Execute();
                    _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Workshop);
                    if (troops.Rams > 0)
                        _stepProviderService.GetStep("FillRecruitmentTroopsCountTextBox").Execute(TroopsRecruitment.Create(TroopTypes.Ram, troops.Rams));
                    if (troops.Catapultes > 0)
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
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
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
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
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
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
            }
        }

        public void SendTroops(Troops troops, int coordinateX, int coordinateY, TroopsIntentions troopsIntentions)
        {
            try
            {
                _stepProviderService.GetStep("ClickBuildingPicture").Execute(BuildingTypes.Yard);

                if (troops.Spearmen > 0)
                    _stepProviderService.GetStep("FillYardSpearmenCountTextBox").Execute(troops.Spearmen);
                if (troops.Swordmen > 0)
                    _stepProviderService.GetStep("FillYardSwordmenCountTextBox").Execute(troops.Swordmen);
                if (troops.Axemen > 0)
                    _stepProviderService.GetStep("FillYardAxemenCountTextBox").Execute(troops.Axemen);
                if (troops.Bowmen > 0)
                    _stepProviderService.GetStep("FillYardBowmenCountTextBox").Execute(troops.Bowmen);

                if (troops.Scouts > 0)
                    _stepProviderService.GetStep("FillYardScoutCountTextBox").Execute(troops.Scouts);
                if (troops.LightCavalary > 0)
                    _stepProviderService.GetStep("FillYardLightCavalaryCountTextBox").Execute(troops.LightCavalary);
                if (troops.HorseArchers > 0)
                    _stepProviderService.GetStep("FillYardHorseArchersCountTextBox").Execute(troops.HorseArchers);
                if (troops.HeavyCavalary > 0)
                    _stepProviderService.GetStep("FillYardHeavyCavalaryCountTextBox").Execute(troops.HeavyCavalary);

                if (troops.Rams > 0)
                    _stepProviderService.GetStep("FillYardRamsCountTextBox").Execute(troops.Rams);
                if (troops.Catapultes > 0)
                    _stepProviderService.GetStep("FillYardCatapultesCountTextBox").Execute(troops.Catapultes);

                if (troops.Knights > 0)
                    _stepProviderService.GetStep("FillYardKnightsCountTextBox").Execute(troops.Knights);
                if (troops.Noblemen > 0)
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
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
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
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
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
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
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
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
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
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
            }
        }

        // TODO: Implement
        public Village GetVillage(int coordinateX, int coordinateY)
        {
            try
            {
                var village = new Village();

                _stepProviderService.GetStep("ClickMapButton").Execute();

                throw new NotImplementedException();

                return village;
            }
            catch (Exception e)
            {
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
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
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
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
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
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
                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    string errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                    throw new FeatureException(errorMessage);
                }
                else
                {
                    _featureLoggingService.LogException(e);
                    TryToReturnToVillageView();
                    throw;
                }
            }
        }

        private void TryToReturnToVillageView()
        {
            try
            {
                _stepProviderService.GetStep("ClickVillageViewButton").Execute();
            }
            catch
            {
            }
        }
    }
}