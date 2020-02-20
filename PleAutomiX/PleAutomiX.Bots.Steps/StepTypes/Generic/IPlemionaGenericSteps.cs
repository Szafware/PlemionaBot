using OpenQA.Selenium;

namespace PleAutomiX.Bots.Steps.StepTypes.Generic
{
    public interface IPlemionaGenericSteps
    {
        void FillElementTextById(string textBoxId, string text);
        void FillElementTextByClassName(string className, string text);

        void ClickElementByClassName(string className);
        void ClickElementByHref(string href);
        void ClickElementById(string elementId);

        bool ElementExistsById(string elementId, out IWebElement webElement);
    }
}