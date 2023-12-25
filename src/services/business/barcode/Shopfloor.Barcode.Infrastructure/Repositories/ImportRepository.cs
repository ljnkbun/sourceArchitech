using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ImportRepository : MasterRepositoryAsync<Import>, IImportRepository
    {
        private readonly DbSet<Import> _imports;
        private readonly DbSet<ImportArticle> _importArticles;
        private readonly DbSet<ImportDetail> _importDetails;
        private readonly DbSet<ArticleBarcode> _articleBarcodes;
        public ImportRepository(BarcodeContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _imports = _dbContext.Set<Import>();
            _importArticles = _dbContext.Set<ImportArticle>();
            _importDetails = _dbContext.Set<ImportDetail>();
            _articleBarcodes = _dbContext.Set<ArticleBarcode>();
        }
        public async Task<Import> ViewImportByIdAsync(int id)
        {
            return await _imports
                .Include(x => x.ImportArticles)
                .ThenInclude(x => x.ImportDetails)
                .ThenInclude(x => x.ArticleBarcode)
                .Where(x => x.Id == id)
                .Select(import => new Import()
                {
                    Id = import.Id,
                    IsActive= import.IsActive,
                    CreatedDate = import.CreatedDate,
                    ModifiedDate = import.ModifiedDate,
                    CreatedUserId= import.CreatedUserId,
                    ModifiedUserId= import.ModifiedUserId,
                    Code = import.Code,
                    Name = import.Name,
                    Note = import.Note,
                    Status = import.Status,
                    Type = import.Type,
                    ImportArticles = import.ImportArticles.OrderByDescending(x => x.ModifiedDate).Select(article => new ImportArticle()
                    {
                        Id = article.Id,
                        IsActive = import.IsActive,
                        CreatedDate = import.CreatedDate,
                        ModifiedDate = import.ModifiedDate,
                        CreatedUserId = import.CreatedUserId,
                        ModifiedUserId = import.ModifiedUserId,
                        ArticleCode = article.ArticleCode,
                        ArticleName = article.ArticleName,
                        GDNNumber = article.GDNNumber,
                        FromSite = article.FromSite,
                        ToSite = article.ToSite,
                        ImportId = article.ImportId,
                        Import = article.Import,
                        SupplierName = article.SupplierName,
                        OrderRefNum = article.OrderRefNum,
                        ColorCode = article.ColorCode,
                        ColorName = article.ColorName,
                        ImportDetails = article.ImportDetails.OrderByDescending(detail => detail.ModifiedDate).ToList(),
                        SizeCode = article.SizeCode,
                        UOM = article.UOM,
                        Units = article.Units,
                        OCNum = article.OCNum,
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }
        public async Task<Import> GetImportByIdAsync(int id)
        {
            return await _imports
                .Include(x => x.ImportArticles)
                .ThenInclude(x => x.ImportDetails)
                .ThenInclude(x => x.ArticleBarcode)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateImportAsync(Import entity, IEnumerable<ImportArticle> modifiedArticles, IEnumerable<ImportArticle> deletedArticles, IEnumerable<ImportDetail> addedDetails, IEnumerable<ImportDetail> modifiedDetails, IEnumerable<ImportDetail> deletedDetails)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var articleBarcodes = deletedDetails.Select(y => y.ArticleBarcode);
                _importDetails.RemoveRange(deletedDetails);
                _articleBarcodes.RemoveRange(articleBarcodes);
                _importArticles.RemoveRange(deletedArticles);

                _importDetails.UpdateRange(modifiedDetails);
                _importArticles.UpdateRange(modifiedArticles);

                _importDetails.AddRange(addedDetails);
                _imports.Update(entity);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception )
            {
                await trans.RollbackAsync();
                throw;
            }
        }
        public async Task DeleteImportAsync(Import entity, IEnumerable<ArticleBarcode> deleteArticleBarcodes)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _imports.Remove(entity);
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

        public async Task AddImportHasBarCodeAsync(Import entity, IEnumerable<ArticleBarcode> modifiedArticleBarcodes)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _articleBarcodes.UpdateRange(modifiedArticleBarcodes);
                _imports.Add(entity);
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
