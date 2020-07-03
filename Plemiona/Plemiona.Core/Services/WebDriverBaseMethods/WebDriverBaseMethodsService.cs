using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverProvider;
using System;

namespace Plemiona.Core.Services.WebDriverBase
{
    public class WebDriverBaseMethodsService : IWebDriverBaseMethodsService
    {
        private readonly IWebDriverProviderService _webDriverProviderService;
        private readonly ITypingDelayService _typingDelayService;

        private RemoteWebDriver _remoteWebDriver;

        public WebDriverBaseMethodsService(
            IWebDriverProviderService webDriverProviderService,
            ITypingDelayService typingDelayService)
        {
            _webDriverProviderService = webDriverProviderService;
            _typingDelayService = typingDelayService;
        }

        public void Initialize()
        {
            _remoteWebDriver = _webDriverProviderService.CreateWebDriver();
        }

        public IWebElement GetBy(By by)
        {
            var localElement = _remoteWebDriver.FindElement(by);
            return localElement;
        }

        public IWebElement GetByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout)
        {
            var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
            var element = webDriverWait.Until(expectedCondition);
            return element;
        }

        public void ClickBy(By by)
        {
            var element = _remoteWebDriver.FindElement(by);
            element.Click();
        }

        public void FillBy(By by, string text)
        {
            var element = _remoteWebDriver.FindElement(by);

            foreach (char character in text)
            {
                _typingDelayService.Delay();
                element.SendKeys(character.ToString()); 
            }
        }

        public void ClearBy(By by)
        {
            var element = _remoteWebDriver.FindElement(by);
            element.Clear();
        }

        public string GetTextBy(By by)
        {
            var element = _remoteWebDriver.FindElement(by);
            string elementText = element.Text;
            return elementText;
        }

        public bool ExistsBy(By by)
        {
            try
            {
                _remoteWebDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void ClickByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout)
        {
            var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
            var element = webDriverWait.Until(expectedCondition);
            element.Click();
        }

        public void FillByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout, string text)
        {
            var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
            var element = webDriverWait.Until(expectedCondition);

            foreach (char character in text)
            {
                _typingDelayService.Delay();
                element.SendKeys(character.ToString());
            }
        }

        public void ClearByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout)
        {
            var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
            var element = webDriverWait.Until(expectedCondition);
            element.Clear();
        }

        public string GetTextByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout)
        {
            var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
            var element = webDriverWait.Until(expectedCondition);
            string elementText = element.Text;
            return elementText;
        }

        public bool ExistsByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout)
        {
            try
            {
                var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
                var element = webDriverWait.Until(expectedCondition);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}