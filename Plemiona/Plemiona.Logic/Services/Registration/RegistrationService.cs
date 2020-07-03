using Plemiona.Logic.Services.Registration.RegistrationKeyProvider;
using Plemiona.Logic.Services.Registration.UniqueMachineKey;
using System.Linq;

namespace Plemiona.Logic.Services.Registration
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IRegistrationKeyProviderService _registrationKeyProviderService;
        private readonly IUniqueMachineKeyService _uniqueMachineKeyService;

        public RegistrationService(
            IRegistrationKeyProviderService registrationKeyProviderService,
            IUniqueMachineKeyService uniqueMachineKeyService)
        {
            _registrationKeyProviderService = registrationKeyProviderService;
            _uniqueMachineKeyService = uniqueMachineKeyService;
        }

        public bool IsCurrentMachineRegistrated()
        {
            string currentMachineKey = _uniqueMachineKeyService.GetKey();

            var registratedKeys = _registrationKeyProviderService.GetRegistratedKeys();

            bool isRegistrationKeyValid = registratedKeys.Contains(currentMachineKey);

            return isRegistrationKeyValid;
        }
    }
}