﻿using Plemiona.Core.Configuration;
using Plemiona.Core.Features;
using Plemiona.Core.Interfaces;
using Plemiona.Core.PlemionaMetadataProvider;
using Plemiona.Core.Steps.Steps;
using Plemiona.Core.Steps.WebDriverBase;
using Plemiona.Core.WebDriver;
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
            _container.BindAsSingleton<IWebDriverProvider, SeleniumWebDriverProvider>();
            _container.Bind<IPlemionaFeatures, PlemionaFeatures>();
            _container.Bind<IPlemionaSteps, PlemionaSteps>();
            _container.Bind<IWebDriverBaseMethodsService, WebDriverBaseMethodsService>();
            _container.Bind<IPlemionaMetadataProviderService, PlemionaMetadataProviderService>();

            _container.Bind<IWindowsPositionService, WindowsPositionService>();
            _container.Bind<IPlemionaSettingsInitializationService, PlemionaSettingsInitializationService>();
        }
    }
}