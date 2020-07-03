using System;

namespace Plemiona.Core.Exceptions
{
    public class BotCheckException : Exception
    {
        public string CurrentStep { get; }

        public BotCheckException(string currentStep)
        {
            CurrentStep = currentStep;
        }
    }
}