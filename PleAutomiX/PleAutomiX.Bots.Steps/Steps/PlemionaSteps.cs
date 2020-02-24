using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using PleAutomiX.Bots.Steps.Exceptions;
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

        public void LoadPlemionaWebsite() => _navigation.GoToUrl(_plemionaUrl);

        public bool IsPlayerSignedIn() => _webDriverBaseMethods.ElementExistsByHref("/page/logout");
        public void ClickSignOutFromAccountButton() => _webDriverBaseMethods.ClickElementByHref("/page/logout");
        public void FillUserTextBox(string username) => _webDriverBaseMethods.FillElementTextById("user", username);
        public void FillPasswordTextBox(string password) => _webDriverBaseMethods.FillElementTextById("password", password);
        public void ClickSignInButton() => _webDriverBaseMethods.ClickElementByClassName("btn-login");
        public void ClickWorldButton(int worldNumber)
        {
            ExceptionHandler(() =>
            {
                var webDriverWait = new WebDriverWait(_remoteWebDriver, TimeSpan.FromSeconds(5));
                var worldButton = webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath($"//span[contains(text(),'{worldNumber}')]")));

                worldButton.Click();

                InitializeVillageData();
            });
        }

        public void ClearVillageNameTextBox() => _webDriverBaseMethods.ClearElementContentByName("name");
        public void FillVillageNameTextBox(string villageName) => _webDriverBaseMethods.FillElementTextByName("name", villageName);
        public void ClickVillageNameChangeButton()
        {
            ExceptionHandler(() =>
            {
                var villageNameChangeButton = _remoteWebDriver.FindElementByXPath("//input[@type='submit']");
                villageNameChangeButton.Click();
            });
        }

        public void ClickDailySignInGiftReceiveButton()
        {
            ExceptionHandler(() =>
            {
                var giftButtons = _remoteWebDriver.FindElementsByClassName("btn-default");

                foreach (var giftButton in giftButtons)
                {
                    giftButton.Click();
                }
            });
        }

        public bool DidEventWindowPoopUp() => _webDriverBaseMethods.ElementExistsByClassName("popup_box_close");
        public void ClickEventWindowCloseButton() => _webDriverBaseMethods.ClickElementByClassName("popup_box_close");

        public void ClickVillageViewButton() => _webDriverBaseMethods.ClickElementByHref($"/game.php?village={_currentVillageNumber}&screen=overview");
        public void ClickKnightRecruitmentButton() => _webDriverBaseMethods.ClickElementByClassName("knight_recruit_launch"); // btn_recruit w innym trybie
        public void ClearKnightNameTextBox() => _webDriverBaseMethods.FillElementByIdWhenAppears("knight_recruit_name", _timeoutForExpectedElements, "\b");
        public void FillKnightNameTextBox(string knightName) => _webDriverBaseMethods.FillElementByIdWhenAppears("knight_recruit_name", _timeoutForExpectedElements, knightName);
        public void ClickKnightRecruitmentConfirmationButton() => _webDriverBaseMethods.ClickElementById("knight_recruit_confirm");
        public bool CanSkipKnightRecruitment() => _webDriverBaseMethods.ElementExistsByClassNameWithDelay("knight_recruit_rush", _timeoutForChceckingElementsExistence);
        public void ClickKnightRecruitmentSkipButton() => _webDriverBaseMethods.ClickElementByClassName("knight_recruit_rush");
        public void ClickKnightRecruitmentCancellationButton() => _webDriverBaseMethods.ClickElementByClassName("knight_recruit_abort");
        public void ClickKnightRevivalButton() => _webDriverBaseMethods.ClickElementByClassName("knight_revive_launch");
        public void ClickKnightRevivalConfirmationButton() => _webDriverBaseMethods.ClickElementById("knight_revive_confirm");

        public void ClickTownhallPicture() => _webDriverBaseMethods.ClickElementByHref($"/game.php?village={_currentVillageNumber}&screen=main");
        public void ClickYardPicture() => _webDriverBaseMethods.ClickElementByHref($"/game.php?village={_currentVillageNumber}&screen=place");
        public void ClickBarracksPicture() => _webDriverBaseMethods.ClickElementByHref($"/game.php?village={_currentVillageNumber}&screen=barracks");
        public void ClickStatuePicture() => _webDriverBaseMethods.ClickElementByHref($"/game.php?village={_currentVillageNumber}&screen=statue");
        public void ClickStablePicture() => _webDriverBaseMethods.ClickElementByHref("NULL");
        public void ClickWorkshopPicture() => _webDriverBaseMethods.ClickElementByHref("NULL");
        public void ClickPalacePicture() => _webDriverBaseMethods.ClickElementByHref("NULL");
        // CLICK BUILDINGS

        public void FillSpearmenCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("spear_0", count.ToString());
        public void FillSwordmenCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("NULL", count.ToString());
        public void FillAxemenCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("NULL", count.ToString());
        public void FillBowmenCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("NULL", count.ToString());
        public void ClickUnsaddledTroopsRecruitmentButton() => _webDriverBaseMethods.ClickElementByClassName("btn-recruit");

        public void FillScoutCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("NULL", count.ToString());
        public void FillLightCavalaryCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("NULL", count.ToString());
        public void FillHorseArchersCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("NULL", count.ToString());
        public void FillHeavyCavalaryCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("NULL", count.ToString());
        public void ClickSaddledTroopsRecruitmentButton() => _webDriverBaseMethods.ClickElementByClassName("NULL");

        public void FillRamsCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("NULL", count.ToString());
        public void FillCatapultesCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("NULL", count.ToString());
        public void ClickWarMachinesRecruitmentTroops() => _webDriverBaseMethods.ClickElementByClassName("NULL");

        public void FillYardSpearmenCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("unit_input_spear", count.ToString());
        public void FillYardSwordmenCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("unit_input_sword", count.ToString());
        public void FillYardAxemenCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("unit_input_axe", count.ToString());
        public void FillYardBowmenCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("unit_input_archer", count.ToString());
        public void FillYardScoutCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("unit_input_spy", count.ToString());
        public void FillYardLightCavalaryCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("unit_input_light", count.ToString());
        public void FillYardHorseArchersCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("unit_input_marcher", count.ToString());
        public void FillYardHeavyCavalaryCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("unit_input_heavy", count.ToString());
        public void FillYardRamsCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("unit_input_ram", count.ToString());
        public void FillYardCatapultesCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("unit_input_catapult", count.ToString());
        public void FillYardKnightsCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("unit_input_knight", count.ToString());
        public void FillYardNobelmenCountTextBox(int count) => _webDriverBaseMethods.FillElementTextById("unit_input_snob", count.ToString());
        public void FillAttackCoordinatesTextBox(int coordinateX, int coordinateY) => _webDriverBaseMethods.FillElementTextByClassName("target-input-field", $"{coordinateX}|{coordinateY}");
        public void ClickSendAttackButton() => _webDriverBaseMethods.ClickElementById("target_attack");
        public void ClickSendHelpButton() => _webDriverBaseMethods.ClickElementById("target_support");

        public int GetSelfWoodCount() => Convert.ToInt32(_webDriverBaseMethods.GetElementTextById("wood"));
        public int GetSelfClayCount() => Convert.ToInt32(_webDriverBaseMethods.GetElementTextById("stone"));
        public int GetSelfIronCount() => Convert.ToInt32(_webDriverBaseMethods.GetElementTextById("iron"));

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

        public void ClickToWorldMapButton() => _webDriverBaseMethods.ClickElementByHref("map");

        public void ClickSignOutFromWorldButton() => _webDriverBaseMethods.ClickElementByHref("game.php?village=37578&screen=&action=logout&h=f1a47cb8");
        public void ClickReturnToMainPageButton() => _webDriverBaseMethods.ClickElementByHref("/");

        private int GetBuildingLevel(string buildingHref)
        {
            int buildingLevel = ExceptionHandler(() =>
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
                catch
                {
                    // Building label contains "not built". Returning level 0.
                    return 0;
                }

                return buildingLevelLabelNumbers;
            });

            return buildingLevel;
        }

        private TValue ExceptionHandler<TValue>(Func<TValue> function)
        {
            try
            {
                var value = function.Invoke();

                return value;
            }
            catch (Exception ex)
            {
                throw new StepException(null, ex);
            }
        }

        private void ExceptionHandler(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception ex)
            {
                throw new StepException(null, ex);
            }
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