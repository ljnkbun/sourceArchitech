using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ImportArticleRepository : GenericRepositoryAsync<ImportArticle>, IImportArticleRepository
    {
        private readonly DbSet<ImportArticle> _importArticles;
        private readonly DbSet<ImportDetail> _importDetails;
        private readonly DbSet<ArticleBarcode> _articleBarcodes;
        private readonly DbSet<Import> _imports;
        public ImportArticleRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _imports = _dbContext.Set<Import>();
            _importArticles = _dbContext.Set<ImportArticle>();
            _importDetails = _dbContext.Set<ImportDetail>();
            _articleBarcodes = _dbContext.Set<ArticleBarcode>();
        }
        public async Task<ImportArticle> GetImportArticleByIdAsync(int id)
        {
            return await _importArticles
                .Include(x => x.ImportDetails)
                .ThenInclude(x => x.ArticleBarcode)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<ImportArticle>> GetImportArticleByIdsAsync(int[] ids)
        {
            return await _importArticles
                .Include(x => x.ImportDetails)
                .ThenInclude(x => x.ArticleBarcode)
                .Where(x => ids.Any(y=>y==x.Id)).ToListAsync();
        }
        public async Task UpdateImportArticleAsync(ImportArticle entity, IEnumerable<ImportDetail> addedDetails, IEnumerable<ImportDetail> modifiedDetails, IEnumerable<ImportDetail> deletedDetails)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {

                var articleBarcodes = deletedDetails.Select(y => y.ArticleBarcode);
                _importDetails.RemoveRange(deletedDetails);
                _articleBarcodes.RemoveRange(articleBarcodes); 
                _importDetails.UpdateRange(modifiedDetails);
                _importDetails.AddRange(addedDetails);
                _importArticles.Update(entity);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception )
            {
                await trans.RollbackAsync();
                throw;
            }
        }
        public async Task DeleteImportArticleAsync(ImportArticle entity, IEnumerable<ArticleBarcode> deleteArticleBarcodes)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _importArticles.Remove(entity);
                _articleBarcodes.RemoveRange(deleteArticleBarcodes);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception )
            {
                await trans.RollbackAsync();
                throw;
            }
        }
        public async Task<ImportType?> GetImportTypeByIdImportId(int id)
        {
            return await _imports.Where(x => x.Id == id).Select(x => x.Type).FirstOrDefaultAsync();
                
        }
        public async Task AddImportArticleHasBarCodeAsync(ImportArticle entity, IEnumerable<ArticleBarcode> modifiedArticleBarcodes)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _articleBarcodes.UpdateRange(modifiedArticleBarcodes);
                _importArticles.Add(entity);
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
