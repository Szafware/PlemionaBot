namespace Plemiona.Core.Steps.Services.Delay.Step
{
    public interface ITypingDelayService
    {
        void Configure(int mminimumMilliseconds, int maximumMilliseconds);

        void Delay();
    }
}