using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Domain.Interfaces;
using Shopfloor.Production.Infrastructure.Contexts;

namespace Shopfloor.Production.Infrastructure.Repositories
{
    public class FPPOOutputDetailRepository : GenericRepositoryAsync<FPPOOutputDetail>, IFPPOOutputDetailRepository
    {
        private readonly DbSet<FPPOOutput> _fPPOOutputs;
        private readonly DbSet<FPPOOutputDetail> _fPPOOutputDetails;
        public FPPOOutputDetailRepository(ProductionContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _fPPOOutputs = _dbContext.Set<FPPOOutput>();
            _fPPOOutputDetails = _dbContext.Set<FPPOOutputDetail>();
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetCustomModelPagedReponseAsync<TParam, TModel>(TParam parameter, string oCNo, string articleName, string jobOrderNo, string batchNo, string fPPONo, decimal? orderQty, string size, string color)
            where TParam : RequestParameter
            where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _fPPOOutputDetails.Filter(parameter);
            query = query.Where(x => x.IsActive == true);
            if (!string.IsNullOrEmpty(oCNo))
            {
                query = query.Where(x => x.FPPOOutput.OCNo.Contains(oCNo));
            }
            if (!string.IsNullOrEmpty(articleName))
            {
                query = query.Where(x => x.FPPOOutput.ArticleName.Contains(articleName));
            }
            if (!string.IsNullOrEmpty(jobOrderNo))
            {
                query = query.Where(x => x.FPPOOutput.JobOrderNo.Contains(jobOrderNo));
            }
            if (!string.IsNullOrEmpty(batchNo))
            {
                query = query.Where(x => x.FPPOOutput.BatchNo.Contains(batchNo));
            }
            if (!string.IsNullOrEmpty(fPPONo))
            {
                query = query.Where(x => x.FPPOOutput.FPPONo.Contains(fPPONo));
            }
            if (!string.IsNullOrEmpty(size))
            {
                query = query.Where(x => x.Size.Contains(size));
            }
            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(x => x.Color.Contains(color));
            }
            if (!string.IsNullOrEmpty(fPPONo))
            {
                query = query.Where(x => x.FPPOOutput.FPPONo.Contains(fPPONo));
            }
            if (orderQty.HasValue)
            {
                query = query.Where(x => x.PlannedQty == orderQty!.Value);
            }

            response.TotalCount = await query.CountAsync();
            response.Data = await query.Include(x => x.FPPOOutput).AsNoTracking()
                    .OrderBy(parameter.OrderBy)
                    .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                    .Paged(parameter.PageSize, parameter.PageNumber)
                    .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            return response;
        }
    }
}
