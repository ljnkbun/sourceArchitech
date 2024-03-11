using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using Shopfloor.Barcode.Application.Settings;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Enums.LevelLocations;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class LocationRepository : MasterRepositoryAsync<Location>, ILocationRepository
    {

        private readonly DbSet<Location> _location;
        private readonly BarcodeConfig _barcodeConfig;
        public LocationRepository(BarcodeContext dbContext
            , IMapper mapper
            , IOptions<BarcodeConfig> setting

            ) : base(dbContext, mapper)
        {
            _location = dbContext.Set<Location>();
            _barcodeConfig = setting.Value;
        }
        public async Task<Location> GetByBarcodeAsync(string barcode)
        {
            return await _location.FirstOrDefaultAsync(x => x.Barcode == barcode);
        }

        public async Task<bool> IsUniqueBarcodeAsync(string barcode, int? id = null)
        {
            return await _dbContext.Set<Location>().AllAsync(x => x.Barcode != barcode || (x.Id == id && x.Barcode == barcode));
        }
        public async Task<Dictionary<string, int>> GetByCodesAsync(string[] codes)
        {
            return await _dbContext.Set<Location>().Where(x => codes.Contains(x.Code)).ToDictionaryAsync(x => x.Code, x => x.Id);
        }

        public override async Task<Location> AddAsync(Location loc)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await GenCodeAsync(loc);

                await _location.AddAsync(loc);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
                return loc;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                trans.Rollback();
                throw;
            }
        }

        private async Task GenCodeAsync(Location loc)
        {
            var checkExisted = await _location.AnyAsync();
            var lastId = 0;
            if (checkExisted)
            {
                lastId = await _location.MaxAsync(x => x.Id);
            }

            var nextId = (lastId++).ToString();
            var lengthId = _barcodeConfig.BarcodeLength;
            var rs = $"LOC{DateTime.Now:yyyyMMdd}/{nextId.PadLeft(lengthId - nextId.Length, '0')}";
            loc.Barcode = rs;
            loc.Code = rs;
        }

        public async Task<IEnumerable<Location>> GetByIdsAsync(int[] ids)
        {
            var locs = await _location.Where(x => ids.Contains(x.Id)).ToListAsync();
            var childLoc = locs.Where(x => x.LevelLocation > LevelLocation.LevelLocation1);
            var rs = locs.Concat(await _location.Where(x => childLoc.Select(x => x.ParentLocationId).Contains(x.Id)).ToListAsync());
            return rs;
        }
    }
}
