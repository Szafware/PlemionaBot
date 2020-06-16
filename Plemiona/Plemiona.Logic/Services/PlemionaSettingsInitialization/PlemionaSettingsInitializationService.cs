using Plemiona.Core.Configuration;
using System;
using System.Configuration;

namespace Plemiona.Logic.Services.PlemionaSettingsInitialization
{
    public class PlemionaSettingsInitializationService : IPlemionaSettingsInitializationService
    {
        private readonly PlemionaSettings _plemionaSettings;

        public PlemionaSettingsInitializationService(PlemionaSettings plemionaSettings)
        {
            _plemionaSettings = plemionaSettings;
        }

        public void Initialize()
        {
            bool showConsole = Convert.ToBoolean(ConfigurationManager.AppSettings["ShowConsole"]);

            _plemionaSettings.ShowConsole = showConsole;
        }
    }
}