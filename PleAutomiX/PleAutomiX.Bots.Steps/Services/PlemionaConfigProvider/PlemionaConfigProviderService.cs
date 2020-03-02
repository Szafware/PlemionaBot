using OpenQA.Selenium.Remote;
using PleAutomiX.Bots.Steps.Models;
using PleAutomiX.Bots.WebDriver;
using System.Linq;

namespace PleAutomiX.Bots.Steps.Services.PlemionaConfigProvider
{
    public class PlemionaConfigProviderService : IPlemionaConfigProviderService
    {
        private readonly IWebDriverProvider _webDriverProvider;
        private readonly RemoteWebDriver _webDriver;

        public PlemionaConfigProviderService(IWebDriverProvider webDriverProvider)
        {
            _webDriverProvider = webDriverProvider;
            _webDriver = _webDriverProvider.CreateWebDriver();
        }

        public PlemionaConfig Create()
        {
            string script = GetJoinedScripts();

            var plemionaConfig = new PlemionaConfig
            {
                PlemionaVersion = GetJsPropertyValue(script, "majorVersion"),
                VillageId = GetJsPropertyValue(script, "id"),
                CsrfToken = GetJsPropertyValue(script, "csrf")
            };

            return plemionaConfig;
        }

        private string GetJoinedScripts()
        {
            var scripts = _webDriver.FindElementsByTagName("script");
            var scriptTexts = scripts.Select(s => s.GetAttribute("innerHTML"));
            string joinedScriptsText = string.Join(string.Empty, scriptTexts);
            string joinedScriptsTextWithoutSpaces = joinedScriptsText.Replace(" ", string.Empty);

            return joinedScriptsTextWithoutSpaces;
        }

        private string GetJsPropertyValue(string script, string propertyName)
        {
            string propertyNamePart = $"\"{propertyName}\":";
            int propertyNamePartLength = propertyNamePart.Length;

            int propertyValueStartIndex = script.IndexOf(propertyNamePart) + propertyNamePartLength;

            string scriptStartingFromPropertyValueFirstCharacter = script.Remove(0, propertyValueStartIndex);

            bool propertyValueFirstCharacterIsApostrophe = scriptStartingFromPropertyValueFirstCharacter.StartsWith('"');

            char propertyValueEndCharacter = scriptStartingFromPropertyValueFirstCharacter.StartsWith('"') ? '"' : ',';

            if (propertyValueFirstCharacterIsApostrophe)
            {
                scriptStartingFromPropertyValueFirstCharacter = scriptStartingFromPropertyValueFirstCharacter.Remove(0, 1);
            }

            var propertyValue = string.Join(string.Empty, scriptStartingFromPropertyValueFirstCharacter.TakeWhile(c => c != propertyValueEndCharacter));

            return propertyValue;
        }
    }
}