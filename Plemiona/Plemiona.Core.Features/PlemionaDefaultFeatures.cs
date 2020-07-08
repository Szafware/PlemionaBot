using Plemiona.Core.Enums;
using Plemiona.Core.Exceptions;
using Plemiona.Core.Interfaces.Features;
using Plemiona.Core.Models;
using Plemiona.Core.Models.Features;
using Plemiona.Core.Models.Gui;
using Plemiona.Core.Models.Steps;
using Plemiona.Core.Services.FeatureLogging;
using Plemiona.Core.Steps.Services.StepExecution;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;

namespace Plemiona.Core.Features
{
    public class PlemionaDefaultFeatures : IPlemionaFeatures
    {
        protected readonly IStepExecutionService _stepExecutionService;
        protected readonly IFeatureLoggingService _featureLoggingService;

        public PlemionaDefaultFeatures(
            IStepExecutionService stepExecutionService,
            IFeatureLoggingService featureLoggingService
            )
        {
            _stepExecutionService = stepExecutionService;
            _featureLoggingService = featureLoggingService;
        }

        public void SignIn(string username, string password, int worldNumber)
        {
            try
            {
                _stepExecutionService.Execute("LoadPlemionaWebsite");
                if (_stepExecutionService.Execute<bool>("IsPlayerSignedIn"))
                    _stepExecutionService.Execute("ClickSignOutFromAccountButton");
                _stepExecutionService.Execute("FillUsernameTextBox", "Dziaczakra");
                _stepExecutionService.Execute("FillPasswordTextBox", password);
                _stepExecutionService.Execute("ClickSignInButton");
                _stepExecutionService.Execute("ClickWorldButton", worldNumber);
                if (_stepExecutionService.Execute<bool>("IsDailySignInGiftWindowPresent"))
                    _stepExecutionService.Execute("ClickDailySignInGiftReceiveButton");
                _stepExecutionService.Execute("ClickHideChatButton");
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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        public void RecruitKnight(string knightName)
        {
            try
            {
                _stepExecutionService.Execute("ClickBuildingPicture", BuildingTypes.Statue);
                _stepExecutionService.Execute("ClickKnightRecruitmentButton");
                _stepExecutionService.Execute("ClearKnightNameTextBox");
                _stepExecutionService.Execute("FillKnightNameTextBox", knightName);
                _stepExecutionService.Execute("ClickKnightRecruitmentConfirmationButton");
                if (_stepExecutionService.Execute<bool>("CanSkipKnightRecruitment"))
                    _stepExecutionService.Execute("ClickKnightRecruitmentSkipButton");
                _stepExecutionService.Execute("ClickVillageViewButton");
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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        public void ReviveKnight()
        {
            try
            {
                _stepExecutionService.Execute("ClickBuildingPicture", BuildingTypes.Statue);
                _stepExecutionService.Execute("ClickKnightRevivalButton");
                _stepExecutionService.Execute("ClickKnightRevivalConfirmationButton");
                _stepExecutionService.Execute("ClickVillageViewButton");
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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        public void RecruitTroops(Troops troops)
        {
            try
            {
                if (troops.AreUnsaddledTroopsPresent)
                {
                    _stepExecutionService.Execute("ClickBuildingPicture", BuildingTypes.Barracks);
                    if (troops.Spearmen > 0)
                        _stepExecutionService.Execute("FillRecruitmentTroopsCountTextBox", TroopsRecruitment.Create(TroopTypes.Spearman, troops.Spearmen));
                    if (troops.Swordmen > 0)
                        _stepExecutionService.Execute("FillRecruitmentTroopsCountTextBox", TroopsRecruitment.Create(TroopTypes.Swordman, troops.Swordmen));
                    if (troops.Axemen > 0)
                        _stepExecutionService.Execute("FillRecruitmentTroopsCountTextBox", TroopsRecruitment.Create(TroopTypes.Axeman, troops.Axemen));
                    if (troops.Bowmen > 0)
                        _stepExecutionService.Execute("FillRecruitmentTroopsCountTextBox", TroopsRecruitment.Create(TroopTypes.Bowman, troops.Bowmen));
                    _stepExecutionService.Execute("ClickUnsaddledTroopsRecruitmentButton");
                }

                if (troops.AreSaddledTroopsPresent)
                {
                    _stepExecutionService.Execute("ClickVillageViewButton");
                    _stepExecutionService.Execute("ClickBuildingPicture", BuildingTypes.Stable);
                    if (troops.Scouts > 0)
                        _stepExecutionService.Execute("FillRecruitmentTroopsCountTextBox", TroopsRecruitment.Create(TroopTypes.Scout, troops.Scouts));
                    if (troops.LightCavalary > 0)
                        _stepExecutionService.Execute("FillRecruitmentTroopsCountTextBox", TroopsRecruitment.Create(TroopTypes.LightCavalryman, troops.LightCavalary));
                    if (troops.HorseArchers > 0)
                        _stepExecutionService.Execute("FillRecruitmentTroopsCountTextBox", TroopsRecruitment.Create(TroopTypes.HorseArcher, troops.HorseArchers));
                    if (troops.HeavyCavalary > 0)
                        _stepExecutionService.Execute("FillRecruitmentTroopsCountTextBox", TroopsRecruitment.Create(TroopTypes.HeavyCavalryman, troops.HeavyCavalary));
                    _stepExecutionService.Execute("ClickSaddledTroopsRecruitmentButton");
                }

                if (troops.AreWarMachinesTroopsPresent)
                {
                    _stepExecutionService.Execute("ClickVillageViewButton");
                    _stepExecutionService.Execute("ClickBuildingPicture", BuildingTypes.Workshop);
                    if (troops.Rams > 0)
                        _stepExecutionService.Execute("FillRecruitmentTroopsCountTextBox", TroopsRecruitment.Create(TroopTypes.Ram, troops.Rams));
                    if (troops.Catapultes > 0)
                        _stepExecutionService.Execute("FillRecruitmentTroopsCountTextBox", TroopsRecruitment.Create(TroopTypes.Catapulte, troops.Catapultes));
                    _stepExecutionService.Execute("ClickWarMachinesRecruitmentButton");
                }

                if (troops.Noblemen > 0)
                {
                    _stepExecutionService.Execute("ClickVillageViewButton");
                    _stepExecutionService.Execute("ClickBuildingPicture", BuildingTypes.Palace);
                    _stepExecutionService.Execute("FillRecruitmentTroopsCountTextBox", TroopsRecruitment.Create(TroopTypes.Nobleman, troops.Noblemen));
                    _stepExecutionService.Execute("ClickNoblemenRecruitmentButton");
                }

                _stepExecutionService.Execute("ClickVillageViewButton");
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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        public Troops GetTroops()
        {
            try
            {
                var troops = new Troops
                {
                    Spearmen = _stepExecutionService.Execute<int>("GetOwnSpearmen"),
                    Swordmen = _stepExecutionService.Execute<int>("GetOwnSwordmen"),
                    Axemen = _stepExecutionService.Execute<int>("GetOwnAxemen"),
                    Bowmen = _stepExecutionService.Execute<int>("GetOwnBowmen"),
                    Scouts = _stepExecutionService.Execute<int>("GetOwnScouts"),
                    LightCavalary = _stepExecutionService.Execute<int>("GetOwnLightCavalary"),
                    HorseArchers = _stepExecutionService.Execute<int>("GetOwnHorseArchers"),
                    HeavyCavalary = _stepExecutionService.Execute<int>("GetOwnHeavyCavalary"),
                    Rams = _stepExecutionService.Execute<int>("GetOwnRams"),
                    Catapultes = _stepExecutionService.Execute<int>("GetOwnCatapultes"),
                    Knights = _stepExecutionService.Execute<int>("GetOwnKnights"),
                    Noblemen = _stepExecutionService.Execute<int>("GetOwnNoblemen"),
                    Peasants = _stepExecutionService.Execute<int>("GetOwnPeasants"),
                };

                return troops;
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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        public void SendTroops(Troops troops, int coordinateX, int coordinateY, TroopsIntentions troopsIntentions, SendingTroopsInfo sendingTroopsInfo = null)
        {
            try
            {
                if ((sendingTroopsInfo == null) || (sendingTroopsInfo.CurrentOrderNumber == 1))
                    _stepExecutionService.Execute("ClickBuildingPicture", BuildingTypes.Yard);

                if (troops.Spearmen > 0)
                    _stepExecutionService.Execute("FillYardSpearmenCountTextBox", troops.Spearmen);
                if (troops.Swordmen > 0)
                    _stepExecutionService.Execute("FillYardSwordmenCountTextBox", troops.Swordmen);
                if (troops.Axemen > 0)
                    _stepExecutionService.Execute("FillYardAxemenCountTextBox", troops.Axemen);
                if (troops.Bowmen > 0)
                    _stepExecutionService.Execute("FillYardBowmenCountTextBox", troops.Bowmen);

                if (troops.Scouts > 0)
                    _stepExecutionService.Execute("FillYardScoutCountTextBox", troops.Scouts);
                if (troops.LightCavalary > 0)
                    _stepExecutionService.Execute("FillYardLightCavalaryCountTextBox", troops.LightCavalary);
                if (troops.HorseArchers > 0)
                    _stepExecutionService.Execute("FillYardHorseArchersCountTextBox", troops.HorseArchers);
                if (troops.HeavyCavalary > 0)
                    _stepExecutionService.Execute("FillYardHeavyCavalaryCountTextBox", troops.HeavyCavalary);

                if (troops.Rams > 0)
                    _stepExecutionService.Execute("FillYardRamsCountTextBox", troops.Rams);
                if (troops.Catapultes > 0)
                    _stepExecutionService.Execute("FillYardCatapultesCountTextBox", troops.Catapultes);

                if (troops.Knights > 0)
                    _stepExecutionService.Execute("FillYardKnightsCountTextBox", troops.Knights);
                if (troops.Noblemen > 0)
                    _stepExecutionService.Execute("FillYardNobelmenCountTextBox", troops.Noblemen);

                _stepExecutionService.Execute("FillYardVillageCoordinatesTextBox", new Point(coordinateX, coordinateY));

                if (troopsIntentions == TroopsIntentions.Attack)
                    _stepExecutionService.Execute("ClickSendAttackButton");
                else
                    _stepExecutionService.Execute("ClickSendHelpButton");

                _stepExecutionService.Execute("ClickSendTroopsConfirmationButton");

                if ((sendingTroopsInfo == null) || sendingTroopsInfo.IsLastOrderInSequence)
                    _stepExecutionService.Execute("ClickVillageViewButton");
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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        public Resources GetResources()
        {
            try
            {
                var resources = new Resources
                {
                    Wood = _stepExecutionService.Execute<int>("GetWood"),
                    Clay = _stepExecutionService.Execute<int>("GetClay"),
                    Iron = _stepExecutionService.Execute<int>("GetIron"),
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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        public Buildings GetBuildings()
        {
            try
            {
                _stepExecutionService.Execute("ClickBuildingPicture", BuildingTypes.Townhall);

                var buildings = new Buildings
                {
                    Townhall = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Townhall),
                    Barracks = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Barracks),
                    Stable = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Stable),
                    Workshop = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Workshop),
                    Palace = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Palace),
                    Forge = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Forge),
                    Yard = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Yard),
                    Statue = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Statue),
                    Market = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Market),
                    Sawmill = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Sawmill),
                    Brickyard = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Brickyard),
                    Ironworks = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Ironworks),
                    Farm = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Farm),
                    Storage = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Storage),
                    Clipboard = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Clipboard),
                    Wall = _stepExecutionService.Execute<int>("GetBuildingLevel", BuildingTypes.Wall)
                };

                _stepExecutionService.Execute("ClickVillageViewButton");

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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        public void ChangeVillageName(string villageName)
        {
            try
            {
                _stepExecutionService.Execute("ClickBuildingPicture", BuildingTypes.Townhall);
                _stepExecutionService.Execute("ClearVillageNameTextBox");
                _stepExecutionService.Execute("FillVillageNameTextBox", villageName);
                _stepExecutionService.Execute("ClickVillageNameChangeButton");
                _stepExecutionService.Execute("ClickVillageViewButton");
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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        // TODO: Implementation
        public IEnumerable<Village> GetNerbaryVillages(int radiusFields)
        {
            try
            {
                _stepExecutionService.Execute("ClickBuildingPicture", BuildingTypes.Yard);

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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

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

                _stepExecutionService.Execute("ClickMapButton");
                _stepExecutionService.Execute("FillVillageCoordinateXMapCenter", coordinateX);
                _stepExecutionService.Execute("FillVillageCoordinateYMapCenter", coordinateY);
                _stepExecutionService.Execute("ClickCenterVillageInMapButton");
                _stepExecutionService.Execute("MoveMouseToMapCenter");
                _stepExecutionService.Execute("ClickMap");
                _stepExecutionService.Execute("ClickVillageInformationButton");

                village.Name = _stepExecutionService.Execute<string>("GetVillageName");
                village.Points = _stepExecutionService.Execute<int>("GetVillagePoints");
                village.IsNomadOrBarbarian = _stepExecutionService.Execute<bool>("IsNomadOrBarbarianVillage");

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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        public void AddBuildingToQueue(BuildingTypes building)
        {
            try
            {
                _stepExecutionService.Execute("ClickBuildingPicture", BuildingTypes.Townhall);
                _stepExecutionService.Execute("ClickAddBuildingToBuildQueueButton", building);
                _stepExecutionService.Execute("ClickVillageViewButton");
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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        // TODO: Implementation
        public OwnPlayer GetOwnPlayer()
        {
            try
            {
                var ownPlayer = new OwnPlayer { Name = _stepExecutionService.Execute<string>("GetPlayerName") };
                _stepExecutionService.Execute("ClickPlayerInformationButton");
                var villageRows = (IEnumerable<ProfileVillageRow>)_stepExecutionService.Execute("GetVillageRows");
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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        public void SignOut()
        {
            try
            {
                _stepExecutionService.Execute("ClickSignOutFromWorldButton");
                _stepExecutionService.Execute("ClickReturnToMainPageButton");
                _stepExecutionService.Execute("ClickSignOutFromAccountButton");
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

                if (_stepExecutionService.Execute<bool>("IsErrorMessagePresent"))
                {
                    plemionaError = true;
                    errorMessage = _stepExecutionService.Execute<string>("GetErrorMessage");
                }
                else
                {
                    errorMessage = e.Message;
                    _featureLoggingService.LogException(e, MethodBase.GetCurrentMethod().Name);
                }

                TryToReturnToVillageView();

                throw new FeatureException(plemionaError, errorMessage);
            }
        }

        private void TryToReturnToVillageView()
        {
            try
            {
                _stepExecutionService.Execute("ClickVillageViewButton");
            }
            catch
            {
            }
        }
    }
}