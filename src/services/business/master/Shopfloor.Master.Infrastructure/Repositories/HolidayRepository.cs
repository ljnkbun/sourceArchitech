using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;
using Shopfloor.Core.Models.Parameters;
using Shopfloor.Core.Models.Responses;
using Shopfloor.Core.Repositories;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;

namespace Shopfloor.Master.Infrastructure.Repositories
{
    public class HolidayRepository : GenericRepositoryAsync<Holiday>, IHolidayRepository
    {
        public HolidayRepository(MasterContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<PagedResponse<IReadOnlyList<TModel>>> GetHolidayModelPagedReponseAsync<TParam, TModel>(TParam parameter, DateTime? fDate, DateTime? tDate)
            where TParam : RequestParameter
            where TModel : class
        {
            var response = new PagedResponse<IReadOnlyList<TModel>>(parameter.PageNumber, parameter.PageSize);
            var query = _dbContext.Set<Holiday>().Filter(parameter);

            if(fDate != null)
                query = query.Where(x => x.Date != null && x.Date.Value.Date >= fDate.Value.Date);

            if (tDate != null)
                query = query.Where(x => x.Date != null && x.Date.Value.Date <= tDate.Value.Date);

            response.TotalCount = await query.CountAsync();
            response.Data = await query.AsNoTracking()
                    .OrderBy(parameter.OrderBy)
                    .SearchTerm(parameter.SearchTerm, parameter.GetSearchProps())
                    .Paged(parameter.PageSize, parameter.PageNumber)
                    .ProjectTo<TModel>(_mapper.ConfigurationProvider)
                    .AsSingleQuery()
                    .ToListAsync();
            return response;
        }
    }
}
