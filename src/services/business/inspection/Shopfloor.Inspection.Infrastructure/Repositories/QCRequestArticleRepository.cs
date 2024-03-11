using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class QCRequestArticleRepository : GenericRepositoryAsync<QCRequestArticle>, IQCRequestArticleRepository
    {
        private readonly DbSet<Inspection.Domain.Entities.QCRequestArticle> _qcRequestArticles;
        private readonly DbSet<Inspection.Domain.Entities.QCDefinition> _qcDefinitions;
        public QCRequestArticleRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _qcRequestArticles = _dbContext.Set<QCRequestArticle>();
            _qcDefinitions = _dbContext.Set<QCDefinition>();
        }

        public async Task<QCRequestArticle> GetQCRequesArticletWithInspectionByIdAsync(int id)
        {
            return await _qcRequestArticles.Include(x => x.Inspection).ThenInclude(x => x.InspectionDefectCapturings)
                                        .Include(x => x.Inspection).ThenInclude(x => x.InspectionMesurements)
                                        .Include(x => x.Inspection).ThenInclude(x => x.InspectionBySizes)
                                        .Include(x => x.Inspection).ThenInclude(x => x.Attachments).FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task<QCRequestArticle> GetQCRequestArticleByIdAsync(int id)
        {

            return await _qcRequestArticles.FirstOrDefaultAsync(x => x.Id == id);

        }
        public async Task<List<QCRequestArticle>> GetQCRequestArticleByArticleCodeAsync(string code)
        {
            return await _qcRequestArticles.Where(x => x.ArticleCode == code).ToListAsync();
        }
        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetWithDetailPagedReponseAsync<TParam, TModel>(TParam parameter, int? qcTypeId, string qcRequestNo)
            where TParam : RequestParameter
            where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<QCRequestArticle>().Filter(parameter);
            if (!string.IsNullOrEmpty(qcRequestNo))
            {
                query = query.Where(x => x.QCRequest.QCRequestNo == qcRequestNo);
            }
            if (qcTypeId.HasValue && qcTypeId.Value > 0)
            {
                var qcDefineCodes = await _qcDefinitions.Where(x=>x.QCTypeId== qcTypeId).Select(x=>x.Code).ToListAsync();
                query = query.Where(x => qcDefineCodes.Contains(x.QCRequest.QCDefinitionCode));
            }
            response.Data = await query.Include(x=>x.Inspection)
                                    .Include(x => x.Inpection100PointSys)
                                    .Include(x => x.Inpection4PointSys)
                                    .Include(x => x.InpectionTCStandard).AsNoTracking()
                                    .OrderBy(parameter.OrderBy)
                                    .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                                    .Paged(parameter.PageSize, parameter.PageNumber)
                                    .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                                    .ToListAsync();
            response.TotalCount = response.Data.Count;
            return response;
        }
    }
}
