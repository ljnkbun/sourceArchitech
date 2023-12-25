using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NPOI.Util;
using Shopfloor.Barcode.Application.Settings;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ArticleBarcodeRepository : GenericRepositoryAsync<ArticleBarcode>, IArticleBarcodeRepository
    {
        private readonly DbSet<ArticleBarcode> _articleBarCodeSet;
        private readonly DbSet<BarcodeLocation> _barCodeLocation;
        private readonly DbSet<ArticleBarcodeHistory> _barCodeHistory;
        private readonly BarcodeConfig _barcodeConfig;

        public ArticleBarcodeRepository(BarcodeContext dbContext
            , IMapper mapper
            , IOptions<BarcodeConfig> setting
            ) : base(dbContext, mapper)
        {
            _articleBarCodeSet = dbContext.Set<ArticleBarcode>();
            _barCodeLocation = dbContext.Set<BarcodeLocation>();
            _barCodeHistory = dbContext.Set<ArticleBarcodeHistory>();
            _barcodeConfig = setting.Value;
        }

        public override async Task<ArticleBarcode> GetByIdAsync(int id)
        {
            return await _articleBarCodeSet.Include(x => x.ImportDetails).Include(x => x.ExportDetails).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ArticleBarcode> GetByBarcodeAsync(string barcode)
        {
            return await _articleBarCodeSet.Include(x => x.ImportDetails).Include(x => x.ExportDetails).FirstOrDefaultAsync(x => x.Barcode == barcode);
        }

        public async Task<bool> IsUniqueBarcodeAsync(string barcode, int? id = null)
        {
            return await _articleBarCodeSet.AllAsync(x => x.Barcode != barcode || (x.Id == id && x.Barcode == barcode));
        }
        public async Task UpdateArticleBarcodeLocationAsync(ArticleBarcode articleBarcode, BarcodeLocation barcodeLocation)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _articleBarCodeSet.Update(articleBarcode);
                _barCodeLocation.Add(barcodeLocation);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<ICollection<ArticleBarcode>> GetByIdsAsync(ICollection<int> ids)
        {
            return await _articleBarCodeSet.Include(x => x.ImportDetails).Include(x => x.ExportDetails).Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task SplitImportBarcodeDetail(ArticleBarcode entity, List<ArticleBarcode> splitBarcodes)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var checkExisted = await _articleBarCodeSet.AnyAsync();
                var lastId = 0;
                if (checkExisted)
                {
                    lastId = await _articleBarCodeSet.MaxAsync(x => x.Id);
                }

                var splitHis = new List<ArticleBarcodeHistory>();

                foreach (var splitBarcode in splitBarcodes)
                {
                    var nextId = (lastId++).ToString();
                    var lengthId = _barcodeConfig.BarcodeLength;
                    var rs = $"{splitBarcode.UOM}{DateTime.Now:yyyyMMdd}/{nextId.PadLeft(lengthId - nextId.Length, '0')}";
                    splitBarcode.Barcode = rs;
                    splitBarcode.RemainQuantity = splitBarcode.Quantity;
                }

                entity.RemainQuantity = entity.Quantity - splitBarcodes.FirstOrDefault().Quantity;
                await UpdateAsync(entity);

                splitBarcodes.RemoveAt(0);
                await _articleBarCodeSet.AddRangeAsync(splitBarcodes);

                foreach (var splitBarcode in splitBarcodes)
                {
                    splitHis.Add(new() { MergeSplitType = MergeSplitType.Split, FromId = entity.Id, ToId = splitBarcode.Id });
                }

                await _barCodeHistory.AddRangeAsync(splitHis);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task MergeImportBarcodeDetail(ICollection<ArticleBarcode> splitBarcodes)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var entity = splitBarcodes.FirstOrDefault().Copy();
                entity.Id = 0;
                entity.ImportDetails = null;
                entity.ExportDetails = null;

                var checkExisted = await _articleBarCodeSet.AnyAsync();
                var lastId = 0;
                if (checkExisted)
                {
                    lastId = await _articleBarCodeSet.MaxAsync(x => x.Id);
                }

                var nextId = (lastId++).ToString();
                var lengthId = _barcodeConfig.BarcodeLength;
                var rs = $"{splitBarcodes.FirstOrDefault().UOM}{DateTime.Now:yyyyMMdd}/{nextId.PadLeft(lengthId - nextId.Length, '0')}";
                entity.Barcode = rs;

                entity.Quantity = splitBarcodes.Sum(x => x.Quantity);
                entity.RemainQuantity = splitBarcodes.Sum(x => x.RemainQuantity);
                entity.NumberOfCone = splitBarcodes.Sum(x => x.NumberOfCone);
                entity.WeightPerCone = splitBarcodes.Sum(x => x.WeightPerCone);

                entity = await AddAsync(entity);

                var splitHis = new List<ArticleBarcodeHistory>();

                foreach (var splitBarcode in splitBarcodes)
                {
                    splitHis.Add(new() { MergeSplitType = MergeSplitType.Merge, FromId = splitBarcode.Id, ToId = entity.Id });
                }

                await _barCodeHistory.AddRangeAsync(splitHis);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public Task<Dictionary<string, ArticleBarcode>> GetByBarCodesAsync(string[] barCodes)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<int, ArticleBarcode>> GetByBarIdsAsync(int[] ids)
        {
            throw new NotImplementedException();
        }
    }
}
