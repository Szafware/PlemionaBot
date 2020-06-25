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
using System.Configuration;
using System.Windows.Forms;

namespace Plemiona.DestopApp
{
    public static class Program
    {
        private static readonly IContainer _container = new NInjectContainer();

        [STAThread]
        public static void Main()
        {
            try
            {
                Binding();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var frmMain = _container.GetImplementation<FrmMain>();

                Application.Run(frmMain);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            bool randomStepDelay = Convert.ToBoolean(ConfigurationManager.AppSettings["RandomStepDelay"]);
            bool constantStepDelay = Convert.ToBoolean(ConfigurationManager.AppSettings["ConstantStepDelay"]);
            bool randomTypingDelay = Convert.ToBoolean(ConfigurationManager.AppSettings["RandomTypingDelay"]);
            bool constantTypingDelay = Convert.ToBoolean(ConfigurationManager.AppSettings["ConstantTypingDelay"]);
            
            if ((randomStepDelay && constantStepDelay) || 
                ((!randomStepDelay) && (!constantStepDelay)) ||
                (randomTypingDelay && constantTypingDelay) ||
                ((!randomTypingDelay) && (!constantTypingDelay)))
            {
                throw new Exception("Incorrect delay configuration. Make sure that Plemiona.DesktopApp.exe.config file contains exactly one StepDelay option is set to true, and also exactly one TypingDelay option is set to true.");
            }

            var stepDelayServiceType = randomStepDelay ? typeof(RandomStepDelayService) : typeof(ConstantStepDelayService);
            var typingDelayServiceType = randomTypingDelay ? typeof(RandomTypingDelayService) : typeof(ConstantTypingDelayService);

            _container.BindAsSingleton<IStepDelayService>(stepDelayServiceType);
            _container.BindAsSingleton<ITypingDelayService>(typingDelayServiceType);
            _container.Bind<IFeatureLoggingService, FeatureLoggingService>();

            _container.Bind<IWindowsPositionService, WindowsPositionService>();
            _container.Bind<IPlemionaSettingsInitializationService, PlemionaSettingsInitializationService>();
        }
    }
}