using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using PleAutomiX.Bots.Steps.Exceptions;
using PleAutomiX.Bots.WebDriver;
using System;

namespace PleAutomiX.Bots.Steps.WebDriverBase
{
    public class WebDriverBaseMethodsService : IWebDriverBaseMethodsService
    {
        private readonly IWebDriverProvider _webDriverProvider;
        private readonly RemoteWebDriver _remoteWebDriver;

        public WebDriverBaseMethodsService(IWebDriverProvider webDriverProvider)
        {
            _webDriverProvider = webDriverProvider;
            _remoteWebDriver = _webDriverProvider.CreateWebDriver();
        }

        public IWebElement GetBy(By by)
        {
            var element = ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElement(by);
                return element;
            });

            return element;
        }

        public IWebElement GetByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout)
        {
            var element = ExceptionHandler(() =>
            {
                var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
                var element = webDriverWait.Until(expectedCondition);
                return element;
            });

            return element;
        }

        public void ClickBy(By by)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElement(by);
                element.Click();
            });
        }

        public void FillBy(By by, string text)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElement(by);
                element.SendKeys(text);
            });
        }

        public void ClearBy(By by)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElement(by);
                element.Clear();
            });
        }

        public string GetTextBy(By by)
        {
            string elementText = ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElement(by);
                string elementText = element.Text;
                return elementText;
            });

            return elementText;
        }

        public bool ExistsBy(By by)
        {
            bool elementExists = ExistsExceptionHandler(() => _remoteWebDriver.FindElement(by));
            return elementExists;
        }

        public void ClickByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout)
        {
            ExceptionHandler(() =>
            {
                var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
                var element = webDriverWait.Until(expectedCondition);
                element.Click();
            });
        }

        public void FillByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout, string text)
        {
            ExceptionHandler(() =>
            {
                var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
                var element = webDriverWait.Until(expectedCondition);
                element.SendKeys(text);
            });
        }

        public void ClearByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout)
        {
            ExceptionHandler(() =>
            {
                var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
                var element = webDriverWait.Until(expectedCondition);
                element.Clear();
            });
        }

        public string GetTextByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout)
        {
            string elementText = ExceptionHandler(() =>
            {
                var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
                var element = webDriverWait.Until(expectedCondition);
                string elementText = element.Text;
                return elementText;
            });

            return elementText;
        }

        public bool ExistsByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout)
        {
            bool elementExists = ExistsExceptionHandler(() =>
            {
                var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
                var element = webDriverWait.Until(expectedCondition);
            });

            return elementExists;
        }

        public void ExceptionHandler(Action action)
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

        public TValue ExceptionHandler<TValue>(Func<TValue> function)
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

        private bool ExistsExceptionHandler(Action indicator)
        {
            try
            {
                indicator();

                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw new StepException(null, ex);
            }
        }
    }
}