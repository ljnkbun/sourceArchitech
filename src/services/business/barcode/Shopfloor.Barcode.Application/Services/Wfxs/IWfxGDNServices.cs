using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Services.Wfxs
{
    public interface IWfxGDNServices
    {
        Task<IReadOnlyList<WfxGDN>> GetGDNsAsync();
    }
}
