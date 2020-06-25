﻿using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Plemiona.Core.Enums;
using Plemiona.Core.Models;
using Plemiona.Core.Models.Gui;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Steps.WebDriverBase;
using Plemiona.Core.Services.WebDriverProvider;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Plemiona.Core.Steps.Steps
{
    public class PlemionaSteps : IPlemionaSteps
    {
        private readonly IWebDriverProviderService _webDriverProviderService;
        private readonly IWebDriverBaseMethodsService _webDriverBaseMethodsService;
        private readonly IPlemionaMetadataProviderService _plemionaConfigProviderService;

        private RemoteWebDriver _remoteWebDriver;
        private INavigation _navigation;

        private readonly string _plemionaUrl = "https://www.plemiona.pl/";

        private readonly TimeSpan _timeoutForExpectedElements = TimeSpan.FromSeconds(5);
        private readonly TimeSpan _timeoutForChceckingElementsExistence = TimeSpan.FromSeconds(2);

        private PlemionaMetadata _plemionaMetadata;

        public PlemionaSteps(
            IWebDriverProviderService webDriverProviderService,
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IPlemionaMetadataProviderService plemionaConfigProviderService)
        {
            _webDriverProviderService = webDriverProviderService;
            _webDriverBaseMethodsService = webDriverBaseMethodsService;
            _plemionaConfigProviderService = plemionaConfigProviderService;
        }

        public void LoadPlemionaWebsite()
        {
            _remoteWebDriver = _webDriverProviderService.CreateWebDriver();
            _navigation = _remoteWebDriver.Navigate();

            _plemionaConfigProviderService.Initialize();
            _webDriverBaseMethodsService.Initialize();

            _navigation.GoToUrl(_plemionaUrl);
        }

        public void ClearVillageNameTextBox() => _webDriverBaseMethodsService.ClearBy(By.Name("name"));
        public void FillVillageNameTextBox(string villageName) => _webDriverBaseMethodsService.FillBy(By.Name("name"), villageName);
        public void ClickVillageNameChangeButton() => _webDriverBaseMethodsService.ClickBy(By.XPath("//input[@type='submit']"));

        public bool DidDailySignInGiftWindowPopUp() => _webDriverBaseMethodsService.ExistsBy(By.Id("popup_box_daily_bonus"));
        public void ClickDailySignInGiftReceiveButton()
        {
            var giftButtons = _remoteWebDriver.FindElementsByClassName("btn-default");

            foreach (var giftButton in giftButtons)
            {
                giftButton.Click();
            }
        }

        public bool DidEventWindowPopUp() => throw new NotImplementedException("Not enough concrete class used. Colidates with daily gift window."); //_webDriverBaseMethods.ElementExistsByClassName("popup_box_close");
        public void ClickEventWindowCloseButton() => throw new NotImplementedException("Not enough concrete class used. Colidates with daily gift window."); // _webDriverBaseMethods.ClickElementByClassName("popup_box_close");

        public void ClickVillageViewButton() => _webDriverBaseMethodsService.ClickBy(By.XPath($"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=overview']"));
        public void ClickKnightRecruitmentButton() => _webDriverBaseMethodsService.ClickBy(By.ClassName("knight_recruit_launch")); // btn_recruit w innym trybie
        public void ClearKnightNameTextBox() => _webDriverBaseMethodsService.ClearByAndCondition(ExpectedConditions.ElementExists(By.Id("knight_recruit_name")), _timeoutForExpectedElements);
        public void FillKnightNameTextBox(string knightName) => _webDriverBaseMethodsService.FillByAndCondition(ExpectedConditions.ElementExists(By.Id("knight_recruit_name")), _timeoutForExpectedElements, knightName);
        public void ClickKnightRecruitmentConfirmationButton() => _webDriverBaseMethodsService.ClickBy(By.Id("knight_recruit_confirm"));
        public bool CanSkipKnightRecruitment() => _webDriverBaseMethodsService.ExistsByAndCondition(ExpectedConditions.ElementExists(By.ClassName("knight_recruit_rush")), _timeoutForChceckingElementsExistence);
        public void ClickKnightRecruitmentSkipButton() => _webDriverBaseMethodsService.ClickBy(By.ClassName("knight_recruit_rush"));
        public void ClickKnightRecruitmentCancellationButton() => _webDriverBaseMethodsService.ClickBy(By.ClassName("knight_recruit_abort"));
        public void ClickKnightRevivalButton() => _webDriverBaseMethodsService.ClickBy(By.ClassName("knight_revive_launch"));
        public void ClickKnightRevivalConfirmationButton() => _webDriverBaseMethodsService.ClickBy(By.Id("knight_revive_confirm"));

        public void ClickBuildingPicture(BuildingTypes building)
        {
            string buildingXPath = null;

            switch (building)
            {
                case BuildingTypes.Townhall: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main']"; break;
                case BuildingTypes.Barracks: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=barracks']"; break;
                case BuildingTypes.Stable: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=stable']"; break;
                case BuildingTypes.Workshop: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=garage']"; break;
                case BuildingTypes.Palace: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=snob']"; break;
                case BuildingTypes.Forge: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=smith']"; break;
                case BuildingTypes.Yard: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=place']"; break;
                case BuildingTypes.Statue: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=statue']"; break;
                case BuildingTypes.Market: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=market']"; break;
                case BuildingTypes.Sawmill: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=wood']"; break;
                case BuildingTypes.Brickyard: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=stone']"; break;
                case BuildingTypes.Ironworks: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=iron']"; break;
                case BuildingTypes.Farm: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=farm']"; break;
                case BuildingTypes.Storage: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=storage']"; break;
                case BuildingTypes.Clipboard: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=hide']"; break;
                case BuildingTypes.Wall: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=wall']"; break;
                default: throw new NotImplementedException();
            }

            _webDriverBaseMethodsService.ClickBy(By.XPath(buildingXPath));
        }

        public void FillSpearmenCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("spear_0"), count.ToString());
        public void FillSwordmenCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("NULL"), count.ToString());
        public void FillAxemenCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("NULL"), count.ToString());
        public void FillBowmenCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("NULL"), count.ToString());
        public void ClickUnsaddledTroopsRecruitmentButton() => _webDriverBaseMethodsService.ClickBy(By.ClassName("btn-recruit"));

        public void FillScoutCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("NULL"), count.ToString());
        public void FillLightCavalaryCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("NULL"), count.ToString());
        public void FillHorseArchersCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("NULL"), count.ToString());
        public void FillHeavyCavalaryCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("NULL"), count.ToString());
        public void ClickSaddledTroopsRecruitmentButton() => _webDriverBaseMethodsService.ClickBy(By.ClassName("NULL"));

        public void FillRamsCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("NULL"), count.ToString());
        public void FillCatapultesCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("NULL"), count.ToString());
        public void ClickWarMachinesRecruitmentTroops() => _webDriverBaseMethodsService.ClickBy(By.ClassName("NULL"));

        public void FillYardSpearmenCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("unit_input_spear"), count.ToString());
        public void FillYardSwordmenCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("unit_input_sword"), count.ToString());
        public void FillYardAxemenCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("unit_input_axe"), count.ToString());
        public void FillYardBowmenCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("unit_input_archer"), count.ToString());
        public void FillYardScoutCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("unit_input_spy"), count.ToString());
        public void FillYardLightCavalaryCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("unit_input_light"), count.ToString());
        public void FillYardHorseArchersCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("unit_input_marcher"), count.ToString());
        public void FillYardHeavyCavalaryCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("unit_input_heavy"), count.ToString());
        public void FillYardRamsCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("unit_input_ram"), count.ToString());
        public void FillYardCatapultesCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("unit_input_catapult"), count.ToString());
        public void FillYardKnightsCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("unit_input_knight"), count.ToString());
        public void FillYardNobelmenCountTextBox(int count) => _webDriverBaseMethodsService.FillBy(By.Id("unit_input_snob"), count.ToString());
        public void FillYardCoordinatesTextBox(int coordinateX, int coordinateY) => _webDriverBaseMethodsService.FillBy(By.ClassName("target-input-field"), $"{coordinateX}|{coordinateY}");
        public void ClickSendAttackButton() => _webDriverBaseMethodsService.ClickBy(By.Id("target_attack"));
        public void ClickSendHelpButton() => _webDriverBaseMethodsService.ClickBy(By.Id("target_support"));
        public void ClickSendingTroopsConfirmationButton() => _webDriverBaseMethodsService.ClickBy(By.Id("troop_confirm_go"));

        public int GetSelfWoodCount() => Convert.ToInt32(_webDriverBaseMethodsService.GetTextBy(By.Id("wood")));
        public int GetSelfClayCount() => Convert.ToInt32(_webDriverBaseMethodsService.GetTextBy(By.Id("stone")));
        public int GetSelfIronCount() => Convert.ToInt32(_webDriverBaseMethodsService.GetTextBy(By.Id("iron")));

        public int GetBuildingLevel(BuildingTypes building)
        {
            string buildingXPath = null;

            switch (building)
            {
                case BuildingTypes.Townhall: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=main"; break;
                case BuildingTypes.Barracks: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=barracks"; break;
                case BuildingTypes.Stable: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=stable"; break;
                case BuildingTypes.Workshop: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=garage"; break;
                case BuildingTypes.Palace: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=snob"; break;
                case BuildingTypes.Forge: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=smith"; break;
                case BuildingTypes.Yard: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=place"; break;
                case BuildingTypes.Statue: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=statue"; break;
                case BuildingTypes.Market: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=market"; break;
                case BuildingTypes.Sawmill: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=wood"; break;
                case BuildingTypes.Brickyard: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=stone"; break;
                case BuildingTypes.Ironworks: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=iron"; break;
                case BuildingTypes.Farm: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=farm"; break;
                case BuildingTypes.Storage: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=storage"; break;
                case BuildingTypes.Clipboard: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=hide"; break;
                case BuildingTypes.Wall: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=wall"; break;
                default: throw new NotImplementedException();
            }

            int buildingLevel = GetBuildingLevel(buildingXPath);

            return buildingLevel;
        }

        public void ClickAddBuildingToBuildQueueButton(BuildingTypes building)
        {
            string addBuildingToBuildQueueButtonXPath = null;

            switch (building)
            {
                case BuildingTypes.Townhall: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=main&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Barracks: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=barracks&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Stable: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=stable&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Workshop: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=garage&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Palace: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=snob&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Forge: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=smith&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Yard: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=place&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Statue: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=statue&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Market: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=market&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Sawmill: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=wood&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Brickyard: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=stone&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Ironworks: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=iron&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Farm: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=farm&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Storage: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=storage&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Clipboard: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=hide&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Wall: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=wall&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                default: throw new NotImplementedException();
            }

            _webDriverBaseMethodsService.ClickBy(By.XPath(addBuildingToBuildQueueButtonXPath));
        }

        public void ClickWorldMapButton() => _webDriverBaseMethodsService.ClickBy(By.XPath($"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=map']"));

        public void ClickPlayerInformationButton() => _webDriverBaseMethodsService.ClickBy(By.XPath($"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=info_player']"));

        public string GetPlayerButtonTextFromProfileButtons() => _webDriverBaseMethodsService.GetTextBy(By.XPath($"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=info_player']"));
        public IEnumerable<ProfileVillageRow> GetVillageRows()
        {
            List<ProfileVillageRow> profileVillageRows = new List<ProfileVillageRow>();

            var villagesTable = _webDriverBaseMethodsService.GetBy(By.XPath("//table[@id='villages_list']/tbody"));

            var villageTableRows = villagesTable.FindElements(By.XPath("tr"));

            foreach (var villageTableRow in villageTableRows)
            {
                var profileVillageRow = new ProfileVillageRow();

                var tableRowCells = villageTableRow.FindElements(By.XPath("td"));
                var villageNameCell = tableRowCells[0];
                var villageLocationCell = tableRowCells[1];
                var villagePointsCell = tableRowCells[2];

                string villageName = villageNameCell.FindElement(By.XPath("table/tbody/tr/td/span/a")).Text;

                int villageLocationX = Convert.ToInt32(villageLocationCell.Text.Substring(0, 3));
                int villageLocationY = Convert.ToInt32(villageLocationCell.Text.Substring(4, 3));
                var villageLocation = new Point(villageLocationX, villageLocationY);

                int villagePoints = Convert.ToInt32(villagePointsCell.Text);

                profileVillageRow.Name = villageName;
                profileVillageRow.Location = villageLocation;
                profileVillageRow.Points = villagePoints;

                profileVillageRows.Add(profileVillageRow);
            }

            return profileVillageRows;
        }

        public void ClickSignOutFromWorldButton() => _webDriverBaseMethodsService.ClickBy(By.XPath($"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=&action=logout&h={_plemionaMetadata.CsrfToken}']"));
        public void ClickReturnToMainPageButton() => _webDriverBaseMethodsService.ClickBy(By.XPath("//div[@class='button small']"));

        private int GetBuildingLevel(string buildingHref)
        {
            IWebElement buildingElement = null;

            try
            {
                buildingElement = _remoteWebDriver.FindElementByXPath($"//td/a[@href='{buildingHref}']/parent::td/span");
            }
            catch (NoSuchElementException)
            {
                // Building was not found. Returning level 0.
                return 0;
            }

            string buildingLevelLabelText = buildingElement.Text;

            string buildingLevelLabelNumbersString = string.Join(string.Empty, buildingLevelLabelText.Where(c => char.IsNumber(c)));

            int buildingLevelLabelNumbers = 0;

            try
            {
                buildingLevelLabelNumbers = Convert.ToInt32(buildingLevelLabelNumbersString);
            }
            catch (FormatException)
            {
                // Building label contains "not built". Returning level 0.
                return 0;
            }

            return buildingLevelLabelNumbers;
        }

        public bool IsPlayerSignedIn()
        {
            throw new NotImplementedException();
        }

        public void ClickSignOutFromAccountButton()
        {
            throw new NotImplementedException();
        }

        public void FillUserTextBox(string username)
        {
            throw new NotImplementedException();
        }

        public void FillPasswordTextBox(string password)
        {
            throw new NotImplementedException();
        }

        public void ClickSignInButton()
        {
            throw new NotImplementedException();
        }

        public void ClickWorldButton(int worldNumber)
        {
            throw new NotImplementedException();
        }
    }
}