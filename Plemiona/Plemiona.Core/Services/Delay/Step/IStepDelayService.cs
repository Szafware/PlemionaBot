namespace Plemiona.Core.Services.Delay.Step
{
    public interface IStepDelayService
    {
        void Configure(int mminimumMilliseconds, int maximumMilliseconds);

        void Delay();
    }
}