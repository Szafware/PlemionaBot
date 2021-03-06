﻿using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Remote;
using Plemiona.Core.Models;
using Plemiona.Core.Services.WebDriverProvider;
using System.Linq;

namespace Plemiona.Core.Services.PlemionaMetadataProvider
{
    public class PlemionaMetadataProviderService : IPlemionaMetadataProviderService
    {
        private readonly IWebDriverProviderService _webDriverProviderService;
        private RemoteWebDriver _webDriver;

        public PlemionaMetadataProviderService(IWebDriverProviderService webDriverProviderService)
        {
            _webDriverProviderService = webDriverProviderService;
        }

        public void Initialize()
        {
            _webDriver = _webDriverProviderService.CreateWebDriver();
        }

        public PlemionaMetadata Create()
        {
            string script = GetJoinedScripts();

            var metadataJsonString = GetMetadataJsonString(script);

            var metadataJson = JObject.Parse(metadataJsonString);

            var plemionaMetadata = new PlemionaMetadata
            {
                PlemionaVersion = GetJsPropertyValue(metadataJson, null, "majorVersion"),
                PlayerId = GetJsPropertyValue(metadataJson, "player", "id"),
                PlayerName = GetJsPropertyValue(metadataJson, "player", "name"),
                VillageId = GetJsPropertyValue(metadataJson, "village", "id"),
                CsrfToken = GetJsPropertyValue(metadataJson, null, "csrf")
            };

            return plemionaMetadata;
        }

        private string GetJoinedScripts()
        {
            var scripts = _webDriver.FindElementsByTagName("script");
            var scriptTexts = scripts.Select(s => s.GetAttribute("innerHTML"));
            string joinedScriptsText = string.Join(string.Empty, scriptTexts);
            string joinedScriptsTextWithoutSpaces = joinedScriptsText.Replace(" ", string.Empty);

            return joinedScriptsTextWithoutSpaces;
        }

        private string GetMetadataJsonString(string script)
        {
            string metadataJsonStartPhrase = "updateGameData(";

            int metadataJsonStartPhraseLength = metadataJsonStartPhrase.Length;

            int metadataJsonStartIndex = script.IndexOf(metadataJsonStartPhrase);

            string metadataJsonCutFromStart = script.Substring(metadataJsonStartIndex + metadataJsonStartPhraseLength);

            var metadataJsonEndIndex = metadataJsonCutFromStart.IndexOf(");");

            string metadataJson = metadataJsonCutFromStart.Substring(0, metadataJsonEndIndex);

            return metadataJson;
        }

        private string GetJsPropertyValue(JObject metadata, string parentName, string propertyName)
        {
            var jsPropertyValue = parentName == null ? 
                metadata[propertyName].Value<string>() : 
                metadata[parentName][propertyName].Value<string>();

            return jsPropertyValue;
        }
    }
}