using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Domain.Enums;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;

namespace Shopfloor.Inspection.Infrastructure.Repositories
{
    public class QCRequestRepository : GenericRepositoryAsync<QCRequest>, IQCRequestRepository
    {
        private readonly DbSet<Inspection.Domain.Entities.QCRequest> _qcRequests;
        public QCRequestRepository(InspectionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _qcRequests = _dbContext.Set<QCRequest>();
        }
        public async Task<QCRequest> GetQCRequesWithDetailByIdAsync(int id, QCScreenType qcScreenType)
        {
            QCRequest qCRequest = null;
            switch (qcScreenType)
            {
                case QCScreenType.Garment:
                    qCRequest= await _qcRequests.Include(x => x.QCRequestArticles).ThenInclude(x => x.Inspection).FirstAsync(x => x.Id == id);
                    break;
                case QCScreenType.Fabric4Point:
                    qCRequest = await _qcRequests.Include(x => x.QCRequestArticles).ThenInclude(x => x.Inpection4PointSys).FirstAsync(x => x.Id == id);
                    break;
                case QCScreenType.Fabric100Point:
                    qCRequest = await _qcRequests.Include(x => x.QCRequestArticles).ThenInclude(x => x.Inpection100PointSys).FirstAsync(x => x.Id == id);
                    break;
                case QCScreenType.TCStandardFixed:
                    qCRequest = await _qcRequests.Include(x => x.QCRequestArticles).ThenInclude(x => x.InpectionTCStandard).FirstAsync(x => x.Id == id);
                    break;
                case QCScreenType.TCStandardPercent:
                    qCRequest = await _qcRequests.Include(x => x.QCRequestArticles).ThenInclude(x => x.InpectionTCStandard).FirstAsync(x => x.Id == id);
                    break;
                default:
                    break;
            }
            return qCRequest;
        }
        public async Task<bool> IsUsedAsync(string qcDefineCode)
        {
            return await _dbContext.Set<QCRequest>().AnyAsync(x => x.QCDefinitionCode == qcDefineCode);
        }
        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetWithDetailPagedReponseAsync<TParam, TModel>(TParam parameter, DateTime? fromDate, DateTime? toDate)
            where TParam : RequestParameter
            where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<QCRequest>().Filter(parameter);
            if (fromDate.HasValue)
            {
                query = query.Where(x => x.QCRequestDate.Date >= fromDate.Value.Date);
            }
            if (toDate.HasValue)
            {
                query = query.Where(x => x.QCRequestDate.Date <= toDate.Value.Date);
            }
            response.Data = await query.AsNoTracking()
                    .OrderBy(parameter.OrderBy)
                    .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                    .SelectMany(x => x.QCRequestArticles)
                    .Paged(parameter.PageSize, parameter.PageNumber)
                    .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            response.TotalCount = response.Data.Count;
            return response;
        }
    }
}
