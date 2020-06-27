using System;

namespace Plemiona.Core.Exceptions
{
    public class FeatureException : Exception
    {
        public string PlemionaErrorMessage { get; }

        public FeatureException(string plemionaErrorMessage)
        {
            PlemionaErrorMessage = plemionaErrorMessage;
        }
    }
}