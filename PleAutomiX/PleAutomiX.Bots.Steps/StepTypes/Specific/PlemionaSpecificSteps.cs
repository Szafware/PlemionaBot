using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using PleAutomiX.Bots.Steps.Exceptions;
using PleAutomiX.Bots.Steps.StepTypes.Generic;
using PleAutomiX.Bots.WebDriver;
using System;
using System.Linq;

namespace PleAutomiX.Bots.Steps.StepTypes.Specific
{
    public class PlemionaSpecificSteps : IPlemionaSpecificSteps
    {
        private readonly IWebDriverProvider _webDriverProvider;
        private readonly IPlemionaGenericSteps _plemionaGenericSteps;

        private readonly RemoteWebDriver _remoteWebDriver;
        private readonly INavigation _navigation;

        private readonly string _plemionaUrl = "https://www.plemiona.pl/";

        public PlemionaSpecificSteps(
            IWebDriverProvider webDriverProvider,
            IPlemionaGenericSteps plemionaGenericSteps)
        {
            _webDriverProvider = webDriverProvider;
            _plemionaGenericSteps = plemionaGenericSteps;

            _remoteWebDriver = _webDriverProvider.CreateWebDriver();

            _navigation = _remoteWebDriver.Navigate();
        }

        public void LoadPlemionaWebsite() => _navigation.GoToUrl(_plemionaUrl);

        public void FillUserTextBox(string username) => _plemionaGenericSteps.FillElementTextById("user", username);
        public void FillPasswordTextBox(string password) => _plemionaGenericSteps.FillElementTextById("password", password);
        public void ClickSignInButton() => _plemionaGenericSteps.ClickElementByClassName("btn-login");

        public void ClickWorldButton(int worldNumber)
        {
            try
            {
                var activeWorldButtonElements = _remoteWebDriver.FindElementsByClassName("world_button_active");

                var activeWorldButtonElement = activeWorldButtonElements.SingleOrDefault(awbe => awbe.Text.Contains(worldNumber.ToString()));

                activeWorldButtonElement.Click();
            }
            catch (Exception ex)
            {
                throw new StepException(null, ex);
            }
        }

        public void ClickDailySignInGiftReceiveButton() => _plemionaGenericSteps.ClickElementByClassName("btn-default");

        public void ClickVillageViewButton() => _plemionaGenericSteps.ClickElementByHref("overview");

        public void ClickKnightRevivalButton() => _plemionaGenericSteps.ClickElementByClassName("knight_revive_launch");
        public void ClickKnightRecruitmentButton() => _plemionaGenericSteps.ClickElementByClassName("NULL");

        public void ClickTownhallPicture() => _plemionaGenericSteps.ClickElementByHref("main");
        public void ClickYardPicture() => _plemionaGenericSteps.ClickElementByHref("place");
        public void ClickBarracksPicture() => _plemionaGenericSteps.ClickElementByHref("barracks");
        public void ClickStatuePicture() => _plemionaGenericSteps.ClickElementByHref("statue");
        public void ClickStablePicture() => _plemionaGenericSteps.ClickElementByHref("NULL");
        public void ClickWorkshopPicture() => _plemionaGenericSteps.ClickElementByHref("NULL");
        public void ClickPalacePicture() => _plemionaGenericSteps.ClickElementByHref("NULL");
        // CLICK BUILDINGS
        
        public void FillSpearmenCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("spear_0", count.ToString());
        public void FillSwordmenCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("NULL", count.ToString());
        public void FillAxemenCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("NULL", count.ToString());
        public void FillBowmenCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("NULL", count.ToString());
        public void ClickUnsaddledTroopsRecruitmentButton() => _plemionaGenericSteps.ClickElementByClassName("btn-recruit");

        public void FillScoutCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("NULL", count.ToString());
        public void FillLightCavalaryCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("NULL", count.ToString());
        public void FillHorseArchersCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("NULL", count.ToString());
        public void FillHeavyCavalaryCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("NULL", count.ToString());
        public void ClickSaddledTroopsRecruitmentButton() => _plemionaGenericSteps.ClickElementByClassName("NULL");

        public void FillRamsCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("NULL", count.ToString());
        public void FillCatapultesCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("NULL", count.ToString());
        public void ClickWarMachinesRecruitmentTroops() => _plemionaGenericSteps.ClickElementByClassName("NULL");

        public void FillYardSpearmenCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("unit_input_spear", count.ToString());
        public void FillYardSwordmenCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("unit_input_sword", count.ToString());
        public void FillYardAxemenCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("unit_input_axe", count.ToString());
        public void FillYardBowmenCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("unit_input_archer", count.ToString());
        public void FillYardScoutCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("unit_input_spy", count.ToString());
        public void FillYardLightCavalaryCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("unit_input_light", count.ToString());
        public void FillYardHorseArchersCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("unit_input_marcher", count.ToString());
        public void FillYardHeavyCavalaryCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("unit_input_heavy", count.ToString());
        public void FillYardRamsCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("unit_input_ram", count.ToString());
        public void FillYardCatapultesCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("unit_input_catapult", count.ToString());
        public void FillYardKnightsCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("unit_input_knight", count.ToString());
        public void FillYardNobelmenCountTextBox(int count) => _plemionaGenericSteps.FillElementTextById("unit_input_snob", count.ToString());
        public void FillAttackCoordinatesTextBox(int coordinateX, int coordinateY) => _plemionaGenericSteps.FillElementTextByClassName("target-input-field", $"{coordinateX}|{coordinateY}");
        public void ClickSendAttackButton() => _plemionaGenericSteps.ClickElementById("target_attack");
        public void ClickSendHelpButton() => _plemionaGenericSteps.ClickElementById("target_support");

        public void ClickToWorldMapButton() => _plemionaGenericSteps.ClickElementByHref("map");
    }
}