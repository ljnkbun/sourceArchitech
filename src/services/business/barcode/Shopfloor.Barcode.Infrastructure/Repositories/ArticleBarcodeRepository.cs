using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NPOI.Util;
using Serilog;
using Shopfloor.Barcode.Application.Settings;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
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
                await _barCodeLocation.AddAsync(barcodeLocation);
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

        public async Task<int[]> SplitImportBarcodeDetail(ArticleBarcode entity, List<ArticleBarcode> splitBarcodes)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var count = 1;
                var dbBarcodesByUOM = await _articleBarCodeSet.Where(x => x.Barcode.Contains(entity.Barcode)).ToListAsync();
                var splitHis = new List<ArticleBarcodeHistory>();

                var rs = entity.Barcode + $"/" + count;
                while (dbBarcodesByUOM.Any(x => x.Barcode == rs))
                {
                    rs = entity.Barcode + $"/" + count++;
                }

                foreach (var splitBarcode in splitBarcodes)
                {
                    var lengthId = _barcodeConfig.BarcodeLength;
                    rs = entity.Barcode + $"/" + count++;
                    splitBarcode.Barcode = rs;
                    splitBarcode.Quantity = splitBarcode.Quantity;
                    splitBarcode.RemainQuantity = splitBarcode.Quantity;
                    splitBarcode.FromId = entity.Id.ToString();
                }


                await _articleBarCodeSet.AddRangeAsync(splitBarcodes);

                foreach (var splitBarcode in splitBarcodes)
                {
                    splitHis.Add(new() { MergeSplitType = MergeSplitType.Split, FromId = entity.Id, ToId = splitBarcode.Id });
                }

                await _barCodeHistory.AddRangeAsync(splitHis);

                await _dbContext.SaveChangesAsync();

                if (string.IsNullOrEmpty(entity.ToId))
                    entity.ToId = String.Join(", ", splitBarcodes.Select(x => x.Id));
                else
                    entity.ToId += ", " + String.Join(", ", splitBarcodes.Select(x => x.Id));

                await UpdateAsync(entity);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
                return splitBarcodes.Select(x => x.Id).ToArray();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<ArticleBarcode> MergeImportBarcodeDetail(ICollection<ArticleBarcode> mergeBarcodes)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var entity = mergeBarcodes.FirstOrDefault().Copy();
                entity.Id = 0;
                entity.ToId = null;
                entity.ImportDetails = null;
                entity.ExportDetails = null;

                var checkExisted = await _articleBarCodeSet.AnyAsync();
                var lastId = 0;
                if (checkExisted)
                {
                    lastId = await _articleBarCodeSet.MaxAsync(x => x.Id);
                }

                var str = $@"{mergeBarcodes.FirstOrDefault().BarcodeUOM}{DateTime.Now:yyyyMMdd}/";

                var nextId = (lastId++).ToString();
                var lengthId = _barcodeConfig.BarcodeLength;
                var rs = str + $"{nextId.PadLeft(lengthId - nextId.Length, '0')}";

                var dbBarcodesByUOM = await _articleBarCodeSet.Where(x => x.Barcode.Contains(str)).ToListAsync();

                while (dbBarcodesByUOM.Any(x => x.Barcode == rs))
                {
                    nextId = (lastId++).ToString();
                    rs = str + $"{nextId.PadLeft(lengthId - nextId.Length, '0')}";
                }

                entity.Barcode = rs;

                entity.Quantity = mergeBarcodes.Sum(x => x.Quantity);
                entity.RemainQuantity = mergeBarcodes.Sum(x => x.RemainQuantity);
                entity.NumberOfCone = mergeBarcodes.Sum(x => x.NumberOfCone);
                entity.WeightPerCone = mergeBarcodes.Sum(x => x.WeightPerCone);
                entity.FromId = String.Join(", ", mergeBarcodes.Select(x => x.Id));

                entity = await AddAsync(entity);

                var splitHis = new List<ArticleBarcodeHistory>();

                foreach (var mergeBarcode in mergeBarcodes)
                {
                    splitHis.Add(new() { MergeSplitType = MergeSplitType.Merge, FromId = mergeBarcode.Id, ToId = entity.Id });

                    mergeBarcode.RemainQuantity = 0;
                    mergeBarcode.ToId = entity.Id.ToString();
                }

                _articleBarCodeSet.UpdateRange(mergeBarcodes);
                await _barCodeHistory.AddRangeAsync(splitHis);

                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
                return entity;
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                await trans.RollbackAsync();
                throw;
            }
        }

        public async Task<Dictionary<string, ArticleBarcode>> GetByBarCodesAsync(string[] barCodes)
        {
            return await _articleBarCodeSet.Include(x => x.ImportDetails).Include(x => x.ExportDetails).Where(x => barCodes.Contains(x.Barcode)).ToDictionaryAsync(x => x.Barcode);
        }

        public async Task<ICollection<ArticleBarcode>> GetAllByBarcodesAsync(string[] barCodes)
        {
            return await _articleBarCodeSet
                .Include(x => x.ImportDetails)
                .Include(x => x.ExportDetails)
                .Include(x => x.BarcodeLocations)
                .Where(x => barCodes.Contains(x.Barcode)).ToListAsync();
        }

        public async Task<Dictionary<int, ArticleBarcode>> GetByBarIdsAsync(int[] ids)
        {
            return await _articleBarCodeSet.Include(x => x.ImportDetails).Include(x => x.ExportDetails).Where(x => ids.Contains(x.Id)).ToDictionaryAsync(x => x.Id);
        }


        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetModelPagedCustomReponseAsync<TParam, TModel>(TParam parameter, string barcodes, string articleCodes) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);

            var query = _articleBarCodeSet.Filter(parameter);
            query = query.Where(x => x.IsActive == true);
            query = query.Where(x => x.RemainQuantity > 0);
            if (!string.IsNullOrEmpty(barcodes))
            {
                var barcodeArr = barcodes.Split(',').Select(x => x.Trim());
                query = query.Where(x => barcodeArr.Contains(x.Barcode));
            }
            if (!string.IsNullOrEmpty(articleCodes))
            {
                var articleCodeAr = articleCodes.Split(',').Select(x => x.Trim());
                query = query.Where(x => articleCodeAr.Contains(x.ArticleCode));
            }

            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                    .OrderBy(parameter.OrderBy)
                    .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                    .Paged(parameter.PageSize, parameter.PageNumber)
                    .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            return response;
        }

        public async Task<bool> UpdateArticleBarcodesLocationAsync(ICollection<ArticleBarcode> entities, ICollection<BarcodeLocation> newBarcodeLocations)
        {
            var rs = false;
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _articleBarCodeSet.UpdateRange(entities);
                await _barCodeLocation.AddRangeAsync(newBarcodeLocations);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
                return rs=true;
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                return rs;
            }
        }
    }
}
