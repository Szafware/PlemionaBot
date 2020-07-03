using System.Collections.Generic;

namespace Plemiona.Logic.Services.Registration.RegistrationKeyProvider
{
    public interface IRegistrationKeyProviderService
    {
        IEnumerable<string> GetRegistratedKeys();
    }
}