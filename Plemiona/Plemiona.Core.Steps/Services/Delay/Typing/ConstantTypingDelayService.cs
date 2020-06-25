using System;
using System.Threading;

namespace Plemiona.Core.Steps.Services.Delay.Step
{
    public class ConstantTypingDelayService : ITypingDelayService
    {
        private int _millisecondDelay = 500;

        public void Configure(int minimumMilliseconds, int maximumMilliseconds)
        {
            if (minimumMilliseconds != maximumMilliseconds)
            {
                throw new Exception("Constant value delay requires both minimum milliseconds and maximum milliseconds of the same value.");
            }

            _millisecondDelay = maximumMilliseconds;
        }

        public void Delay()
        {
            Thread.Sleep(_millisecondDelay);
        }
    }
}