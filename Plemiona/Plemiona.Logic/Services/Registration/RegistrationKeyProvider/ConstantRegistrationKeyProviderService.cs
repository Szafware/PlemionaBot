using System.Collections.Generic;
using System.Linq;

namespace Plemiona.Logic.Services.Registration.RegistrationKeyProvider
{
    public class ConstantRegistrationKeyProviderService : IRegistrationKeyProviderService
    {
        private readonly List<string> _registratedKeys = new List<string>
        {
            "BFEBFBFFBSS-0123456789000906EA", // My key
        };

        public IEnumerable<string> GetRegistratedKeys()
        {
            return _registratedKeys.ToList();
        }
    }
}