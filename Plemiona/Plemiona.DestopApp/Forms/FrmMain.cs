using Plemiona.Core.Interfaces;
using Plemiona.Core.WebDriver;
using Plemiona.Logic.Services;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Plemiona.DestopApp.Forms
{
    public partial class FrmMain : Form
    {
        private readonly IPlemionaFeatures _plemionaFeatures;
        private readonly IWebDriverProvider _webDriverProvider;

        private readonly IWindowsPositionService _windowsPositionService;

        public FrmMain(
            IPlemionaFeatures plemionaFeatures,
            IWebDriverProvider webDriverProvider,
            IWindowsPositionService windowsPositionService)
        {
            InitializeComponent();

            _plemionaFeatures = plemionaFeatures;
            _webDriverProvider = webDriverProvider;
            _windowsPositionService = windowsPositionService;           
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            string username = ConfigurationManager.AppSettings["Username"];
            string password = ConfigurationManager.AppSettings["Password"];
            int worldNumber = Convert.ToInt32(ConfigurationManager.AppSettings["WorldNumber"]);

            _plemionaFeatures.SignIn(username, password, worldNumber);

            var webDriver = _webDriverProvider.CreateWebDriver();

            var browserWindow = webDriver.Manage().Window;

            _windowsPositionService.SetWindowsPosition(this, browserWindow);
        }
    }
}