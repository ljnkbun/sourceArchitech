using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class WfxGDNHistoryRepository : GenericRepositoryAsync<WfxGDNHistory>, IWfxGDNHistoryRepository
    {
        private readonly DbSet<WfxGDNHistory> _wfxGDNHistories;
        private readonly DbSet<WfxGDN> _wfxGDNs;
        private readonly DbSet<ExportDetail> _exportDetails;
        private readonly DbSet<ArticleBarcode> _articleBarcodes;
        private readonly DbSet<Location> _locations;
        public WfxGDNHistoryRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _wfxGDNHistories = dbContext.Set<WfxGDNHistory>();
            _wfxGDNs = dbContext.Set<WfxGDN>();
            _exportDetails = dbContext.Set<ExportDetail>();
            _articleBarcodes = dbContext.Set<ArticleBarcode>();
            _locations = dbContext.Set<Location>();
        }

    }

}
