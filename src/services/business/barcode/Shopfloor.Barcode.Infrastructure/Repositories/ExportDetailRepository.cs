using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ExportDetailRepository : MasterRepositoryAsync<ExportDetail>, IExportDetailRepository
    {
        private readonly DbSet<ExportDetail> _ExportDetailSet;
        public ExportDetailRepository(BarcodeContext dbContext
            , IMapper mapper
            ) : base(dbContext, mapper)
        {
            _ExportDetailSet = _dbContext.Set<ExportDetail>();
        }

        public override async Task<ExportDetail> GetByIdAsync(int id)
        {
            return await _ExportDetailSet.Include(x => x.ArticleBarcode).Include(x => x.ExportArticle).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<ExportDetail>> GetByIdsAsync(int[] ids)
        {
            return await _ExportDetailSet.Include(x => x.ArticleBarcode).Include(x => x.ExportArticle).Where(x => ids.Contains(x.Id)).ToListAsync();
        }

    }
}
