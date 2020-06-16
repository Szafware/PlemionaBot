using System;

namespace Plemiona.Core.Steps.Exceptions
{
    public class StepException : Exception
    {
        public StepException()
        {
        }

        public StepException(string message) : base(message)
        {
        }

        public StepException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}