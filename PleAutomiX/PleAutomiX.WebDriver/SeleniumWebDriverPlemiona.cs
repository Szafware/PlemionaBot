using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;

namespace PleAutomiX.Bots.WebDriver
{
    public class SeleniumWebDriverPlemiona : IPlemionaWebDriver
    {
        private readonly string _plemionaUrl = "https://www.plemiona.pl/";

        private readonly ChromeDriver _chromeDriver;
        private INavigation _navigation;

        public SeleniumWebDriverPlemiona()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            _chromeDriver = new ChromeDriver(chromeDriverService);
        }

        public virtual void LoadPlemionaWebsite()
        {
            _navigation = _chromeDriver.Navigate();

            _navigation.GoToUrl(_plemionaUrl);
        }

        public virtual void SignIn(string username, string password)
        {
            var loginElement = _chromeDriver.FindElementById("user");
            loginElement.SendKeys(username);

            var passwordElement = _chromeDriver.FindElementById("password");
            passwordElement.SendKeys(password);

            var loginButtonElement = _chromeDriver.FindElementByClassName("btn-login");
            loginButtonElement.Click();
        }

        public virtual void PickWorld(int worldNumber)
        {
            var activeWorldButtonElements = _chromeDriver.FindElementsByClassName("world_button_active");

            var activeWorldButtonElement = activeWorldButtonElements.SingleOrDefault(awbe => awbe.Text.Contains(worldNumber.ToString()));

            if (activeWorldButtonElement == null)
            {
                // TODO throw custom Exception? 
            }

            activeWorldButtonElement.Click();

            //if (ElementExists("popup_box_daily_bonus", out var dailyGiftDialogBoxElement))
            //{

            //}
        }

        public virtual void GetDailySignInGift()
        {
            var openGiftElement = _chromeDriver.FindElementByClassName("btn-default");

            openGiftElement.Click();
        }

        public virtual void GoToVillageView()
        {
            NavigateByHref("overview");
        }

        public virtual void GoToTownhall()
        {
            NavigateByHref("main");
        }

        public virtual void GoToYard()
        {
            NavigateByHref("place");
        }

        public virtual void GoToBarracks()
        {
            NavigateByHref("barracks");
        }

        // GOTOBUILDING

        public virtual void RecruitSpearmen(int count)
        {
            var spearmenCountElement = _chromeDriver.FindElementById("spear_0");
            spearmenCountElement.SendKeys(count.ToString());

            var recruitButtonElement = _chromeDriver.FindElementByClassName("btn-recruit");
            recruitButtonElement.Click();
        }

        public virtual void RecruitKnights(int count)
        {

        }

        public virtual void RecruitAxemen(int count)
        {
            
        }

        public virtual void RecruitBowmen(int count)
        {

        }

        public virtual void GoToWorldMap()
        {
            NavigateByHref("map");
        }

        public void AttackVillage(int coordinateX, int coordinateY, int pikemenCount)
        {
            //GoTo
        }

        private void NavigateByHref(string buildingName)
        {
            var townhallElement = _chromeDriver.FindElement(By.CssSelector($"[href*='/game.php?village=29403&screen={buildingName}']"));

            townhallElement.Click();
        }

        private bool ElementExists(string id, out IWebElement webElement)
        {
            try
            {
                webElement = _chromeDriver.FindElementById(id);

                return true;
            }
            catch (NoSuchElementException)
            {
                webElement = null;

                return false;
            }
        }
    }
}