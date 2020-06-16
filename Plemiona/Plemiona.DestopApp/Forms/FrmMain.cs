using Plemiona.Core.Enums;
using Plemiona.Core.Interfaces;
using Plemiona.Core.Models;
using Plemiona.Core.WebDriver;
using Plemiona.Logic.Services.PlemionaSettingsInitialization;
using Plemiona.Logic.Services.WindowsPosition;
using System;
using System.Configuration;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace Plemiona.DestopApp.Forms
{
    public partial class FrmMain : Form
    {
        private readonly IPlemionaFeatures _plemionaFeatures;
        private readonly IWebDriverProvider _webDriverProvider;

        private readonly IWindowsPositionService _windowsPositionService;
        private readonly IPlemionaSettingsInitializationService _plemionaSettingsInitializationService;

        public FrmMain(
            IPlemionaFeatures plemionaFeatures,
            IWebDriverProvider webDriverProvider,
            IWindowsPositionService windowsPositionService,
            IPlemionaSettingsInitializationService plemionaSettingsInitializationService)
        {
            InitializeComponent();

            _plemionaFeatures = plemionaFeatures;
            _webDriverProvider = webDriverProvider;
            _windowsPositionService = windowsPositionService;
            _plemionaSettingsInitializationService = plemionaSettingsInitializationService;

            _windowsPositionService.SetMainFormWindow(this);
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            _plemionaSettingsInitializationService.Initialize();

            string username = ConfigurationManager.AppSettings["Username"];
            string password = ConfigurationManager.AppSettings["Password"];
            int worldNumber = Convert.ToInt32(ConfigurationManager.AppSettings["WorldNumber"]);

            _plemionaFeatures.SignIn(username, password, worldNumber);

            var webDriver = _webDriverProvider.CreateWebDriver();

            var browserWindow = webDriver.Manage().Window;

            _windowsPositionService.SetBrowserWindow(browserWindow);
        }
    }
}