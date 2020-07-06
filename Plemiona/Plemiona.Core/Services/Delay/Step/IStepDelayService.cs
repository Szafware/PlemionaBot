using System;

namespace Plemiona.Core.Services.Delay.Step
{
    public interface IStepDelayService
    {
        event Action<int> OnDelay;

        void Configure(int mminimumMilliseconds, int maximumMilliseconds);

        void Delay();
    }
}