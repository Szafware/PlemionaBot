using Plemiona.Core.Steps.Models;

namespace Plemiona.Core.Steps.Services.PlemionaConfigProvider
{
    public interface IPlemionaConfigProviderService
    {
        void Initialize();

        PlemionaConfig Create();
    }
}