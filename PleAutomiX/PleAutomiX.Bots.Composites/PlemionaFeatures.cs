using PleAutomiX.Bots.Core.Enums;
using PleAutomiX.Bots.Core.Models;
using PleAutomiX.Bots.Steps.Steps;
using System;
using System.Collections.Generic;

namespace PleAutomiX.Bots.Features
{
    public class PlemionaFeatures : IPlemionaFeatures
    {
        private readonly IPlemionaSteps _plemionaSteps;

        public PlemionaFeatures(IPlemionaSteps plemionaSpecificSteps)
        {
            _plemionaSteps = plemionaSpecificSteps;
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
                _plemionaSteps.ClickBarracksPicture();
                _plemionaSteps.FillSpearmenCountTextBox(troops.Spearmen);
                _plemionaSteps.FillSwordmenCountTextBox(troops.Spearmen);
                _plemionaSteps.FillAxemenCountTextBox(troops.Spearmen);
                _plemionaSteps.FillBowmenCountTextBox(troops.Spearmen);
                _plemionaSteps.ClickUnsaddledTroopsRecruitmentButton();
            }

            if (troops.AreSaddledTroopsPresent)
            {
                _plemionaSteps.ClickVillageViewButton();
                _plemionaSteps.ClickStablePicture();
                _plemionaSteps.FillScoutCountTextBox(troops.Spearmen);
                _plemionaSteps.FillLightCavalaryCountTextBox(troops.Spearmen);
                _plemionaSteps.FillHorseArchersCountTextBox(troops.Spearmen);
                _plemionaSteps.FillHeavyCavalaryCountTextBox(troops.Spearmen);
                _plemionaSteps.ClickSaddledTroopsRecruitmentButton();
            }

            if (troops.AreWarMachinesTroopsPresent)
            {
                _plemionaSteps.ClickVillageViewButton();
                _plemionaSteps.ClickWorkshopPicture();
                _plemionaSteps.FillRamsCountTextBox(troops.Spearmen);
                _plemionaSteps.FillCatapultesCountTextBox(troops.Spearmen);
                _plemionaSteps.ClickWarMachinesRecruitmentTroops();
            }

            if (troops.Noblemen > 0)
            {
                _plemionaSteps.ClickPalacePicture();
                // TODO - Monety? Nie monety?

                _plemionaSteps.ClickVillageViewButton();
            }

            _plemionaSteps.ClickVillageViewButton();
        }

        public void RecruitKnight(string knightName)
        {
            _plemionaSteps.ClickStatuePicture();
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
            _plemionaSteps.ClickStatuePicture();
            _plemionaSteps.ClickKnightRevivalButton();
            _plemionaSteps.ClickKnightRevivalConfirmationButton();
            _plemionaSteps.ClickVillageViewButton();
        }

        public void SendTroops(Troops troops, int coordinateX, int coordinateY, TroopsIntentions troopsIntentions)
        {
            _plemionaSteps.ClickYardPicture();

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
            _plemionaSteps.ClickTownhallPicture();

            var buildings = new Buildings
            {
                Townhall = _plemionaSteps.GetTownhallLevel(),
                Barracks = _plemionaSteps.GetBarracksLevel(),
                Stable = _plemionaSteps.GetStableLevel(),
                Workshop = _plemionaSteps.GetWorkshopLevel(),
                Palace = _plemionaSteps.GetPalaceLevel(),
                Forge = _plemionaSteps.GetForgeLevel(),
                Yard = _plemionaSteps.GetYardLevel(),
                Market = _plemionaSteps.GetMarketLevel(),
                Sawmill = _plemionaSteps.GetSawmillLevel(),
                Brickyard = _plemionaSteps.GetBrickyardLevel(),
                Ironworks = _plemionaSteps.GetIronworksLevel(),
                Farm = _plemionaSteps.GetFarmLevel(),
                Storage = _plemionaSteps.GetStorageLevel(),
                Clipboard = _plemionaSteps.GetClipboardLevel(),
                Wall = _plemionaSteps.GetWallLevel()
            };

            _plemionaSteps.ClickVillageViewButton();

            return buildings;
        }

        public Player GetSelfInformation()
        {
            var player = new Player();

            _plemionaSteps.ClickPlayerInformationButton();
            string playerName = _plemionaSteps.GetPlayerButtonTextFromProfileButtons();
            var villageRows = _plemionaSteps.GetVillageRows();

            return player;
        }

        public IEnumerable<Village> GetNerbaryVillages(int radiusFields)
        {
            _plemionaSteps.ClickYardPicture();


            throw new NotImplementedException();
        }

        public void ChangeVillageName(string villageName)
        {
            _plemionaSteps.ClickTownhallPicture();
            _plemionaSteps.ClearVillageNameTextBox();
            _plemionaSteps.FillVillageNameTextBox(villageName);
            _plemionaSteps.ClickVillageNameChangeButton();
            _plemionaSteps.ClickVillageViewButton();
        }

        public void SignOut()
        {
            _plemionaSteps.ClickSignOutFromWorldButton();
            _plemionaSteps.ClickReturnToMainPageButton();
            _plemionaSteps.ClickSignOutFromAccountButton();
        }
    }
}