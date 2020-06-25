using Plemiona.Core.Models;

namespace Plemiona.Core.Services.PlemionaMetadataProvider
{
    public interface IPlemionaMetadataProviderService
    {
        void Initialize();

        PlemionaMetadata Create();
    }
}