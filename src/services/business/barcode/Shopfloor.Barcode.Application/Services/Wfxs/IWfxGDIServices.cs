using Shopfloor.Barcode.Domain.Entities;

namespace Shopfloor.Barcode.Application.Services.Wfxs
{
    public interface IWfxGDIServices
    {
        Task<IReadOnlyList<WfxGDI>> GetGDIsAsync();
    }
}
