using Serilog;
using System;
using System.Diagnostics;

namespace Plemiona.Core.Services.FeatureLogging
{
    public class FeatureLoggingService : IFeatureLoggingService
    {
        private readonly string _logFileName = "PlemionaHelpTool.log";

        public FeatureLoggingService()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(_logFileName, outputTemplate: "[{Timestamp:dd-MM-yyyy HH:mm:ss}] {Message:lj}{NewLine}{Exception}{NewLine}")
                .CreateLogger();
        }

        public void LogException(Exception exception, string featureName)
        {
            string stepName = null;

            try
            {
                var stackTrace = new StackTrace(exception);
                
                var stepFrame = stackTrace.GetFrame(3);
                var stepMethod = stepFrame.GetMethod();
                var stepClassType = stepMethod.DeclaringType;
                stepName = stepClassType.Name;
            }
            catch
            {
            }

            Log.Error(exception, "Feature:{featureName}  Step:{stepClassName}", featureName ?? "unknown", stepName ?? "unknown");
        }

        public void LogBotCheck(string featureName, string stepName)
        {
            Log.Warning("BOT CHECK  Feature:{featureName}  Step:{stepName}", featureName ?? "unknown", stepName ?? "unknown");
        }
    }
}