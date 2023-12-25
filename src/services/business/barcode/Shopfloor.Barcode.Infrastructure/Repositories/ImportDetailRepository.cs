using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shopfloor.Barcode.Application.Settings;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ImportDetailRepository : GenericRepositoryAsync<ImportDetail>, IImportDetailRepository
    {
        private readonly DbSet<ImportDetail> _importDetails;
        private readonly DbSet<ImportArticle> _importImportArticles;
        private readonly DbSet<ArticleBarcode> _articleBarcodes;
        private readonly BarcodeConfig _barcodeConfig;
        public ImportDetailRepository(BarcodeContext dbContext, IMapper mapper, IOptions<BarcodeConfig> setting) : base(dbContext, mapper)
        {
            _importDetails = _dbContext.Set<ImportDetail>();
            _importImportArticles = _dbContext.Set<ImportArticle>();
            _articleBarcodes = _dbContext.Set<ArticleBarcode>();
            _barcodeConfig = setting.Value;
        }
        public async Task<ImportDetail> GetImportDetailByIdAsync(int id)
        {
            return await _importDetails.AsNoTracking()
                .Include(x => x.ArticleBarcode)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task DeleteImportTransferToSiteDetaiAsync(ImportDetail entity)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _importDetails.Remove(entity);
                _articleBarcodes.Remove(entity.ArticleBarcode);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }
        public async Task<List<ImportDetail>> GetByIdsAsync(int[] ids)
        {
            return await _importDetails.Include(x => x.ArticleBarcode).Where(x => ids.Contains(x.Id)).ToListAsync();
        }
        public async Task<List<TModel>> PrintImportDetail<TModel>(int[] ids)
        {
            return await _importDetails.Where(x => ids.Contains(x.Id))
                .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        public async Task DeleteImportTransferToSiteDetaisAsync(List<ImportDetail> importTransferToSiteDetails)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                foreach (var item in importTransferToSiteDetails)
                {
                    var articleBarcode = item.ArticleBarcode;
                    _importDetails.Remove(item);
                    _articleBarcodes.Remove(articleBarcode);
                }

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }
        public async Task<ICollection<ArticleBarcode>> GenBarCode(string UOM, ICollection<ImportDetail> details)
        {
            if (string.IsNullOrEmpty(UOM)) return null;

            var barcodes = new List<ArticleBarcode>();

            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var checkExisted = await _articleBarcodes.AnyAsync();
                var lastId = 0;
                if (checkExisted)
                {
                    lastId = await _articleBarcodes.MaxAsync(x => x.Id);
                }

                foreach (var detail in details)
                {
                    var nextId = (lastId++).ToString();
                    var lengthId = _barcodeConfig.BarcodeLength;
                    var rs = $"{UOM}{DateTime.Now:yyyyMMdd}/{nextId.PadLeft(lengthId - nextId.Length, '0')}";

                    var barcode = new ArticleBarcode()
                    {
                        Barcode = rs,
                        RemainQuantity = detail.Quantity,
                        Quantity = detail.Quantity,
                        Location = detail.Location,
                        ArticleName = detail.ArticleName,
                        ArticleCode = detail.ArticleCode,
                        Color = detail.Color,
                        IsActive = detail.IsActive,
                        Note = detail.Note,
                        NumberOfCone = detail.NumberOfCone,
                        OC = detail.OC,
                        Shade = detail.Shade,
                        Size = detail.Size,
                        Unit = detail.Unit,
                        UOM = detail.UOM,
                        WeightPerCone = detail.WeightPerCone,
                    };

                    barcodes.Add(barcode);
                    detail.ArticleBarcode = barcode;
                }

                await _articleBarcodes.AddRangeAsync(barcodes);
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
            return barcodes;
        }
        public async Task<ImportType?> GetImportTypeByIdImportArticleId(int id)
        {
            return await _importImportArticles.Where(x => x.Id == id).Select(x => x.Import.Type).FirstOrDefaultAsync();

        }
        public async Task AddImportDetailHasBarCodeAsync(ImportDetail entity, ArticleBarcode modifiedArticleBarcode)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _articleBarcodes.Update(modifiedArticleBarcode);
                _importDetails.Add(entity);
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
