namespace Plemiona.Core.Steps.Services.Delay.Step
{
    public interface IStepDelayService
    {
        void Configure(int mminimumMilliseconds, int maximumMilliseconds);

        void Delay();
    }
}