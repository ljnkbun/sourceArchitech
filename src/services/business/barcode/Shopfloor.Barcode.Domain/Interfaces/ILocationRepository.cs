using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Domain.Interfaces
{
    public interface ILocationRepository : IMasterRepositoryAsync<Location>
    {
        Task<bool> IsUniqueBarcodeAsync(string barcode, int? id = null);
        Task<Location> GetByBarcodeAsync(string barcode);
        Task<Dictionary<string, int>> GetByCodesAsync(string[] codes);
    }
}
