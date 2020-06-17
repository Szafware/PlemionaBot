using Plemiona.Core.Models;

namespace Plemiona.Core.PlemionaMetadataProvider
{
    public interface IPlemionaMetadataProviderService
    {
        void Initialize();

        PlemionaMetadata Create();
    }
}