using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using PleAutomiX.Bots.Steps.WebDriverBase;
using PleAutomiX.Bots.WebDriver;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace PleAutomiX.Bots.Steps.Steps
{
    public class PlemionaSteps : IPlemionaSteps
    {
        private readonly IWebDriverProvider _webDriverProvider;
        private readonly IWebDriverBaseMethods _webDriverBaseMethods;

        private readonly RemoteWebDriver _remoteWebDriver;
        private readonly INavigation _navigation;

        private readonly string _plemionaUrl = "https://www.plemiona.pl/";

        private readonly TimeSpan _timeoutForExpectedElements = TimeSpan.FromSeconds(5);
        private readonly TimeSpan _timeoutForChceckingElementsExistence = TimeSpan.FromSeconds(2);

        private string _currentVillageNumber;
        private string _csrfVillageToken;

        public PlemionaSteps(
            IWebDriverProvider webDriverProvider,
            IWebDriverBaseMethods webDriverBaseMethods)
        {
            _webDriverProvider = webDriverProvider;
            _webDriverBaseMethods = webDriverBaseMethods;

            _remoteWebDriver = _webDriverProvider.CreateWebDriver();

            _navigation = _remoteWebDriver.Navigate();
        }

        public void LoadPlemionaWebsite()
        {
            _webDriverBaseMethods.ExceptionHandler(() =>
            {
                _navigation.GoToUrl(_plemionaUrl);
            });
        }

        public bool IsPlayerSignedIn() => _webDriverBaseMethods.ExistsBy(By.XPath("//[@href='/page/logout']"));
        public void ClickSignOutFromAccountButton() => _webDriverBaseMethods.ExistsBy(By.XPath("//[@href='/page/logout']"));
        public void FillUserTextBox(string username) => _webDriverBaseMethods.FillBy(By.Id("user"), username);
        public void FillPasswordTextBox(string password) => _webDriverBaseMethods.FillBy(By.Id("password"), password);
        public void ClickSignInButton() => _webDriverBaseMethods.ClickBy(By.ClassName("btn-login"));
        public void ClickWorldButton(int worldNumber)
        {
            _webDriverBaseMethods.ClickByAndCondition(ExpectedConditions.ElementExists(By.XPath($"//span[contains(text(),'{worldNumber}')]")), _timeoutForExpectedElements);

            _webDriverBaseMethods.ExceptionHandler(InitializeVillageData);
        }

        public void ClearVillageNameTextBox() => _webDriverBaseMethods.ClearBy(By.Name("name"));
        public void FillVillageNameTextBox(string villageName) => _webDriverBaseMethods.FillBy(By.Name("name"), villageName);
        public void ClickVillageNameChangeButton() => _webDriverBaseMethods.ClickBy(By.XPath("//input[@type='submit']"));

        public bool DidDailySignInGiftWindowPopUp() => _webDriverBaseMethods.ExistsBy(By.Id("popup_box_daily_bonus"));
        public void ClickDailySignInGiftReceiveButton()
        {
            _webDriverBaseMethods.ExceptionHandler(() =>
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

        public void ClickVillageViewButton() => _webDriverBaseMethods.ClickBy(By.XPath($"//[@href='/game.php?village={_currentVillageNumber}&screen=overview']"));
        public void ClickKnightRecruitmentButton() => _webDriverBaseMethods.ClickBy(By.ClassName("knight_recruit_launch")); // btn_recruit w innym trybie
        public void ClearKnightNameTextBox() => _webDriverBaseMethods.ClearByAndCondition(ExpectedConditions.ElementExists(By.Id("knight_recruit_name")), _timeoutForExpectedElements);
        public void FillKnightNameTextBox(string knightName) => _webDriverBaseMethods.FillByAndCondition(ExpectedConditions.ElementExists(By.Id("knight_recruit_name")), _timeoutForExpectedElements, knightName);
        public void ClickKnightRecruitmentConfirmationButton() => _webDriverBaseMethods.ClickBy(By.Id("knight_recruit_confirm"));
        public bool CanSkipKnightRecruitment() => _webDriverBaseMethods.ExistsByAndCondition(ExpectedConditions.ElementExists(By.ClassName("knight_recruit_rush")), _timeoutForChceckingElementsExistence);
        public void ClickKnightRecruitmentSkipButton() => _webDriverBaseMethods.ClickBy(By.ClassName("knight_recruit_rush"));
        public void ClickKnightRecruitmentCancellationButton() => _webDriverBaseMethods.ClickBy(By.ClassName("knight_recruit_abort"));
        public void ClickKnightRevivalButton() => _webDriverBaseMethods.ClickBy(By.ClassName("knight_revive_launch"));
        public void ClickKnightRevivalConfirmationButton() => _webDriverBaseMethods.ClickBy(By.Id("knight_revive_confirm"));

        public void ClickTownhallPicture() => _webDriverBaseMethods.ClickBy(By.XPath($"//[@href='/game.php?village={_currentVillageNumber}&screen=main']"));
        public void ClickYardPicture() => _webDriverBaseMethods.ClickBy(By.XPath($"//[@href='/game.php?village={_currentVillageNumber}&screen=place']"));
        public void ClickBarracksPicture() => _webDriverBaseMethods.ClickBy(By.XPath($"//[@href='/game.php?village={_currentVillageNumber}&screen=barracks']"));
        public void ClickStatuePicture() => _webDriverBaseMethods.ClickBy(By.XPath($"//[@href='/game.php?village={_currentVillageNumber}&screen=statue']"));
        public void ClickStablePicture() => _webDriverBaseMethods.ClickBy(By.XPath("NULL"));
        public void ClickWorkshopPicture() => _webDriverBaseMethods.ClickBy(By.XPath("NULL"));
        public void ClickPalacePicture() => _webDriverBaseMethods.ClickBy(By.XPath("NULL"));
        // CLICK BUILDINGS

        public void FillSpearmenCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("spear_0"), count.ToString());
        public void FillSwordmenCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("NULL"), count.ToString());
        public void FillAxemenCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("NULL"), count.ToString());
        public void FillBowmenCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("NULL"), count.ToString());
        public void ClickUnsaddledTroopsRecruitmentButton() => _webDriverBaseMethods.ClickBy(By.ClassName("btn-recruit"));

        public void FillScoutCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("NULL"), count.ToString());
        public void FillLightCavalaryCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("NULL"), count.ToString());
        public void FillHorseArchersCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("NULL"), count.ToString());
        public void FillHeavyCavalaryCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("NULL"), count.ToString());
        public void ClickSaddledTroopsRecruitmentButton() => _webDriverBaseMethods.ClickBy(By.ClassName("NULL"));

        public void FillRamsCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("NULL"), count.ToString());
        public void FillCatapultesCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("NULL"), count.ToString());
        public void ClickWarMachinesRecruitmentTroops() => _webDriverBaseMethods.ClickBy(By.ClassName("NULL"));

        public void FillYardSpearmenCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("unit_input_spear"), count.ToString());
        public void FillYardSwordmenCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("unit_input_sword"), count.ToString());
        public void FillYardAxemenCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("unit_input_axe"), count.ToString());
        public void FillYardBowmenCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("unit_input_archer"), count.ToString());
        public void FillYardScoutCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("unit_input_spy"), count.ToString());
        public void FillYardLightCavalaryCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("unit_input_light"), count.ToString());
        public void FillYardHorseArchersCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("unit_input_marcher"), count.ToString());
        public void FillYardHeavyCavalaryCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("unit_input_heavy"), count.ToString());
        public void FillYardRamsCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("unit_input_ram"), count.ToString());
        public void FillYardCatapultesCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("unit_input_catapult"), count.ToString());
        public void FillYardKnightsCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("unit_input_knight"), count.ToString());
        public void FillYardNobelmenCountTextBox(int count) => _webDriverBaseMethods.FillBy(By.Id("unit_input_snob"), count.ToString());
        public void FillAttackCoordinatesTextBox(int coordinateX, int coordinateY) => _webDriverBaseMethods.FillBy(By.ClassName("target-input-field"), $"{coordinateX}|{coordinateY}");
        public void ClickSendAttackButton() => _webDriverBaseMethods.ClickBy(By.Id("target_attack"));
        public void ClickSendHelpButton() => _webDriverBaseMethods.ClickBy(By.Id("target_support"));

        public int GetSelfWoodCount() => _webDriverBaseMethods.ExceptionHandler(() => Convert.ToInt32(_webDriverBaseMethods.GetTextBy(By.Id("wood"))));
        public int GetSelfClayCount() => _webDriverBaseMethods.ExceptionHandler(() => Convert.ToInt32(_webDriverBaseMethods.GetTextBy(By.Id("stone"))));
        public int GetSelfIronCount() => _webDriverBaseMethods.ExceptionHandler(() => Convert.ToInt32(_webDriverBaseMethods.GetTextBy(By.Id("iron"))));

        public int GetTownhallLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=main");
        public int GetBarracksLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=barracks");
        public int GetStableLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=stable");
        public int GetWorkshopLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=garage");
        public int GetPalaceLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=snob");
        public int GetForgeLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=smith");
        public int GetYardLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=place");
        public int GetMarketLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=market");
        public int GetSawmillLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=wood");
        public int GetBrickyardLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=stone");
        public int GetIronworksLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=iron");
        public int GetFarmLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=farm");
        public int GetStorageLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=storage");
        public int GetClipboardLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=hide");
        public int GetWallLevel() => GetBuildingLevel($"/game.php?village={_currentVillageNumber}&screen=wall");

        public void ClickWorldMapButton() => _webDriverBaseMethods.ClickBy(By.XPath($"//[@href='/game.php?village={_currentVillageNumber}&screen=map']"));

        public void ClickSignOutFromWorldButton() => _webDriverBaseMethods.ClickBy(By.XPath($"//[@href='/game.php?village={_currentVillageNumber}&screen=&action=logout&h={_csrfVillageToken}']"));
        public void ClickReturnToMainPageButton() => _webDriverBaseMethods.ClickBy(By.XPath("//div[@class='button small']"));

        private int GetBuildingLevel(string buildingHref)
        {
            int buildingLevel = _webDriverBaseMethods.ExceptionHandler(() =>
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

        private void InitializeVillageData()
        {
            // Receiving village unique number required to many url-based steps
            string hrefStart = "/game.php?village=";
            string hrefEnd = "&screen=overview";

            var element = _remoteWebDriver.FindElement(By.XPath($"//a[contains(@href,'{hrefStart}') and contains(@href,'{hrefEnd}')]"));

            string elementHref = element.GetAttribute("href");
            elementHref = elementHref.Remove(0, elementHref.IndexOf("=") + 1);

            string villageNumber = string.Join(string.Empty, elementHref.TakeWhile(c => c != '&'));

            _currentVillageNumber = villageNumber;

            // Receiving csrf token required (so far) to url-based sign out step
            var scripts = _remoteWebDriver.FindElementsByTagName("script");
            var scriptTexts = scripts.Select(s => s.GetAttribute("innerHTML"));
            string mergerScriptsText = string.Join(string.Empty, scriptTexts);
            string mergerScriptsTextWithoutSpaces = mergerScriptsText.Replace(" ", string.Empty);
            string csrfSearchPhrase = "\"csrf\":\"";
            int index = mergerScriptsText.IndexOf(csrfSearchPhrase);

            int csrfSearchPhraseLength = csrfSearchPhrase.Length;
            int csrfTokenLength = 8;

            string csrfVillageToken = mergerScriptsText.Substring(index + csrfSearchPhraseLength, csrfTokenLength);
            _csrfVillageToken = csrfVillageToken;
        }
    }
}