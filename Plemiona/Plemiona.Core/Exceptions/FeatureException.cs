using System;

namespace Plemiona.Core.Exceptions
{
    public class FeatureException : Exception
    {
        public bool PlemionaError { get; }

        public string PlemionaErrorMessage { get; }

        public FeatureException(bool plemionaError, string plemionaErrorMessage)
        {
            PlemionaError = plemionaError;
            PlemionaErrorMessage = plemionaErrorMessage;
        }
    }
}