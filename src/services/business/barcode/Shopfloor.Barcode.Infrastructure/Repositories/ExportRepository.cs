using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ExportRepository : MasterRepositoryAsync<Export>, IExportRepository
    {
        private readonly DbSet<Export> _Exports;
        private readonly DbSet<ExportArticle> _ExportArticles;
        private readonly DbSet<ExportDetail> _ExportDetails;
        public ExportRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _Exports = _dbContext.Set<Export>();
            _ExportArticles = _dbContext.Set<ExportArticle>();
            _ExportDetails = _dbContext.Set<ExportDetail>();
        }

        public async Task<Export> GetExportByIdAsync(int id)
        {
            return await _Exports
                .Include(x => x.ExportArticles)
                .ThenInclude(x => x.ExportDetails)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateExportAsync(Export entity, IEnumerable<ExportArticle> deleteArticles, IEnumerable<ExportDetail> deleteDetails)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _ExportDetails.RemoveRange(deleteDetails);
                _ExportArticles.RemoveRange(deleteArticles);

                _Exports.Update(entity);

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
