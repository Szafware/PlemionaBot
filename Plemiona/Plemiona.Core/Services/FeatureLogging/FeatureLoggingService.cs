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

        public void LogException(Exception e)
        {
            try
            {
                var stackTrace = new StackTrace(e);

                var stepFrame = stackTrace.GetFrame(3);
                var stepMethod = stepFrame.GetMethod();
                var stepClassType = stepMethod.DeclaringType;
                string stepClassName = stepClassType.Name;

                var featureFrame = stackTrace.GetFrame(4);
                var featureMethod = featureFrame.GetMethod();
                string featureName = featureMethod.Name;

                Log.Error(e, "Feature: {featureName}  |  Step: {stepClassName}", featureName, stepClassName);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Non feature exception");
            }
        }
    }
}