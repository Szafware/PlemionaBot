using OpenQA.Selenium;
using System;

namespace Plemiona.Core.Steps.WebDriverBase
{
    public interface IWebDriverBaseMethodsService
    {
        void Initialize();

        IWebElement GetBy(By by);
        IWebElement GetByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout);

        void ClickBy(By by);
        void FillBy(By by, string text);
        void ClearBy(By by);
        string GetTextBy(By by);
        bool ExistsBy(By by);

        void ClickByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout);
        void FillByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout, string text);
        void ClearByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout);
        string GetTextByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout);
        bool ExistsByAndCondition(Func<IWebDriver, IWebElement> expectedCondition, TimeSpan timeout);
    }
}