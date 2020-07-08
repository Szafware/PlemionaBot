using System.Collections.Generic;
using System.Linq;

namespace Plemiona.Logic.Services.Registration.RegistrationKeyProvider
{
    public class ConstantRegistrationKeyProviderService : IRegistrationKeyProviderService
    {
        private readonly List<string> _registratedKeys = new List<string>
        {
            "BFEBFBFFBSS-0123456789000906EA", // Ja
            "BFEBFBFFPF0DT3P8000506E3", // Marcel
            "BFEBFBFF/7M1WYN1/CN1296117A0540/000206A7", // Sawczi
        };

        public IEnumerable<string> GetRegistratedKeys()
        {
            return _registratedKeys.ToList();
        }
    }
}