using Plemiona.Core.Enums;
using Plemiona.Core.Interfaces;
using Plemiona.Core.Models;
using Plemiona.Core.Steps.Steps;
using System;
using System.Collections.Generic;

namespace Plemiona.Core.Features
{
    public class PlemionaFeatures : IPlemionaFeatures
    {
        private readonly IPlemionaSteps _plemionaSteps;

        public PlemionaFeatures(IPlemionaSteps plemionaSteps)
        {
            _plemionaSteps = plemionaSteps;
        }

        public void SignIn(string username, string password, int worldNumber)
        {
            _plemionaSteps.LoadPlemionaWebsite();
            if (_plemionaSteps.IsPlayerSignedIn())
                _plemionaSteps.ClickSignOutFromAccountButton();
            _plemionaSteps.FillUserTextBox(username);
            _plemionaSteps.FillPasswordTextBox(password);
            _plemionaSteps.ClickSignInButton();
            _plemionaSteps.ClickWorldButton(worldNumber);
            //if (_plemionaSteps.DidEventWindowPopUp())
            //    _plemionaSteps.ClickEventWindowCloseButton();
            if (_plemionaSteps.DidDailySignInGiftWindowPopUp())
                _plemionaSteps.ClickDailySignInGiftReceiveButton();
        }

        public void SwitchToVillage(string villageName)
        {

        }

        public void RecruitTroops(Troops troops)
        {
            if (troops.AreUnsaddledTroopsPresent)
            {
                _plemionaSteps.ClickBuildingPicture(BuildingTypes.Barracks);
                _plemionaSteps.FillSpearmenCountTextBox(troops.Spearmen);
                _plemionaSteps.FillSwordmenCountTextBox(troops.Spearmen);
                _plemionaSteps.FillAxemenCountTextBox(troops.Spearmen);
                _plemionaSteps.FillBowmenCountTextBox(troops.Spearmen);
                _plemionaSteps.ClickUnsaddledTroopsRecruitmentButton();
            }

            if (troops.AreSaddledTroopsPresent)
            {
                _plemionaSteps.ClickVillageViewButton();
                _plemionaSteps.ClickBuildingPicture(BuildingTypes.Stable);
                _plemionaSteps.FillScoutCountTextBox(troops.Spearmen);
                _plemionaSteps.FillLightCavalaryCountTextBox(troops.Spearmen);
                _plemionaSteps.FillHorseArchersCountTextBox(troops.Spearmen);
                _plemionaSteps.FillHeavyCavalaryCountTextBox(troops.Spearmen);
                _plemionaSteps.ClickSaddledTroopsRecruitmentButton();
            }

            if (troops.AreWarMachinesTroopsPresent)
            {
                _plemionaSteps.ClickVillageViewButton();
                _plemionaSteps.ClickBuildingPicture(BuildingTypes.Workshop);
                _plemionaSteps.FillRamsCountTextBox(troops.Spearmen);
                _plemionaSteps.FillCatapultesCountTextBox(troops.Spearmen);
                _plemionaSteps.ClickWarMachinesRecruitmentTroops();
            }

            if (troops.Noblemen > 0)
            {
                _plemionaSteps.ClickBuildingPicture(BuildingTypes.Palace);
                // TODO - Monety? Nie monety?

                _plemionaSteps.ClickVillageViewButton();
            }

            _plemionaSteps.ClickVillageViewButton();
        }

        public void RecruitKnight(string knightName)
        {
            _plemionaSteps.ClickBuildingPicture(BuildingTypes.Statue);
            _plemionaSteps.ClickKnightRecruitmentButton();
            _plemionaSteps.ClearKnightNameTextBox();
            _plemionaSteps.FillKnightNameTextBox(knightName);
            _plemionaSteps.ClickKnightRecruitmentConfirmationButton();
            if (_plemionaSteps.CanSkipKnightRecruitment())
                _plemionaSteps.ClickKnightRecruitmentSkipButton();
            _plemionaSteps.ClickVillageViewButton();
        }

        public void ReviveKnight()
        {
            _plemionaSteps.ClickBuildingPicture(BuildingTypes.Statue);
            _plemionaSteps.ClickKnightRevivalButton();
            _plemionaSteps.ClickKnightRevivalConfirmationButton();
            _plemionaSteps.ClickVillageViewButton();
        }

        public void SendTroops(Troops troops, int coordinateX, int coordinateY, TroopsIntentions troopsIntentions)
        {
            _plemionaSteps.ClickBuildingPicture(BuildingTypes.Yard);

            _plemionaSteps.FillYardSpearmenCountTextBox(troops.Spearmen);
            _plemionaSteps.FillYardSwordmenCountTextBox(troops.Swordmen);
            _plemionaSteps.FillYardAxemenCountTextBox(troops.Axemen);
            _plemionaSteps.FillYardBowmenCountTextBox(troops.Bowmen);

            _plemionaSteps.FillYardScoutCountTextBox(troops.Scouts);
            _plemionaSteps.FillYardLightCavalaryCountTextBox(troops.LightCavalary);
            _plemionaSteps.FillYardHorseArchersCountTextBox(troops.HorseArchers);
            _plemionaSteps.FillHeavyCavalaryCountTextBox(troops.HeavyCavalary);

            _plemionaSteps.FillYardRamsCountTextBox(troops.Rams);
            _plemionaSteps.FillYardCatapultesCountTextBox(troops.Catapultes);

            _plemionaSteps.FillYardKnightsCountTextBox(troops.Knights);
            _plemionaSteps.FillYardNobelmenCountTextBox(troops.Noblemen);

            _plemionaSteps.FillAttackCoordinatesTextBox(coordinateX, coordinateY);

            if (troopsIntentions == TroopsIntentions.Attack)
                _plemionaSteps.ClickSendAttackButton();
            else
                _plemionaSteps.ClickSendHelpButton();

            _plemionaSteps.ClickVillageViewButton();
        }

        public Resources GetCurrentVillageResources()
        {
            var resources = new Resources
            {
                Wood = _plemionaSteps.GetSelfWoodCount(),
                Clay = _plemionaSteps.GetSelfClayCount(),
                Iron = _plemionaSteps.GetSelfIronCount()
            };

            return resources;
        }

        public Buildings GetCurrentVillageBuildings()
        {
            _plemionaSteps.ClickBuildingPicture(BuildingTypes.Townhall);

            var buildings = new Buildings
            {
                Townhall = _plemionaSteps.GetBuildingLevel(BuildingTypes.Townhall),
                Barracks = _plemionaSteps.GetBuildingLevel(BuildingTypes.Barracks),
                Stable = _plemionaSteps.GetBuildingLevel(BuildingTypes.Stable),
                Workshop = _plemionaSteps.GetBuildingLevel(BuildingTypes.Workshop),
                Palace = _plemionaSteps.GetBuildingLevel(BuildingTypes.Palace),
                Forge = _plemionaSteps.GetBuildingLevel(BuildingTypes.Forge),
                Yard = _plemionaSteps.GetBuildingLevel(BuildingTypes.Yard),
                Statue = _plemionaSteps.GetBuildingLevel(BuildingTypes.Statue),
                Market = _plemionaSteps.GetBuildingLevel(BuildingTypes.Market),
                Sawmill = _plemionaSteps.GetBuildingLevel(BuildingTypes.Sawmill),
                Brickyard = _plemionaSteps.GetBuildingLevel(BuildingTypes.Brickyard),
                Ironworks = _plemionaSteps.GetBuildingLevel(BuildingTypes.Ironworks),
                Farm = _plemionaSteps.GetBuildingLevel(BuildingTypes.Farm),
                Storage = _plemionaSteps.GetBuildingLevel(BuildingTypes.Storage),
                Clipboard = _plemionaSteps.GetBuildingLevel(BuildingTypes.Clipboard),
                Wall = _plemionaSteps.GetBuildingLevel(BuildingTypes.Wall)
            };

            _plemionaSteps.ClickVillageViewButton();

            return buildings;
        }

        public void ChangeVillageName(string villageName)
        {
            _plemionaSteps.ClickBuildingPicture(BuildingTypes.Townhall);
            _plemionaSteps.ClearVillageNameTextBox();
            _plemionaSteps.FillVillageNameTextBox(villageName);
            _plemionaSteps.ClickVillageNameChangeButton();
            _plemionaSteps.ClickVillageViewButton();
        }

        public IEnumerable<Village> GetNerbaryVillages(int radiusFields)
        {
            _plemionaSteps.ClickBuildingPicture(BuildingTypes.Yard);


            throw new NotImplementedException();
        }

        public void AddBuildingToQueue(BuildingTypes building)
        {
            _plemionaSteps.ClickBuildingPicture(BuildingTypes.Townhall);
            _plemionaSteps.ClickAddBuildingToBuildQueueButton(building);
            _plemionaSteps.ClickVillageViewButton();
        }

        public Player GetSelfInformation()
        {
            var player = new Player();

            _plemionaSteps.ClickPlayerInformationButton();
            string playerName = _plemionaSteps.GetPlayerButtonTextFromProfileButtons();
            var villageRows = _plemionaSteps.GetVillageRows();

            return player;
        }

        public void SignOut()
        {
            _plemionaSteps.ClickSignOutFromWorldButton();
            _plemionaSteps.ClickReturnToMainPageButton();
            _plemionaSteps.ClickSignOutFromAccountButton();
        }
    }
}