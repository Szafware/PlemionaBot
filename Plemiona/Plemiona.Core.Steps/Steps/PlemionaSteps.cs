using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Plemiona.Core.Enums;
using Plemiona.Core.Steps.Models;
using Plemiona.Core.Steps.Models.Gui;
using Plemiona.Core.Steps.Services.PlemionaConfigProvider;
using Plemiona.Core.Steps.WebDriverBase;
using Plemiona.Core.WebDriver;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Plemiona.Core.Steps.Steps
{
    public class PlemionaSteps : IPlemionaSteps
    {
        private readonly IWebDriverProvider _webDriverProvider;
        private readonly IWebDriverBaseMethodsService _webDriverBaseMethodsService;
        private readonly IPlemionaConfigProviderService _plemionaConfigProviderService;
        
        private readonly RemoteWebDriver _remoteWebDriver;
        private readonly INavigation _navigation;

        private readonly string _plemionaUrl = "https://www.plemiona.pl/";

        private readonly TimeSpan _timeoutForExpectedElements = TimeSpan.FromSeconds(5);
        private readonly TimeSpan _timeoutForChceckingElementsExistence = TimeSpan.FromSeconds(2);

        private PlemionaConfig _plemionaConfig;

        public PlemionaSteps(
            IWebDriverProvider webDriverProvider,
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IPlemionaConfigProviderService plemionaConfigProviderService)
        {
            _webDriverProvider = webDriverProvider;
            _webDriverBaseMethodsService = webDriverBaseMethodsService;
            _plemionaConfigProviderService = plemionaConfigProviderService;

            _remoteWebDriver = _webDriverProvider.CreateWebDriver();

            _navigation = _remoteWebDriver.Navigate();
        }

        public void LoadPlemionaWebsite()
        {
            _webDriverBaseMethodsService.ExceptionHandler(() =>
            {
                _navigation.GoToUrl(_plemionaUrl);
            });
        }

        public bool IsPlayerSignedIn() => _webDriverBaseMethodsService.ExistsBy(By.XPath("//*[@href='/page/logout']"));
        public void ClickSignOutFromAccountButton() => _webDriverBaseMethodsService.ExistsBy(By.XPath("//*[@href='/page/logout']"));
        public void FillUserTextBox(string username) => _webDriverBaseMethodsService.FillBy(By.Id("user"), username);
        public void FillPasswordTextBox(string password) => _webDriverBaseMethodsService.FillBy(By.Id("password"), password);
        public void ClickSignInButton() => _webDriverBaseMethodsService.ClickBy(By.ClassName("btn-login"));
        public void ClickWorldButton(int worldNumber)
        {
            _webDriverBaseMethodsService.ClickByAndCondition(ExpectedConditions.ElementExists(By.XPath($"//span[contains(text(),'{worldNumber}')]")), _timeoutForExpectedElements);

            var plemionaConfig = _webDriverBaseMethodsService.ExceptionHandler(() => _plemionaConfigProviderService.Create());

            _plemionaConfig = plemionaConfig;
        }

        public void ClearVillageNameTextBox() => _webDriverBaseMethodsService.ClearBy(By.Name("name"));
        public void FillVillageNameTextBox(string villageName) => _webDriverBaseMethodsService.FillBy(By.Name("name"), villageName);
        public void ClickVillageNameChangeButton() => _webDriverBaseMethodsService.ClickBy(By.XPath("//input[@type='submit']"));

        public bool DidDailySignInGiftWindowPopUp() => _webDriverBaseMethodsService.ExistsBy(By.Id("popup_box_daily_bonus"));
        public void ClickDailySignInGiftReceiveButton()
        {
            _webDriverBaseMethodsService.ExceptionHandler(() =>
            {
                var giftButtons = _remoteWebDriver.FindElementsByClassName("btn-default");

                foreach (var giftButton in giftButtons)
                {
                    giftButton.Click();
                }
            });
        }

        public bool DidEventWindowPopUp() => throw new NotImplementedException("Not enough concrete class used. Colidates with daily gift window."); //_webDriverBaseMethods.ElementExistsByClassName("popup_box_close");
        public void ClickEventWindowCloseButton() => throw new NotImplementedException("Not enough concrete class used. Colidates with daily gift window."); // _webDriverBaseMethods.ClickElementByClassName("popup_box_close");

        public void ClickVillageViewButton() => _webDriverBaseMethodsService.ClickBy(By.XPath($"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=overview']"));
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
            string buildingXPath = building switch
            {
                BuildingTypes.Townhall => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main']",
                BuildingTypes.Barracks => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=barracks']",
                BuildingTypes.Stable => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=stable']",
                BuildingTypes.Workshop => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=garage']",
                BuildingTypes.Palace => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=snob']",
                BuildingTypes.Forge => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=smith']",
                BuildingTypes.Yard => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=place']",
                BuildingTypes.Statue => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=statue']",
                BuildingTypes.Market => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=market']",
                BuildingTypes.Sawmill => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=wood']",
                BuildingTypes.Brickyard => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=stone']",
                BuildingTypes.Ironworks => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=iron']",
                BuildingTypes.Farm => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=farm']",
                BuildingTypes.Storage => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=storage']",
                BuildingTypes.Clipboard => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=hide']",
                BuildingTypes.Wall => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=wall']",
                _ => throw new NotImplementedException()
            };

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
        public void FillAttackCoordinatesTextBox(int coordinateX, int coordinateY) => _webDriverBaseMethodsService.FillBy(By.ClassName("target-input-field"), $"{coordinateX}|{coordinateY}");
        public void ClickSendAttackButton() => _webDriverBaseMethodsService.ClickBy(By.Id("target_attack"));
        public void ClickSendHelpButton() => _webDriverBaseMethodsService.ClickBy(By.Id("target_support"));

        public int GetSelfWoodCount() => _webDriverBaseMethodsService.ExceptionHandler(() => Convert.ToInt32(_webDriverBaseMethodsService.GetTextBy(By.Id("wood"))));
        public int GetSelfClayCount() => _webDriverBaseMethodsService.ExceptionHandler(() => Convert.ToInt32(_webDriverBaseMethodsService.GetTextBy(By.Id("stone"))));
        public int GetSelfIronCount() => _webDriverBaseMethodsService.ExceptionHandler(() => Convert.ToInt32(_webDriverBaseMethodsService.GetTextBy(By.Id("iron"))));

        public int GetBuildingLevel(BuildingTypes building)
        {
            int buildingLevel = _webDriverBaseMethodsService.ExceptionHandler(() =>
            {
                string buildingXPath = building switch
                {
                    BuildingTypes.Townhall => $"/game.php?village={_plemionaConfig.VillageId}&screen=main",
                    BuildingTypes.Barracks => $"/game.php?village={_plemionaConfig.VillageId}&screen=barracks",
                      BuildingTypes.Stable => $"/game.php?village={_plemionaConfig.VillageId}&screen=stable",
                    BuildingTypes.Workshop => $"/game.php?village={_plemionaConfig.VillageId}&screen=garage",
                      BuildingTypes.Palace => $"/game.php?village={_plemionaConfig.VillageId}&screen=snob",
                       BuildingTypes.Forge => $"/game.php?village={_plemionaConfig.VillageId}&screen=smith",
                        BuildingTypes.Yard => $"/game.php?village={_plemionaConfig.VillageId}&screen=place",
                      BuildingTypes.Statue => $"/game.php?village={_plemionaConfig.VillageId}&screen=statue",
                      BuildingTypes.Market => $"/game.php?village={_plemionaConfig.VillageId}&screen=market",
                     BuildingTypes.Sawmill => $"/game.php?village={_plemionaConfig.VillageId}&screen=wood",
                   BuildingTypes.Brickyard => $"/game.php?village={_plemionaConfig.VillageId}&screen=stone",
                   BuildingTypes.Ironworks => $"/game.php?village={_plemionaConfig.VillageId}&screen=iron",
                        BuildingTypes.Farm => $"/game.php?village={_plemionaConfig.VillageId}&screen=farm",
                     BuildingTypes.Storage => $"/game.php?village={_plemionaConfig.VillageId}&screen=storage",
                   BuildingTypes.Clipboard => $"/game.php?village={_plemionaConfig.VillageId}&screen=hide",
                        BuildingTypes.Wall => $"/game.php?village={_plemionaConfig.VillageId}&screen=wall",
                    _ => throw new NotImplementedException()
                };

                int buildingLevel = GetBuildingLevel(buildingXPath);

                return buildingLevel;
            });

            return buildingLevel;
        }

        public void ClickAddBuildingToBuildQueueButton(BuildingTypes building)
        {
            _webDriverBaseMethodsService.ExceptionHandler(() =>
            {
                string addBuildingToBuildQueueButtonXPath = building switch
                {
                    BuildingTypes.Townhall => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=main&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Barracks => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=barracks&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Stable => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=stable&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Workshop => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=garage&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Palace => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=snob&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Forge => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=smith&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Yard => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=place&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Statue => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=statue&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Market => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=market&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Sawmill => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=wood&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Brickyard => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=stone&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Ironworks => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=iron&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Farm => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=farm&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Storage => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=storage&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Clipboard => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=hide&type=main&h={_plemionaConfig.CsrfToken}']",
                    BuildingTypes.Wall => $"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=main&action=upgrade_building&id=wall&type=main&h={_plemionaConfig.CsrfToken}']",
                    _ => throw new NotImplementedException()
                };

                _webDriverBaseMethodsService.ClickBy(By.XPath(addBuildingToBuildQueueButtonXPath));
            });
        }

        public void ClickWorldMapButton() => _webDriverBaseMethodsService.ClickBy(By.XPath($"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=map']"));

        public void ClickPlayerInformationButton() => _webDriverBaseMethodsService.ClickBy(By.XPath($"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=info_player']"));

        public string GetPlayerButtonTextFromProfileButtons() => _webDriverBaseMethodsService.GetTextBy(By.XPath($"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=info_player']"));
        public IEnumerable<ProfileVillageRow> GetVillageRows()
        {
            var villageRows = _webDriverBaseMethodsService.ExceptionHandler(() =>
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
            });

            return villageRows;
        }

        public void ClickSignOutFromWorldButton() => _webDriverBaseMethodsService.ClickBy(By.XPath($"//*[@href='/game.php?village={_plemionaConfig.VillageId}&screen=&action=logout&h={_plemionaConfig.CsrfToken}']"));
        public void ClickReturnToMainPageButton() => _webDriverBaseMethodsService.ClickBy(By.XPath("//div[@class='button small']"));

        private int GetBuildingLevel(string buildingHref)
        {
            int buildingLevel = _webDriverBaseMethodsService.ExceptionHandler(() =>
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
            });

            return buildingLevel;
        }
    }
}