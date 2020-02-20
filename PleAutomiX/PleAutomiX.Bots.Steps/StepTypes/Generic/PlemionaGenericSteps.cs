using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using PleAutomiX.Bots.Steps.Exceptions;
using PleAutomiX.Bots.WebDriver;
using System;

namespace PleAutomiX.Bots.Steps.StepTypes.Generic
{
    public class PlemionaGenericSteps : IPlemionaGenericSteps
    {
        private readonly IWebDriverProvider _webDriverProvider;

        private readonly RemoteWebDriver _remoteWebDriver;
        private readonly INavigation _navigation;

        private readonly string _plemionaUrl = "https://www.plemiona.pl/";


        public PlemionaGenericSteps(IWebDriverProvider webDriverProvider)
        {
            _webDriverProvider = webDriverProvider;

            _remoteWebDriver = _webDriverProvider.CreateWebDriver();

            _navigation = _remoteWebDriver.Navigate();
        }

        public void FillElementTextById(string textBoxId, string text)
        {
            try
            {
                var element = _remoteWebDriver.FindElementById(textBoxId);
                element.SendKeys(text);

            }
            catch (Exception ex)
            {
                throw new StepException(null, ex);
            }
        }

        public void FillElementTextByClassName(string className, string text)
        {
            try
            {
                var element = _remoteWebDriver.FindElementByClassName(className);
                element.SendKeys(text);

            }
            catch (Exception ex)
            {
                throw new StepException(null, ex);
            }
        }

        public void ClickElementByClassName(string className)
        {
            try
            {
                var element = _remoteWebDriver.FindElementByClassName(className);
                element.Click();
            }
            catch (Exception ex)
            {
                throw new StepException(null, ex);
            }
        }

        public void ClickElementByHref(string elementHref)
        {
            try
            {
                var element = _remoteWebDriver.FindElement(By.CssSelector($"[href*='/game.php?village=29403&screen={elementHref}']"));
                element.Click();
            }
            catch (Exception ex)
            {
                throw new StepException(null, ex);
            }
        }

        public void ClickElementById(string elementId)
        {
            try
            {
                var element = _remoteWebDriver.FindElementById(elementId);
                element.Click();
            }
            catch (Exception ex)
            {
                throw new StepException(null, ex);
            }
        }

        public bool ElementExistsById(string elementId, out IWebElement webElement)
        {
            try
            {
                webElement = _remoteWebDriver.FindElementById(elementId);

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