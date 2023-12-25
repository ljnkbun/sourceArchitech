using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ImportTransferToSiteSyncRepository : GenericRepositoryAsync<ImportTransferToSiteSync>, IImportTransferToSiteSyncRepository
    {
        public ImportTransferToSiteSyncRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }
        public async Task<ImportTransferToSiteSync> GetByGDNNoAsync(string gdnNo)
        {
            return await _dbContext.Set<ImportTransferToSiteSync>().FirstOrDefaultAsync(x=> x.GDNNo == gdnNo);
        }

    }
}
