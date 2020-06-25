using Plemiona.Core.Interfaces.Features;
using Plemiona.Core.Services.WebDriverProvider;
using Plemiona.Core.Steps.Services.Delay;
using Plemiona.Logic.Services.PlemionaSettingsInitialization;
using Plemiona.Logic.Services.WindowsPosition;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plemiona.DestopApp.Forms
{
    public partial class FrmMain : Form
    {
        private readonly IPlemionaFeatures _plemionaFeatures;
        private readonly IWebDriverProviderService _webDriverProviderService;

        private readonly IWindowsPositionService _windowsPositionService;
        private readonly IPlemionaSettingsInitializationService _plemionaSettingsInitializationService;
        private readonly IDelayService _delayService;

        public FrmMain(
            IPlemionaFeatures plemionaFeatures,
            IWebDriverProviderService webDriverProviderService,
            IWindowsPositionService windowsPositionService,
            IPlemionaSettingsInitializationService plemionaSettingsInitializationService,
            IDelayService delayService)
        {
            InitializeComponent();

            _plemionaFeatures = plemionaFeatures;
            _webDriverProviderService = webDriverProviderService;
            _windowsPositionService = windowsPositionService;
            _plemionaSettingsInitializationService = plemionaSettingsInitializationService;
            _delayService = delayService;

            _windowsPositionService.SetMainFormWindow(this);

            _delayService.Configure(500, 500);
        }

        private async void FrmMain_Shown(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                _plemionaSettingsInitializationService.Initialize();

                string username = ConfigurationManager.AppSettings["Username"];
                string password = ConfigurationManager.AppSettings["Password"];
                int worldNumber = Convert.ToInt32(ConfigurationManager.AppSettings["WorldNumber"]);

                _plemionaFeatures.SignIn(username, password, worldNumber);

                var webDriver = _webDriverProviderService.CreateWebDriver();

                var browserWindow = webDriver.Manage().Window;

                _windowsPositionService.SetBrowserWindow(browserWindow);
            });
        }
    }
}