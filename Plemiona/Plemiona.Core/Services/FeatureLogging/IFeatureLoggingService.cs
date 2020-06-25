using System;

namespace Plemiona.Core.Services.FeatureLogging
{
    public interface IFeatureLoggingService
    {
        void LogException(Exception e);
    }
}