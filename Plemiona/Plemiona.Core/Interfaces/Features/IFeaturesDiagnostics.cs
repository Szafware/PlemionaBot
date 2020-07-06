using Plemiona.Core.Enums;
using System;

namespace Plemiona.Core.Interfaces.Features
{
    public interface IFeaturesDiagnostics
    {
        event Action<int> OnStepDelay;
        
        event Action<string, DateTime> OnStepStart;

        event Action<string, DateTime, long, bool> OnStepEnd;

        event Action<string, DateTime> OnFeatureStart;

        event Action<string, DateTime, long, FeatureResults> OnFeatureEnd;
    }
}