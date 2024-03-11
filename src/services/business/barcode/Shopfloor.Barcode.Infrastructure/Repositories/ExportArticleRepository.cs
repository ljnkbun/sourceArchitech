using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ExportArticleRepository : MasterRepositoryAsync<ExportArticle>, IExportArticleRepository
    {
        private readonly DbSet<ExportArticle> _exportArticles;
        private readonly DbSet<ExportDetail> _exportDetails;
        private readonly DbSet<ArticleBarcode> _articleBarcodes;
        public ExportArticleRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _exportArticles = _dbContext.Set<ExportArticle>();
            _exportDetails = _dbContext.Set<ExportDetail>();
            _articleBarcodes = _dbContext.Set<ArticleBarcode>();
        }

        public async Task<ICollection<ExportArticle>> GetByIdsAsync(int[] ids)
        {
            return await _exportArticles.Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<List<ExportArticle>> GetExportArticleByExportIds(int[] ids)
        {
            return await _exportArticles.Where(x => ids.Contains(x.ExportId)).ToListAsync();

        }

        public async Task<ExportArticle> GetExportArticleByIdAsync(int id)
        {
            return await _exportArticles.Include(x => x.ExportDetails).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateExportArticleAsync(ExportArticle entity, IEnumerable<ExportDetail> addedDetails, IEnumerable<ExportDetail> modifiedDetails, IEnumerable<ExportDetail> deletedDetails)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {

                var articleBarcodes = deletedDetails.Select(y => y.ArticleBarcode);
                _exportDetails.RemoveRange(deletedDetails);
                _articleBarcodes.RemoveRange(articleBarcodes);
                _exportDetails.UpdateRange(modifiedDetails);
                _exportDetails.AddRange(addedDetails);
                _exportArticles.Update(entity);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }

    }
}
