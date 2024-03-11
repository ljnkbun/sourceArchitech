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
    public class ExportRepository : MasterRepositoryAsync<Export>, IExportRepository
    {
        private readonly DbSet<Export> _exports;
        private readonly DbSet<ExportArticle> _exportArticles;
        private readonly DbSet<ExportDetail> _exportDetails;
        private readonly DbSet<WfxGDI> _wfxGDIs;
        private readonly DbSet<WfxGDIHistory> _wfxGDIHistory;
        private readonly DbSet<ArticleBarcode> _articleBarcodes;
        private readonly BarcodeConfig _barcodeConfig;
        public ExportRepository(BarcodeContext dbContext, IMapper mapper
            , IOptions<BarcodeConfig> setting) : base(dbContext, mapper)
        {
            _exports = _dbContext.Set<Export>();
            _exportArticles = _dbContext.Set<ExportArticle>();
            _exportDetails = _dbContext.Set<ExportDetail>();
            _articleBarcodes = _dbContext.Set<ArticleBarcode>();
            _wfxGDIs = _dbContext.Set<WfxGDI>();
            _barcodeConfig = setting.Value;
        }

        public async Task<Export> GetExportByIdAsync(int id)
        {
            return await _exports
                .Include(x => x.ExportArticles)
                .ThenInclude(x => x.ExportDetails)
                .ThenInclude(x => x.ArticleBarcode)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<Export> AddAsync(Export entity)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                entity.Code = await AutoGenCode();

                var details = entity.ExportArticles.SelectMany(x => x.ExportDetails);
                var wfxGDIs = _wfxGDIs;
                var wfxGDIHises = new List<WfxGDIHistory>();
                foreach (var detail in details)
                {
                    var wfxGDI = wfxGDIs.FirstOrDefault(x => x.ArticleCode == detail.ArticleCode && x.OrderRefNum == detail.OCRefNum && x.SizeCode == detail.SizeCode && x.ColorCode == detail.ColorCode && x.UOM == detail.UOM);
                    if (wfxGDI == null) continue;
                    wfxGDIHises.Add(new()
                    {
                        ExportDetail = detail,
                        WfxGDI = wfxGDI,
                        Quantity = detail.Quantity,
                        RemainQuantity = wfxGDI.RollUnits - detail.Quantity
                    });
                }

                if (wfxGDIHises.Any())
                    await _wfxGDIHistory.AddRangeAsync(wfxGDIHises);

                await AutoGenCodeArticle(entity.ExportArticles);
                await AutoGenCodeDetail(entity.ExportArticles.SelectMany(x => x.ExportDetails));

                await _exports.AddAsync(entity);
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

        private async Task AutoGenCodeDetail(IEnumerable<ExportDetail> details)
        {
            var checkExisted = await _exportDetails.AnyAsync();
            var lastId = 0;
            if (checkExisted)
            {
                lastId = await _exportDetails.MaxAsync(x => x.Id);
            }
            foreach (var article in details)
            {
                var nextId = (lastId++).ToString();
                var lengthId = _barcodeConfig.BarcodeLength;
                article.Code = $"DTL-{DateTime.Now:yyyy-MM-dd}/{nextId.PadLeft(lengthId - nextId.Length, '0')}";
            }
        }

        private async Task AutoGenCodeArticle(ICollection<ExportArticle> exportArticles)
        {
            var checkExisted = await _exportArticles.AnyAsync();
            var lastId = 0;
            if (checkExisted)
            {
                lastId = await _exportArticles.MaxAsync(x => x.Id);
            }
            foreach (var article in exportArticles)
            {
                var nextId = (lastId++).ToString();
                var lengthId = _barcodeConfig.BarcodeLength;
                article.Code = $"ART-{DateTime.Now:yyyy-MM-dd}/{nextId.PadLeft(lengthId - nextId.Length, '0')}";
            }
        }

        private async Task<string> AutoGenCode()
        {
            var checkExisted = await _exports.AnyAsync();
            var lastId = 0;
            if (checkExisted)
            {
                lastId = await _exports.MaxAsync(x => x.Id);
            }
            var nextId = (lastId++).ToString();
            var lengthId = _barcodeConfig.BarcodeLength;
            return $"DOC-{DateTime.Now:yyyy-MM-dd}/{nextId.PadLeft(lengthId - nextId.Length, '0')}";
        }

        public async Task UpdateExportAsync(Export entity, IEnumerable<ExportArticle> modifiedArticles, IEnumerable<ExportArticle> deletedArticles, IEnumerable<ExportDetail> addedDetails, IEnumerable<ExportDetail> modifiedDetails, IEnumerable<ExportDetail> deletedDetails)
        {
            var trans = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var articleBarcodes = deletedDetails.Select(y => y.ArticleBarcode);
                articleBarcodes = articleBarcodes.Where(x => x != null);
                _exportDetails.RemoveRange(deletedDetails);
                if (articleBarcodes.Any())
                    _articleBarcodes.RemoveRange(articleBarcodes);
                _exportArticles.RemoveRange(deletedArticles);

                _exportDetails.UpdateRange(modifiedDetails);
                _exportArticles.UpdateRange(modifiedArticles);

                await AutoGenCodeDetail(addedDetails);

                _exportDetails.AddRange(addedDetails);
                _exports.Update(entity);
                await _dbContext.SaveChangesAsync();
                await trans.CommitAsync();
            }
            catch (Exception)
            {
                await trans.RollbackAsync();
                throw;
            }
        }


        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetModelPagedCustomReponseAsync<TParam, TModel>(TParam parameter, ExportStatus[] exportStatuses, ExportTypes[] exportTypes, WfxStatus[] wfxStatuses) where TParam : RequestParameter where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _exports.Filter(parameter);
            query = query.Where(x => x.IsActive == true);
            if (exportStatuses != null && exportStatuses.Any())
            {
                query = query.Where(x => exportStatuses.Contains(x.Status!.Value));
            }
            if (exportTypes != null && exportTypes.Any())
            {
                query = query.Where(x => exportTypes.Contains(x.GDIType!.Value));
            }
            if(wfxStatuses != null && wfxStatuses.Any())
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

        public async Task<ICollection<Export>> GetByIdsAsync(int[] ids)
        {
            return await _exports.Where(x => ids.Contains(x.Id)).ToListAsync();
        }
    }
}
