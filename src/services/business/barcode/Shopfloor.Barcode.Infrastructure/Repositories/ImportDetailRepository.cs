using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using Shopfloor.Barcode.Application.Settings;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Enums.LevelLocations;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Repositories;
using Shopfloor.EventBus.Models.Requests;
using Shopfloor.EventBus.Models.Responses;
using Shopfloor.EventBus.Services;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ImportDetailRepository : GenericRepositoryAsync<ImportDetail>, IImportDetailRepository
    {
        private readonly DbSet<ImportDetail> _importDetails;
        private readonly DbSet<ImportArticle> _importImportArticles;
        private readonly DbSet<ArticleBarcode> _articleBarcodes;
        private readonly DbSet<Location> _locations;
        private readonly BarcodeConfig _barcodeConfig;
        private readonly IRequestClientService _requestClientService;

        public ImportDetailRepository(BarcodeContext dbContext
            , IMapper mapper
            , IOptions<BarcodeConfig> setting
            , IRequestClientService requestClientService
            ) : base(dbContext, mapper)
        {
            _importDetails = _dbContext.Set<ImportDetail>();
            _importImportArticles = _dbContext.Set<ImportArticle>();
            _articleBarcodes = _dbContext.Set<ArticleBarcode>();
            _locations = _dbContext.Set<Location>();
            _barcodeConfig = setting.Value;
            _requestClientService = requestClientService;
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
            return await _importDetails.Include(x => x.ArticleBarcode).Include(x => x.ImportArticle).Where(x => ids.Contains(x.Id)).ToListAsync();
        }

        public async Task<List<TModel>> PrintImportDetail<TModel>(int[] ids, CategoryType categoryType)
        {
            return await _importDetails.Include(x => x.ImportArticle).Include(x => x.ArticleBarcode).Where(x => ids.Contains(x.Id))
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

        public async Task GenBarCode(string UOM, ICollection<ImportArticle> importArticles)
        {
            var checkExisted = await _articleBarcodes.AnyAsync();
            var lastId = 0;
            if (checkExisted)
            {
                lastId = await _articleBarcodes.MaxAsync(x => x.Id);
            }

            MassTransit.Response<GetArticlessResponse> articleReqs = null;
            try
            {
                articleReqs = await _requestClientService.GetResponseAsync<GetArticlessRequest, GetArticlessResponse>(new GetArticlessRequest()
                {
                    ArticleCode = importArticles.SelectMany(x => x.ImportDetails).Select(o => o.ArticleCode).ToList()
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            var articles = articleReqs?.Message?.Data;


            var locations = _locations.Where(x => x.LevelLocation == LevelLocation.LevelLocation1);

            foreach (var importArticle in importArticles)
            {
                if (importArticle.ImportDetails?.Any() ?? false)
                {

                    foreach (var detail in importArticle.ImportDetails)
                    {
                        var article = articles?.FirstOrDefault(x => x.ArticleCode == detail.ArticleCode);

                        if (string.IsNullOrEmpty(detail.UOM))
                        {

                            UOM = (article?.Category) switch
                            {
                                nameof(CategoryType.Fiber) => "BALE",
                                nameof(CategoryType.Yarns) => "BOX",
                                nameof(CategoryType.Fabric) or nameof(CategoryType.TextilesFabric) => "ROLL",
                                _ => "DTL",
                            };
                        }

                        var str = $@"{UOM}{DateTime.Now:yyyyMMdd}/";
                        var dbBarcodesByUOM = await _articleBarcodes.Where(x => x.Barcode.Contains(str)).ToListAsync();

                        var nextId = (lastId++).ToString();
                        var lengthId = _barcodeConfig.BarcodeLength;
                        var rs = str + $"{nextId.PadLeft(lengthId - nextId.Length, '0')}";

                        while (dbBarcodesByUOM.Any(x => x.Barcode == rs))
                        {
                            nextId = (lastId++).ToString();
                            rs = str + $"{nextId.PadLeft(lengthId - nextId.Length, '0')}";
                        }


                        var barcode = new ArticleBarcode()
                        {
                            Barcode = rs,
                            PONo = detail.PONo,
                            OrderRefNum = importArticle.OrderRefNum,
                            SupplierName = importArticle.SupplierName,
                            FPPOOCNUm = importArticle?.OCNum,
                            RemainQuantity = detail.Quantity,
                            Quantity = detail.Quantity,
                            Location = locations.FirstOrDefault(x => x.Id == detail.LocationId)?.Name,
                            PreLocationId = detail.LocationId,
                            LotNo = detail.LotNo,
                            Site = detail.Site,
                            ArticleName = detail.ArticleName,
                            ArticleCode = detail.ArticleCode,
                            Color = detail.Color,
                            IsActive = detail.IsActive,
                            Note = detail.Note,
                            NumberOfCone = detail.NumberOfCone,
                            OC = detail.OC,
                            Shade = detail.Shade,
                            Size = detail.Size,
                            Grade = detail.Grade,
                            Category = article?.Category,
                            SubCategory = article?.ProductSubCategory,
                            ArticleUOM = importArticle.UOM,
                            BarcodeUOM = detail.UOM,
                            WeightPerCone = detail.WeightPerCone,
                            CurrentLocationId = detail.LocationId,
                        };
                        detail.ArticleBarcode = barcode;
                    }
                }
            }

        }

        public async Task GenBarCode(string UOM, ICollection<ImportDetail> details)
        {
            var checkExisted = await _articleBarcodes.AnyAsync();
            var lastId = 0;
            if (checkExisted)
            {
                lastId = await _articleBarcodes.MaxAsync(x => x.Id);
            }

            MassTransit.Response<GetArticlessResponse> articleReqs = null;
            try
            {
                articleReqs = await _requestClientService.GetResponseAsync<GetArticlessRequest, GetArticlessResponse>(new GetArticlessRequest()
                {
                    ArticleCode = details.Select(o => o.ArticleCode).ToList()
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
            var articles = articleReqs?.Message?.Data;


            var locations = _locations.Where(x => x.LevelLocation == LevelLocation.LevelLocation1);

            foreach (var detail in details)
            {

                var article = articles?.FirstOrDefault(x => x.ArticleCode == detail.ArticleCode);
                if (string.IsNullOrEmpty(detail.UOM))
                {

                    UOM = (article?.Category) switch
                    {
                        nameof(CategoryType.Fiber) => "BALE",
                        nameof(CategoryType.Yarns) => "BOX",
                        nameof(CategoryType.Fabric) or nameof(CategoryType.TextilesFabric) => "ROLL",
                        _ => "DTL",
                    };
                }

                var str = $@"{UOM}{DateTime.Now:yyyyMMdd}/";
                var dbBarcodesByUOM = await _articleBarcodes.Where(x => x.Barcode.Contains(str)).ToListAsync();

                var nextId = (lastId++).ToString();
                var lengthId = _barcodeConfig.BarcodeLength;
                var rs = str + $"{nextId.PadLeft(lengthId - nextId.Length, '0')}";

                while (dbBarcodesByUOM.Any(x => x.Barcode == rs))
                {
                    nextId = (lastId++).ToString();
                    rs = str + $"{nextId.PadLeft(lengthId - nextId.Length, '0')}";
                }


                var barcode = new ArticleBarcode()
                {
                    Barcode = rs,
                    PONo = detail.PONo,
                    OrderRefNum = detail.ImportArticle?.OrderRefNum,
                    SupplierName = detail.ImportArticle?.SupplierName,
                    FPPOOCNUm = detail.ImportArticle?.OCNum,
                    RemainQuantity = detail.Quantity,
                    Quantity = detail.Quantity,
                    Location = locations.FirstOrDefault(x => x.Id == detail.LocationId)?.Name,
                    PreLocationId = detail.LocationId,
                    LotNo = detail.LotNo,
                    Site = detail.Site,
                    ArticleName = detail.ArticleName,
                    ArticleCode = detail.ArticleCode,
                    Color = detail.Color,
                    IsActive = detail.IsActive,
                    Note = detail.Note,
                    NumberOfCone = detail.NumberOfCone,
                    OC = detail.OC,
                    Shade = detail.Shade,
                    Size = detail.Size,
                    Grade = detail.Grade,
                    Category = article?.Category,
                    SubCategory = article?.ProductSubCategory,
                    ArticleUOM = detail.UOM,
                    BarcodeUOM = detail.UOM,
                    WeightPerCone = detail.WeightPerCone,
                    CurrentLocationId = detail.LocationId,
                };
                detail.ArticleBarcode = barcode;
            }

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
                if (modifiedArticleBarcode != null)
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
