using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class WfxGDIHistoryRepository : GenericRepositoryAsync<WfxGDIHistory>, IWfxGDIHistoryRepository
    {
        private readonly DbSet<WfxGDIHistory> _wfxGDIHistories;
        private readonly DbSet<WfxGDI> _wfxGDIs;
        private readonly DbSet<ExportDetail> _exportDetails;
        private readonly DbSet<ArticleBarcode> _articleBarcodes;
        private readonly DbSet<Location> _locations;
        public WfxGDIHistoryRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _wfxGDIHistories = dbContext.Set<WfxGDIHistory>();
            _wfxGDIs = dbContext.Set<WfxGDI>();
            _exportDetails = dbContext.Set<ExportDetail>();
            _articleBarcodes = dbContext.Set<ArticleBarcode>();
            _locations = dbContext.Set<Location>();
        }

        public async Task<ICollection<WfxGDIHistory>> GetByWfxGDIIdAsync(int[] wfxGDIIds)
        {
            return await _wfxGDIHistories.Where(x => wfxGDIIds.Contains(x.WfxGDIId.Value)).ToListAsync();
        }
    }

}
