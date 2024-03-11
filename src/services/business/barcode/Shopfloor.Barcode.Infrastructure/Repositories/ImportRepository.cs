using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using Shopfloor.Barcode.Application.Settings;
using Shopfloor.Barcode.Domain.Constants;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Domain.Enums;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;

namespace Shopfloor.Barcode.Infrastructure.Repositories
{
    public class ImportRepository : MasterRepositoryAsync<Import>, IImportRepository
    {
        private readonly DbSet<Import> _imports;
        private readonly DbSet<ImportArticle> _importArticles;
        private readonly DbSet<ImportDetail> _importDetails;
        private readonly DbSet<WfxPOArticleHistory> _wfxPOArticleHistory;
        private readonly DbSet<WfxPOArticle> _wfxPOArticles;
        private readonly DbSet<ArticleBarcode> _articleBarcodes;
        private readonly BarcodeConfig _barcodeConfig;

        public ImportRepository(BarcodeContext dbContext, IMapper mapper
            , IOptions<BarcodeConfig> setting) : base(dbContext, mapper)
        {
            _imports = _dbContext.Set<Import>();
            _importArticles = _dbContext.Set<ImportArticle>();
            _importDetails = _dbContext.Set<ImportDetail>();
            _articleBarcodes = _dbContext.Set<ArticleBarcode>();
            _wfxPOArticleHistory = _dbContext.Set<WfxPOArticleHistory>();
            _wfxPOArticles = _dbContext.Set<WfxPOArticle>();
            _barcodeConfig = setting.Value;
        }
        public async Task<Import> ViewImportByIdAsync(int id)
        {
            var rs = await _imports
                .Include(x => x.ImportArticles)
                .ThenInclude(x => x.ImportDetails)
                .ThenInclude(x => x.ArticleBarcode)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            _ = rs.ImportArticles.Select(x =>
            {
                x.ImportDetails = x.ImportDetails.OrderByDescending(x => x.ModifiedDate).ToList();
                return x;
            });

            rs.ImportArticles = rs.ImportArticles.OrderByDescending(x => x.ModifiedDate).ToList();

            return rs;
        }

        public async Task<Import> GetImportByIdAsync(int id)
        {
            return await _imports
                .Include(x => x.ImportArticles)
                .ThenInclude(x => x.ImportDetails)
                .ThenInclude(x => x.ArticleBarcode)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task UpdateImportAsync(Import entity, IEnumerable<ImportArticle> addedArticles, IEnumerable<ImportArticle> modifiedArticles, IEnumerable<ImportArticle> deletedArticles, IEnumerable<ImportDetail> addedDetails, IEnumerable<ImportDetail> modifiedDetails, IEnumerable<ImportDetail> deletedDetails)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var articleBarcodes = deletedDetails.Select(y => y.ArticleBarcode);
                foreach (var deletedDetail in deletedDetails)
                {
                    deletedDetail.ImportArticle = null;
                }
                _importDetails.RemoveRange(deletedDetails);
                foreach (var articleBarcode in articleBarcodes)
                {
                    articleBarcode.ImportDetails = null;
                }
                _articleBarcodes.RemoveRange(articleBarcodes);
                _importArticles.RemoveRange(deletedArticles);

                foreach (var modifiedDetail in modifiedDetails)
                {
                    modifiedDetail.ImportArticle = null;
                }
                _importDetails.UpdateRange(modifiedDetails);
                foreach (var modifiedArticle in modifiedArticles)
                {
                    modifiedArticle.Import = null;
                    modifiedArticle.ImportDetails = null;
                }
                _importArticles.UpdateRange(modifiedArticles);

                _importDetails.AddRange(addedDetails);
                _importArticles.AddRange(addedArticles);

                entity.ImportArticles = null;
                _imports.Update(entity);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception e)
            {
                Log.Error(e.InnerException.Message);
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
            catch (Exception)
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
                entity.Code = await AutoGenCodeAsync();
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

        public override async Task<Import> AddAsync(Import entity)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                entity.Code = await AutoGenCodeAsync();

                var details = entity.ImportArticles.SelectMany(x => x.ImportDetails);
                var wfxPOArticles = _wfxPOArticles.AsNoTracking();
                var upadtedwfxPOArticles = new List<WfxPOArticle>();
                var wfxPOArticleHises = new List<WfxPOArticleHistory>();
                foreach (var detail in details)
                {
                    var wfxPOArticle = wfxPOArticles.FirstOrDefault(x => x.ArticleCode == detail.ArticleCode && x.PONo == detail.PONo && x.SizeCode == detail.Size && x.ColorCode == detail.Color && x.UOM == detail.UOM);
                    if (wfxPOArticle == null) continue;
                    var hist = new WfxPOArticleHistory()
                    {
                        ImportDetail = detail,
                        WfxPOArticle = wfxPOArticle,
                        Quantity = detail.Quantity,
                        RemainQuantity = wfxPOArticle.Quantity - detail.Quantity
                    };
                    wfxPOArticleHises.Add(hist);
                    if (!upadtedwfxPOArticles.Select(x => x.Id).Contains(wfxPOArticle.Id)) //we can also use !listWithoutDuplicates.Any(x => x.Equals(item))
                    {
                        wfxPOArticle.WfxPOArticleHistories = new List<WfxPOArticleHistory>() { hist };
                        upadtedwfxPOArticles.Add(wfxPOArticle);
                    }
                    else
                    {
                        wfxPOArticle = upadtedwfxPOArticles.FirstOrDefault(x => x.Id == wfxPOArticle.Id);
                        wfxPOArticle.WfxPOArticleHistories.Add(hist);
                    }
                }

                _wfxPOArticles.UpdateRange(upadtedwfxPOArticles);
                await _imports.AddAsync(entity);
                await _wfxPOArticleHistory.AddRangeAsync(wfxPOArticleHises);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                await trans.RollbackAsync();
                throw;
            }
            return entity;
        }

        private async Task<string> AutoGenCodeAsync()
        {
            var checkExisted = await _imports.AnyAsync();
            var lastId = 0;
            if (checkExisted)
            {
                lastId = await _imports.MaxAsync(x => x.Id);
            }
            var nextId = (lastId++).ToString();
            var lengthId = _barcodeConfig.BarcodeLength;
            return $"DOC-{DateTime.Now:yyyy-MM-dd}/{nextId.PadLeft(lengthId - nextId.Length, '0')}";
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetModelPagedCustomReponseAsync<TParam, TModel>(TParam parameter, ImportStatus[] importStatuses, ImportType[] importTypes, string articleCode, string articleName, string pONo, WfxStatus[] wfxStatuses) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _imports.Filter(parameter);
            query = query.Where(x => x.IsActive == true);
            if (importStatuses != null && importStatuses.Any())
            {
                query = query.Where(x => importStatuses.Contains(x.Status!.Value));
            }
            if (importTypes != null && importTypes.Any())
            {
                query = query.Where(x => importTypes.Contains(x.Type!.Value));
            }
            if (!string.IsNullOrEmpty(articleCode))
            {
                query = query.Where(x => x.ImportArticles.Any(x => x.ArticleCode == articleCode));
            }
            if (!string.IsNullOrEmpty(articleName))
            {
                query = query.Where(x => x.ImportArticles.Any(x => x.ArticleName == articleName));
            }
            if (!string.IsNullOrEmpty(pONo))
            {
                query = query.Where(x => x.ImportArticles.Any(x => x.PONo == pONo));
            }
            if (wfxStatuses != null && wfxStatuses.Any())
            {
                query = query.Where(x => wfxStatuses.Contains(x.WfxStatus!.Value));
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

        public async Task<ICollection<Import>> GetByIdsAsync(int[] ids)
        {
            return await _imports.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
