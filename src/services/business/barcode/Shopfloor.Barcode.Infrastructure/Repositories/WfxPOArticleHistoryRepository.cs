using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class WfxPOArticleHistoryRepository : GenericRepositoryAsync<WfxPOArticleHistory>, IWfxPOArticleHistoryRepository
    {
        private readonly DbSet<WfxPOArticleHistory> _wfxPOArticleHistories;
        private readonly DbSet<WfxPOArticle> _wfxPOArticles;
        private readonly DbSet<ImportDetail> _importDetail;
        private readonly DbSet<ArticleBarcode> _articleBarcodes;
        private readonly DbSet<Location> _locations;
        public WfxPOArticleHistoryRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _wfxPOArticleHistories = dbContext.Set<WfxPOArticleHistory>();
            _wfxPOArticles = dbContext.Set<WfxPOArticle>();
            _importDetail = dbContext.Set<ImportDetail>();
            _articleBarcodes = dbContext.Set<ArticleBarcode>();
            _locations = dbContext.Set<Location>();
        }

        public async Task<ICollection<WfxPOArticleHistory>> GetByWfxPOIdAsync(int[] wfxPOIds)
        {
            return await _wfxPOArticleHistories.Where(x => wfxPOIds.Contains(x.Id)).ToListAsync();
        }
    }
}
