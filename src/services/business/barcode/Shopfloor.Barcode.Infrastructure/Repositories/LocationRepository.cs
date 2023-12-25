using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class LocationRepository : MasterRepositoryAsync<Location>, ILocationRepository
    {
        public LocationRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<Location> GetByBarcodeAsync(string barcode)
        {
            return await _dbContext.Set<Location>().FirstOrDefaultAsync(x=> x.Barcode == barcode);
        }

        public async Task<bool> IsUniqueBarcodeAsync(string barcode, int? id = null)
        {
            return await _dbContext.Set<Location>().AllAsync(x => x.Barcode != barcode || (x.Id == id && x.Barcode == barcode));
        }
        public async Task<Dictionary<string, int>> GetByCodesAsync(string[] codes)
        {
            return await _dbContext.Set<Location>().Where(x => codes.Contains(x.Code)).ToDictionaryAsync(x => x.Code, x => x.Id);
        }
    }
}
