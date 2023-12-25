using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ExportArticleRepository : MasterRepositoryAsync<ExportArticle>, IExportArticleRepository
    {
        private readonly DbSet<ExportArticle> _ExportArticles;
        private readonly DbSet<ExportDetail> _ExportDetails;
        public ExportArticleRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _ExportArticles = _dbContext.Set<ExportArticle>();
            _ExportDetails = _dbContext.Set<ExportDetail>();
        }

        public async Task<ExportArticle> GetExportArticleByIdAsync(int id)
        {
            return await _ExportArticles.Include(x => x.ExportDetails).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateExportArticleAsync(ExportArticle entity, IEnumerable<ExportDetail> deleteDetails)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _ExportDetails.RemoveRange(deleteDetails);
                _ExportArticles.Update(entity);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                Log.Error(ex.Message, ex);
            }
        }
    }
}
