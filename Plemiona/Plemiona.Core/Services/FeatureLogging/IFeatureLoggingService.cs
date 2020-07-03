using System;

namespace Plemiona.Core.Services.FeatureLogging
{
    public interface IFeatureLoggingService
    {
        void LogException(Exception exception, string featureName);

        void LogBotCheck(string featureName, string stepName);
    }
}