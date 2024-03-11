using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Exceptions;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class AppVersionRepository : GenericRepositoryAsync<AppVersion>, IAppVersionRepository
    {
        public AppVersionRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<AppVersion> GetLastVersion() => await _dbContext.Set<AppVersion>()
            .OrderByDescending(x => x.Version).FirstOrDefaultAsync();
    }
}