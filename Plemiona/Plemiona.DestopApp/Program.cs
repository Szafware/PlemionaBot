using Plemiona.Core.Configuration;
using Plemiona.Core.Features;
using Plemiona.Core.Interfaces.Features;
using Plemiona.Core.Services.FeatureLogging;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Services.WebDriverProvider;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Services.StepProvider;
using Plemiona.Core.Steps.WebDriverBase;
using Plemiona.DependencyInjection;
using Plemiona.DestopApp.Forms;
using Plemiona.Logic.Services.PlemionaSettingsInitialization;
using Plemiona.Logic.Services.WindowsPosition;
using System;
using System.Windows.Forms;

namespace Plemiona.DestopApp
{
    public static class Program
    {
        private static readonly IContainer _container = new NInjectContainer();

        [STAThread]
        public static void Main()
        {
            Binding();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var frmMain = _container.GetImplementation<FrmMain>();

            Application.Run(frmMain);
        }

        private static void Binding()
        {
            _container.BindToSelf<FrmMain>();

            _container.BindToSelfAsSingleton<PlemionaSettings>();
            _container.BindAsSingleton<IWebDriverProviderService, SeleniumWebDriverProviderService>();
            _container.Bind<IPlemionaFeatures, PlemionaDefaultFeatures>();
            _container.Bind<IWebDriverBaseMethodsService, WebDriverBaseMethodsService>();
            _container.Bind<IPlemionaMetadataProviderService, PlemionaMetadataProviderService>();

            _container.Bind<IStepProviderService, StepProviderService>();
            _container.BindAsSingleton<IStepDelayService, ConstantStepDelayService>();
            _container.BindAsSingleton<ITypingDelayService, RandomTypingDelayService>();
            _container.Bind<IFeatureLoggingService, FeatureLoggingService>();

            _container.Bind<IWindowsPositionService, WindowsPositionService>();
            _container.Bind<IPlemionaSettingsInitializationService, PlemionaSettingsInitializationService>();
        }
    }
}