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
            string plemionaUrl = ConfigurationManager.AppSettings["PlemionaUrl"];
            string username = ConfigurationManager.AppSettings["Username"];
            string password = ConfigurationManager.AppSettings["Password"];
            int worldNumber = Convert.ToInt32(ConfigurationManager.AppSettings["WorldNumber"]);
            bool showConsole = Convert.ToBoolean(ConfigurationManager.AppSettings["ShowConsole"]);

            _plemionaSettings.Url = plemionaUrl;
            _plemionaSettings.Username = username;
            _plemionaSettings.Password = password;
            _plemionaSettings.WorldNumber = worldNumber;
            _plemionaSettings.ShowConsole = showConsole;
        }
    }
}