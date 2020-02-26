using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using PleAutomiX.Bots.Steps.Exceptions;
using PleAutomiX.Bots.WebDriver;
using SeleniumExtras.WaitHelpers;
using System;

namespace PleAutomiX.Bots.Steps.WebDriverBase
{
    public class WebDriverBaseMethods : IWebDriverBaseMethods
    {
        private readonly IWebDriverProvider _webDriverProvider;
        private readonly RemoteWebDriver _remoteWebDriver;

        public WebDriverBaseMethods(IWebDriverProvider webDriverProvider)
        {
            _webDriverProvider = webDriverProvider;
            _remoteWebDriver = _webDriverProvider.CreateWebDriver();
        }

        public void FillElementTextById(string id, string text)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElementById(id);
                element.SendKeys(text);
            });
        }

        public void FillElementTextByClassName(string className, string text)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElementByClassName(className);
                element.SendKeys(text);
            });
        }

        public void FillElementTextByName(string name, string text)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElementByName(name);
                element.SendKeys(text);
            });
        }

        public void FillElementTextByXPath(string xPath, string text)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElementByXPath(xPath);
                element.SendKeys(text);
            });
        }

        public void ClickElementById(string id)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElementById(id);
                element.Click();
            });
        }

        public void ClickElementByClassName(string className)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElementByClassName(className);
                element.Click();
            });
        }

        public void ClickElementByHref(string href)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElement(By.CssSelector($"[href*='{href}']"));
                element.Click();
            });
        }

        public void ClickElementByXPath(string xPath)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElementByXPath(xPath);
                element.Click();
            });
        }

        public string GetElementTextById(string id)
        {
            var value = ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElementById(id);
                string elementText = element.Text;
                return elementText;
            });

            return value;
        }

        public void ClearElementContentById(string id)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElementById(id);
                element.Clear();
            });
        }

        public void ClearElementContentByClassName(string className)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElementByClassName(className);
                element.Clear();
            });
        }

        public void ClearElementContentByName(string name)
        {
            ExceptionHandler(() =>
            {
                var element = _remoteWebDriver.FindElementByName(name);
                element.Clear();
            });
        }

        public bool ElementExistsById(string id)
        {
            bool elementExists = ExistsExceptionHandler(() => _remoteWebDriver.FindElementById(id));
            return elementExists;
        }

        public bool ElementExistsByClassName(string className)
        {
            bool elementExists = ExistsExceptionHandler(() => _remoteWebDriver.FindElementByClassName(className));
            return elementExists;
        }

        public bool ElementExistsByHref(string href)
        {
            bool elementExists = ExistsExceptionHandler(() => _remoteWebDriver.FindElement(By.CssSelector($"[href*='{href}']")));
            return elementExists;
        }

        public bool ElementExistsByIdWithDelay(string id, TimeSpan timeout)
        {
            bool elementExists = ElementExistsByWhenAppears(By.Id(id), timeout);
            return elementExists;
        }

        public bool ElementExistsByClassNameWithDelay(string className, TimeSpan timeout)
        {
            bool elementExists = ElementExistsByWhenAppears(By.ClassName(className), timeout);
            return elementExists;
        }

        public bool ElementExistsByHrefWithDelay(string href, TimeSpan timeout)
        {
            bool elementExists = ElementExistsByWhenAppears(By.CssSelector($"[href*='{href}']"), timeout);
            return elementExists;
        }

        public void ClickElementByIdWhenAppears(string id, TimeSpan timeout)
        {
            ClickElementByWhenAppears(By.Id(id), timeout);
        }

        public void ClickElementByClassNameWhenAppears(string className, TimeSpan timeout)
        {
            ClickElementByWhenAppears(By.ClassName(className), timeout);
        }

        public void ClickElementByHrefWhenAppears(string href, TimeSpan timeout)
        {
            ClickElementByWhenAppears(By.CssSelector($"[href*='{href}']"), timeout);
        }

        public void FillElementByIdWhenAppears(string id, TimeSpan timeout, string text)
        {
            FillElementByWhenAppears(By.Id(id), timeout, text);
        }

        public void FillElementByClassNameWhenAppears(string className, TimeSpan timeout, string text)
        {
            FillElementByWhenAppears(By.ClassName(className), timeout, text);
        }

        public void FillElementByHrefWhenAppears(string href, TimeSpan timeout, string text)
        {
            FillElementByWhenAppears(By.CssSelector($"[href*='{href}']"), timeout, text);
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

        private bool ElementExistsByWhenAppears(By by, TimeSpan timeout)
        {
            bool elementExists = ExistsExceptionHandler(() =>
            {
                var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
                webDriverWait.Until(ExpectedConditions.ElementExists(by));
            });

            return elementExists;
        }

        private void ClickElementByWhenAppears(By by, TimeSpan timeout)
        {
            ExceptionHandler(() =>
            {
                var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
                var skipKnightRecruitmentButton = webDriverWait.Until(ExpectedConditions.ElementExists(by));
                skipKnightRecruitmentButton.Click();
            });
        }

        private void FillElementByWhenAppears(By by, TimeSpan timeout, string text)
        {
            ExceptionHandler(() =>
            {
                var webDriverWait = new WebDriverWait(_remoteWebDriver, timeout);
                var skipKnightRecruitmentButton = webDriverWait.Until(ExpectedConditions.ElementExists(by));
                skipKnightRecruitmentButton.SendKeys(text);
            });
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