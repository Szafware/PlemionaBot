using Plemiona.Core.Enums;
using Plemiona.Core.Exceptions;
using Plemiona.Core.Interfaces.Features;
using Plemiona.Core.Models;
using Plemiona.Core.Models.Features;
using Plemiona.Core.Models.Gui;
using Plemiona.Core.Models.Steps;
using Plemiona.Core.Services.FeatureLogging;
using Plemiona.Core.Steps.Services.StepProvider;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace Plemiona.Core.Features
{
    public class PlemionaDefaultFeatures : IPlemionaFeatures
    {
        private readonly IStepProviderService _stepProviderService;
        private readonly IFeatureLoggingService _featureLoggingService;
        private readonly PlemionaMetadata _plemionaMetadata;

        public PlemionaDefaultFeatures(
            IStepProviderService stepProviderService,
            IFeatureLoggingService featureLoggingService,
            PlemionaMetadata plemionaMetadata
            )
        {
            _stepProviderService = stepProviderService;
            _featureLoggingService = featureLoggingService;
            _plemionaMetadata = plemionaMetadata;
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
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        // TODO: Implement
        public void SwitchToVillage(string villageName)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
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
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
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
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
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
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        public void SendTroops(Troops troops, int coordinateX, int coordinateY, TroopsIntentions troopsIntentions, SendingTroopsInfo sendingTroopsInfo = null)
        {
            try
            {
                if ((sendingTroopsInfo == null) || (sendingTroopsInfo.CurrentActionNumber == 1))
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

                if ((sendingTroopsInfo == null) || sendingTroopsInfo.IsLastActionInSequence)
                    _stepProviderService.GetStep("ClickVillageViewButton").Execute();
            }
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
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
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
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
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
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
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
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
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        public Village GetVillage(int coordinateX, int coordinateY)
        {
            try
            {
                var village = new Village
                {
                    Location = new Point(coordinateX, coordinateY)
                };

                _stepProviderService.GetStep("ClickMapButton").Execute();
                _stepProviderService.GetStep("FillVillageCoordinateXMapCenter").Execute(coordinateX);
                _stepProviderService.GetStep("FillVillageCoordinateYMapCenter").Execute(coordinateY);
                _stepProviderService.GetStep("ClickCenterVillageInMapButton").Execute();
                _stepProviderService.GetStep("MoveMouseToMapCenter").Execute();
                _stepProviderService.GetStep("ClickMap").Execute();
                _stepProviderService.GetStep("ClickVillageInformationButton").Execute();

                village.Name = (string)_stepProviderService.GetStep("GetVillageName").Execute();
                village.Points = (int)_stepProviderService.GetStep("GetVillagePoints").Execute();
                village.IsNomadOrBarbarian = (bool)_stepProviderService.GetStep("IsNomadOrBarbarianVillage").Execute();

                return village;
            }
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
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
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        // TODO: Implementation
        public OwnPlayer GetOwnPlayer()
        {
            try
            {
                var ownPlayer = new OwnPlayer { Name = (string)_stepProviderService.GetStep("GetPlayerName").Execute() };
                _stepProviderService.GetStep("ClickPlayerInformationButton").Execute();
                var villageRows = (IEnumerable<ProfileVillageRow>)_stepProviderService.GetStep("GetVillageRows").Execute();
                if (villageRows.Count() == 1)
                {
                    var x = new OwnVillage { };
                }
                else
                {

                }
               
                throw new NotImplementedException();

                return ownPlayer;
            }
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        // TODO: Implement
        public Player GetPlayer(string playerName)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
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
            catch (BotCheckException bce)
            {
                _featureLoggingService.LogBotCheck(MethodBase.GetCurrentMethod().Name, bce.CurrentStep);
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = string.Empty;
                bool plemionaError = false;

                if ((bool)_stepProviderService.GetStep("IsErrorMessagePresent").Execute())
                {
                    plemionaError = true;
                    errorMessage = (string)_stepProviderService.GetStep("GetErrorMessage").Execute();
                    TryToReturnToVillageView();
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                    TryToReturnToVillageView();
                }

                throw new FeatureException(plemionaError, errorMessage);
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