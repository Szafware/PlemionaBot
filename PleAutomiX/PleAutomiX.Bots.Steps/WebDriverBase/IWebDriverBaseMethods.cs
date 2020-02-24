using System;

namespace PleAutomiX.Bots.Steps.WebDriverBase
{
    public interface IWebDriverBaseMethods
    {
        void FillElementTextById(string Id, string text);
        void FillElementTextByClassName(string className, string text);
        void FillElementTextByName(string name, string text);
        void FillElementTextByXPath(string xPath, string text);
        
        void ClickElementById(string id);
        void ClickElementByClassName(string className);
        void ClickElementByHref(string href);
        void ClickElementByXPath(string xPath);
        
        string GetElementTextById(string id);

        void ClearElementContentById(string id);
        void ClearElementContentByClassName(string className);
        void ClearElementContentByName(string name);

        bool ElementExistsById(string id);
        bool ElementExistsByClassName(string className);
        bool ElementExistsByHref(string href);

        bool ElementExistsByIdWithDelay(string id, TimeSpan timeout);
        bool ElementExistsByClassNameWithDelay(string className, TimeSpan timeout);
        bool ElementExistsByHrefWithDelay(string href, TimeSpan timeout);
        
        void ClickElementByHrefWhenAppears(string href, TimeSpan timeout);
        void ClickElementByIdWhenAppears(string id, TimeSpan timeout);
        void ClickElementByClassNameWhenAppears(string className, TimeSpan timeout);
        
        void FillElementByHrefWhenAppears(string href, TimeSpan timeout, string text);
        void FillElementByIdWhenAppears(string id, TimeSpan timeout, string text);
        void FillElementByClassNameWhenAppears(string className, TimeSpan timeout, string text);
    }
}